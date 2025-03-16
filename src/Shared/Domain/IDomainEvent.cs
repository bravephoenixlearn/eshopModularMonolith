using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Domain
{
    public interface IDomainEvent : INotification
    {
        public Guid EventId => Guid.NewGuid();
        public DateTimeOffset OccuredOn => DateTimeOffset.Now;
        public string EventType => GetType().AssemblyQualifiedName!;
    }
}
