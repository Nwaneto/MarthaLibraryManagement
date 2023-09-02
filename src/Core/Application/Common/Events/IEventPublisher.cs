using MarthaLibrary.Shared.Events;

namespace MarthaLibrary.Application.Common.Events;
public interface IEventPublisher : ITransientService
{
    Task PublishAsync(IEvent @event);
}