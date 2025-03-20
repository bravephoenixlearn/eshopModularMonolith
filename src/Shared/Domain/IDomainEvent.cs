using MediatR;

namespace Shared.Domain
{
    public interface IDomainEvent : INotification
    {
        public Guid EventId => Guid.NewGuid();
        public DateTimeOffset OccuredOn => DateTimeOffset.Now;
        public string EventType => GetType().AssemblyQualifiedName!;
    }
}
