using FastDelivery.Domain.Enums;

namespace FastDelivery.Domain.Entities;
internal class Order : Entity {
  public DateTime Registration { get; private set; }
  public decimal TotalValue { get; private set; }
  public OrderStatus Status { get; private set; }
  private List<OrderItem> _orderItems;
  public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
}
