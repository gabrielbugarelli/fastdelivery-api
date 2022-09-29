using FastDelivery.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FastDelivery.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : MainController {

  [HttpGet]
  public async Task<IActionResult> FindProducts()
  {
    return Ok();
  }
}
