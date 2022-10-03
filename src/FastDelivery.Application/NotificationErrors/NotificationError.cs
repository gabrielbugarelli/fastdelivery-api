using MediatR;

namespace FastDelivery.Application.NotificationErros;

public class NotificationError : INotification
{
  public string ProcessName { get; set; }
  public string Message { get; set; }

  public NotificationError(string processName, string message)
  {
    Message = message;
    ProcessName = processName;
  }

  public NotificationError(string message)
  {
    ProcessName = "Default process";
  }
}