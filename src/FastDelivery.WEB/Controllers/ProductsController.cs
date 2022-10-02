using FastDelivery.Application.Services.ProductHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastDelivery.WEB.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : MainController
{
  private readonly IMediator _mediator;

  public ProductsController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost]
  public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest command)
  {
    return Ok(await _mediator.Send(command));
  }
}
