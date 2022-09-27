namespace FastDelivery.Domain.Entities;

internal class OrderItem : Entity {
  public Guid OrderId { get; private set; }
  public Guid ProductId { get; set; }
  public int Quantity { get; private set; }
  public decimal UnitValue { get; private set; }
  public string? ProductName { get; private set; }
  public Order? Order { get; private set; }

  public decimal CalculateValue() {
    return UnitValue * Quantity;
  }

  public void AddQuantity(int quantity) {
    Quantity += quantity;
  }
}
