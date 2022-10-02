using FastDelivery.Application.Services.ProductHandler;
using FastDelivery.Core.Mediatr;
using FastDelivery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FastDelivery.WEB.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : MainController
{
  private readonly IMediatrHandler _handler;

  public ProductsController(IMediatrHandler handler)
  {
    _handler = handler;
  }

  [HttpPost]
  public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
  {
    return Ok(await _handler.SendCommand(command));
  }
}
