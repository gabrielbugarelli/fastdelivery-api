
using MediatR;

namespace FastDelivery.Core.Messages;

public abstract class BaseCommand : IRequest<bool>
{
  public string CommandType { get; set; }
  public Guid AggregateId { get; set; }
  public DateTime Created { get; set; }


  public BaseCommand()
  {
    Created = DateTime.UtcNow;
    CommandType = GetType().Name;
  }

}