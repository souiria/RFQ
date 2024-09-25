namespace Edi.Common.Base;

/// <summary>
/// A base class for DDD Entities. Includes support for domain events dispatched post-persistence.
/// If you prefer GUID Ids, change it here.
/// If you need to support both GUID and int IDs, change to EntityBase<TId> and use TId as the type for Id.
/// </summary>
public abstract class EntityBase<TId> : EntityBase
{
    public TId Id { get; set; }
    public Guid CreatedById { get; set; }
    public string? CreatedBy { get; set; }
    public Guid ModifiedById { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}

public abstract class EntityBase
{
    private List<DomainEventBase> _domainEvents;
    public EntityBase()
    {
        _domainEvents = new();
    }

    //public EntityBase(List<DomainEventBase> domainevents)
    //{
    //    _domainEvents = domainevents;
    //}

    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
    internal void ClearDomainEvents() => _domainEvents.Clear();
}