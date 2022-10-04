using FastDelivery.Application.NotificationErros;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastDelivery.WEB.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{

  protected readonly IMediator Mediator;
  protected readonly NotificationErrorHandler NotificationHandler;

  protected MainController(IMediator mediator, INotificationHandler<NotificationError> notificationHandler)
  {
    Mediator = mediator;
    NotificationHandler = (NotificationErrorHandler)notificationHandler;
  }

  protected bool InvalidProcess()
  {
    return NotificationHandler.ErrorsExists();
  }

  protected IEnumerable<NotificationError> GetErrors()
  {
    return NotificationHandler.GetErrors();
  }
}
