using FastDelivery.Core.Messages;
using FastDelivery.Domain.Enums;

namespace FastDelivery.Application.Services.ProductHandler;

public class CreateProductCommand : BaseCommand
{
  public string? Name { get; private set; }
  public string? Description { get; private set; }
  public decimal Value { get; private set; }
  public ProductType Type { get; private set; }
  public int QuantityStock { get; private set; }

  public CreateProductCommand(string? name, string? description, decimal value, ProductType type, int quantityStock)
  {
    Name = name;
    Description = description;
    Value = value;
    Type = type;
    QuantityStock = quantityStock;
  }
}
