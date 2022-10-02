using FastDelivery.Domain.Entities;
using FastDelivery.Domain.Interfaces.Repositories;
using FluentValidation.Results;
using MediatR;

namespace FastDelivery.Application.Services.ProductHandler;

public class ProductRequestHandler : IRequestHandler<CreateProductRequest, bool>
{
  private readonly IProductRepository _productRepository;

  public ProductRequestHandler(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

  public async Task<bool> Handle(CreateProductRequest request, CancellationToken cancellationToken)
  {
    var validator = new ProductRequestValidator();
    ValidationResult result = validator.Validate(request);

    var product = new Product(request.Name, request.Description, request.Value, request.Type, request.QuantityStock);
    await _productRepository.Create(product);

    return true;
  }
}