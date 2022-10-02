using FastDelivery.Domain.Entities;
using FastDelivery.Domain.Interfaces.Repositories;
using MediatR;

namespace FastDelivery.Application.Services.ProductHandler;

public class ProductCommandHandler : IRequestHandler<CreateProductRequest, bool>
{
  private readonly IProductRepository _productRepository;

  public ProductCommandHandler(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

  public async Task<bool> Handle(CreateProductRequest request, CancellationToken cancellationToken)
  {
    var product = new Product(request.Name, request.Description, request.Value, request.Type, request.QuantityStock);
    await _productRepository.Create(product);

    return true;
  }
}