using FastDelivery.Core.DomainObjects;
using FastDelivery.Domain.Enums;

namespace FastDelivery.Domain.Entities;

public class Product : Entity
{
  public string Name { get; private set; }
  public string Description { get; private set; }
  public decimal Value { get; private set; }
  public bool Active { get; private set; }
  public DateTime Registration { get; private set; }
  public ProductType Type { get; private set; }
  public int QuantityStock { get; private set; }

  public Product(string name, string description, decimal value, ProductType type, int quantityStock)
  {
    Name = name;
    Description = description;
    Active = true;
    Value = value;
    Registration = DateTime.UtcNow;
    Type = type;
    QuantityStock = quantityStock;

    Validate();
  }

  public void Enable() => Active = true;
  public void Disable() => Active = false;
  public void ChangeType(ProductType newType) => Type = newType;

  public void ChangeDescription(string newDescription)
  {
    if (string.IsNullOrWhiteSpace(newDescription))
    {
      throw new DomainException("Invalid description.");
    }

    Description = newDescription;
  }

  public void ChangeName(string name)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      throw new DomainException("Invalid name.");
    }

    Name = name;
  }

  public void DebitStock(int quantity)
  {
    if (quantity < 0)
    {
      throw new DomainException("Quantity invalid.");
    }

    if (!HaveStock(quantity))
    {
      throw new DomainException("Not have stock!");
    }

    QuantityStock -= quantity;
  }

  public bool HaveStock(int stock) => stock >= QuantityStock;

  public void AddStock(int quantity)
  {
    QuantityStock += quantity;
  }

  protected override void Validate()
  {
    if (string.IsNullOrWhiteSpace(Name))
    {
      throw new DomainException("Name cannot be empty!");
    }

    if (string.IsNullOrWhiteSpace(Description))
    {
      throw new DomainException("Description cannot be empty!");
    }

    if (Value <= 0)
    {
      throw new DomainException("The value cannot be less than or equal to zero!");
    }

    if (Registration.Date < DateTime.UtcNow.Date)
    {
      throw new DomainException("The product cannot be registered on a retroactive date!");
    }

    if (QuantityStock <= 0)
    {
      throw new DomainException("The quantity stock cannot be less than or equal to zero!");
    }
  }
}
