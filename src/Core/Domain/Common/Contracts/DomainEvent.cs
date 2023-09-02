using MarthaLibrary.Shared.Events;

namespace MarthaLibrary.Domain.Common.Contracts;
public abstract class DomainEvent : IEvent
{
    public DateTime TriggeredOn { get; protected set; } = DateTime.UtcNow;
}