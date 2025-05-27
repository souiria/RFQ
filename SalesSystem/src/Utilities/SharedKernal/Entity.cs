namespace SharedKernel
{
    public abstract class Entity
    {
        readonly List<IDomainEvent> _DomainEvents = [];

        public IList<IDomainEvent> DomainEvents => [.. _DomainEvents];

        public void ClearDomainEvents()
        {
            _DomainEvents.Clear();
        }

        public void Raised(IDomainEvent domainEvent)
        {
            _DomainEvents.Add(domainEvent);
        }
    }
}
