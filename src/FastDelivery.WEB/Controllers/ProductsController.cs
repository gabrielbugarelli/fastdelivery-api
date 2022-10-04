using FastDelivery.Application.NotificationErros;
using FastDelivery.Application.Services.ProductHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastDelivery.WEB.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : MainController
{

  public ProductsController(IMediator mediator, INotificationHandler<NotificationError> notificationHandler) : base(mediator, notificationHandler)
  {

  }

  [HttpPost]
  public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
  {
    await Mediator.Send(request);

    if (InvalidProcess())
    {
      return BadRequest(GetErrors());
    }

    return Ok();
  }
}
