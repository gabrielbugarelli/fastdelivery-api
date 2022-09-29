using FastDelivery.Domain.Commons;

namespace FastDelivery.Domain.Entities;

public class OrderItem : Entity
{
  public Guid OrderId { get; private set; }
  public Guid ProductId { get; set; }
  public int Quantity { get; private set; }
  public decimal UnitValue { get; private set; }
  public string? ProductName { get; private set; }
  public Order? Order { get; private set; }

  public OrderItem(Guid productId, string productName, int quantity, decimal unitValue)
  {
    ProductId = productId;
    ProductName = productName;
    Quantity = quantity;
    UnitValue = unitValue;

    Validate();
  }

  public void SyncOrder(Guid orderId)
  {
    OrderId = orderId;
  }

  public decimal CalculateValue()
  {
    return UnitValue * Quantity;
  }

  public void AddQuantity(int quantity)
  {
    Quantity += quantity;
  }

  public void UpdateQuantity(int quantity)
  {
    Quantity = quantity;
  }

  protected override void Validate()
  {
    if (ProductId == Guid.Empty)
    {
      throw new DomainException("Product id invalid!");
    }

    if (Quantity <= 0)
    {
      throw new DomainException("The value cannot be less than or equal to zero!");
    }

    if (string.IsNullOrWhiteSpace(ProductName))
    {
      throw new DomainException("Product name cannot be empty!");
    }

    if (UnitValue <= 0)
    {
      throw new DomainException("The value cannot be less than or equal to zero!");
    }
  }
}
