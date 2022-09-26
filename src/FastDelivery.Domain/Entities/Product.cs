using FastDelivery.Domain.Enums;

namespace FastDelivery.Domain.Entities;

internal class Product : Entity {
  public Product(string name, string description, decimal value, ProductType type, int quantityStock) {
    Name = name;
    Description = description;
    Value = value;
    Registration = DateTime.UtcNow;
    Type = type;
    QuantityStock = quantityStock;
  }

  public string Name { get; private set; }
  public string Description { get; private set; }
  public decimal Value { get; private set; }
  public bool Active { get; private set; }
  public DateTime Registration { get; private set; }
  public ProductType Type { get; private set; }
  public int QuantityStock { get; private set; }

  public void Enable() => Active = true;
  public void Disable() => Active = false;
  public void ChangeType(ProductType newType) => Type = newType;

  public void ChangeDescription(string newDescription) {
    if (string.IsNullOrWhiteSpace(newDescription)) {
      throw new Exception("Invalid description.");
    }

    Description = newDescription;
  }

  public void ChangeName(string name) {
    if (string.IsNullOrWhiteSpace(name)) {
      throw new Exception("Invalid name.");
    }

    Name = name;
  }

  public void DebitStock(int quantity) {
    if (quantity < 0) {
      throw new Exception("Quantity invalid.");
    }

    if (!HaveStock(quantity)) {
      throw new Exception("Not have stock!");
    }

    QuantityStock -= quantity;
  }

  public bool HaveStock(int stock) => stock >= QuantityStock;

  public void AddStock(int quantity) {
    QuantityStock += quantity;
  }
}
