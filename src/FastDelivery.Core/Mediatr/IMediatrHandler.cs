using FastDelivery.Core.Messages;

namespace FastDelivery.Core.Mediatr;

public interface IMediatrHandler
{
  Task<bool> SendCommand<T>(T command) where T : BaseCommand;
}