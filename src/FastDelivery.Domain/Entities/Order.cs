using FastDelivery.Core.DomainObjects;
using FastDelivery.Domain.Enums;

namespace FastDelivery.Domain.Entities;

public class Order : Entity
{
  public DateTime Registration { get; private set; }
  public decimal TotalValue { get; private set; }
  public OrderStatus Status { get; private set; }
  private List<OrderItem> _orderItems;
  public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

  public Order()
  {
    Registration = DateTime.UtcNow;
    Status = OrderStatus.New;
    _orderItems = new List<OrderItem>();
  }

  public void CalculateTotalValue()
  {
    TotalValue = _orderItems.Sum(orderItem => orderItem.CalculateValue());
  }

  public void AddOrderItem(OrderItem orderItem)
  {
    orderItem.SyncOrder(Id);

    if (OrderItemExists(orderItem) is var orderItemExists && orderItemExists != null)
    {
      orderItemExists.AddQuantity(orderItem.Quantity);
      orderItem = orderItemExists;
    }
    else
    {
      _orderItems.Add(orderItem);
    }

    orderItem.CalculateValue();
    CalculateTotalValue();
  }

  public OrderItem OrderItemExists(OrderItem item)
  {
    var itemExists = _orderItems.FirstOrDefault(orderItem => orderItem.ProductId == item.ProductId);
    if (itemExists == null)
    {
      throw new DomainException("Order item does not exists!");
    }

    return itemExists;
  }

  public void AddQuantityItem(OrderItem item, int newQuantity)
  {
    if (OrderItemExists(item) is var orderItemExists && orderItemExists == null)
    {
      throw new Exception("Item does not exists!");
    }

    item.UpdateQuantity(newQuantity);
    CalculateTotalValue();
  }

  public void AwaitingPayment()
  {
    Status = OrderStatus.AwaitingPayment;
  }

  public void CompleteOrder()
  {
    Status = OrderStatus.Completed;
  }

  public void RemoveItem(OrderItem orderItem)
  {
    if (OrderItemExists(orderItem) is var orderItemExists && orderItemExists == null)
    {
      throw new Exception("Item does not exists!");
    }

    _orderItems.Remove(orderItemExists);
    CalculateTotalValue();
  }

  protected override void Validate()
  {
    if (Registration.Date < DateTime.UtcNow.Date)
    {
      throw new DomainException("Invalid date.");
    }
  }
}
