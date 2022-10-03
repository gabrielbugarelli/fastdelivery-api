using FastDelivery.Domain.Entities;
using FastDelivery.Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using FastDelivery.Application.NotificationErros;

namespace FastDelivery.Application.Services.ProductHandler;

public class ProductRequestHandler : IRequestHandler<CreateProductRequest, bool>
{
  private readonly IProductRepository _productRepository;
  private readonly IMediator _mediator;


  public ProductRequestHandler(IProductRepository productRepository, IMediator mediator)
  {
    _mediator = mediator;
    _productRepository = productRepository;
  }

  public async Task<bool> Handle(CreateProductRequest request, CancellationToken cancellationToken)
  {
    var validator = new ProductRequestValidator();

    var result = Validate(request, validator);

    if (!result)
    {
      return false;
    }

    var product = new Product(request.Name, request.Description, request.Value, request.Type, request.QuantityStock);
    await _productRepository.Create(product);

    return true;
  }

  private bool Validate<TEntity, TValidator>(TEntity entity, TValidator validator)
    where TEntity : class where TValidator : AbstractValidator<TEntity>
  {
    var validationResult = validator.Validate(entity);

    foreach (var error in validationResult.Errors)
    {
      var notification = new NotificationError(entity.GetType().Name, error.ErrorMessage);
      _mediator.Publish(notification);
    }

    return validationResult.IsValid;
  }
}