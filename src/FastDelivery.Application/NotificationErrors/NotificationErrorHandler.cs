using MediatR;

namespace FastDelivery.Application.NotificationErros;

public class NotificationErrorHandler : INotificationHandler<NotificationError>
{
  private readonly List<NotificationError> _errors;

  public NotificationErrorHandler()
  {
    _errors = new List<NotificationError>();
  }

  async public Task Handle(NotificationError notification, CancellationToken cancellationToken)
  {
    _errors.Add(notification);
    await Task.CompletedTask;
  }
}