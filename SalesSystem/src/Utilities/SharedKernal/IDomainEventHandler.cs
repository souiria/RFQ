namespace SharedKernel
{
    public interface IDomainEventsHandler<in T> where T : IDomainEvent
    {
        Task Handle(T domainEvent, CancellationToken cancellationToken);
    }
}
