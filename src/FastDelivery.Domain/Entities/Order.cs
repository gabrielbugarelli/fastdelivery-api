using FastDelivery.Domain.Enums;

namespace FastDelivery.Domain.Entities;

internal class Order : Entity {
  public DateTime Registration { get; private set; }
  public decimal TotalValue { get; private set; }
  public OrderStatus Status { get; private set; }
  private List<OrderItem> _orderItems;
  public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

  public Order() {
    _orderItems = new List<OrderItem>();
  }

  public void CalculateTotalValue() {
    TotalValue = _orderItems.Sum(orderItem => orderItem.CalculateValue());
  }

  public void AddOrderItem(OrderItem orderItem) {
    if (OrderItemExists(orderItem) is var orderItemExists && orderItemExists != null) {
      orderItemExists.AddQuantity(orderItem.Quantity);
      orderItem = orderItemExists;
    }
    else {
      _orderItems.Add(orderItem);
    }

    orderItem.CalculateValue();
    CalculateTotalValue();
  }

  public OrderItem OrderItemExists(OrderItem orderItem) {
    var itemExists = _orderItems.FirstOrDefault(orderItem => orderItem.ProductId == orderItem.ProductId);
    return itemExists;
  }

  public void RemoveItem(OrderItem orderItem) {
    if (OrderItemExists(orderItem) is var orderItemExists && orderItemExists != null) {
      throw new Exception("Order item already exists!");
    }

    _orderItems.Remove(orderItemExists);
    CalculateTotalValue();
  }
}
