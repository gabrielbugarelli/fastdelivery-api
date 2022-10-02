using FluentValidation;

namespace FastDelivery.Application.Services.ProductHandler;

public class ProductRequestValidator : AbstractValidator<CreateProductRequest>
{
  public ProductRequestValidator()
  {
    RuleFor(product => product.Name)
      .NotEmpty().WithMessage("Product name is required")
      .MinimumLength(3).WithMessage("Product name must be longer than {MinLength} characters")
      .MaximumLength(200).WithMessage("Product name must be less than {MaxLength} characters");

    RuleFor(product => product.Description)
      .NotEmpty().WithMessage("Description is required")
      .MinimumLength(3).WithMessage("Description must be longer than {MinLength} characters")
      .MaximumLength(700).WithMessage("Description must be less than {MaxLength} characters");

    RuleFor(product => product.Value)
      .NotEmpty().WithMessage("Product value is required")
      .GreaterThan(0).WithMessage("Product value must be greater than zero");

    RuleFor(product => product.QuantityStock)
      .NotEmpty().WithMessage("Quantity stock is required")
      .GreaterThan(0).WithMessage("Quantity stock must be greater than zero");

    RuleFor(product => product.Type)
      .NotEmpty().WithMessage("Type is required");
  }
}
