using SharedKernal;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedKernel
{
    public abstract class HasDomainEventsBase : IHasDomainEvents
    {
        readonly List<DomainEventBase> _DomainEvents = new();
        [NotMapped]
        public IReadOnlyCollection<DomainEventBase> DomainEvents => _DomainEvents.AsReadOnly();

        protected void RegisterDomainEvent(DomainEventBase domainEvent) => _DomainEvents.Add(domainEvent);
        internal void ClearDomainEvents() => _DomainEvents.Clear();
    }
}
