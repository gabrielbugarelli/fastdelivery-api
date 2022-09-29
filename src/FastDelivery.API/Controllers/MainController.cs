using Microsoft.AspNetCore.Mvc;

namespace FastDelivery.API.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
  public MainController() { }

  protected ActionResult CustomReponse(object result = null)
  {
    return Ok(new
    {
      sucess = true,
      data = result
    });
  }
}
