using FastDelivery.Core.Messages;
using MediatR;

namespace FastDelivery.Core.Mediatr;

public class MediatrHandler : IMediatrHandler
{
  private readonly IMediator _mediator;

  public MediatrHandler(IMediator mediator)
  {
    _mediator = mediator;
  }

  public async Task<bool> SendCommand<T>(T command) where T : BaseCommand
  {
    return await _mediator.Send(command);
  }
}
