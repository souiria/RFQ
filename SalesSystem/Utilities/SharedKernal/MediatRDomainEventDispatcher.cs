using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernal;

namespace SharedKernel
{
    public class MediatRDomainEventDispatcher : IDomainEventDispatcher
    {
        readonly IMediator _Mediator;
        readonly ILogger<MediatRDomainEventDispatcher> _Logger;

        public MediatRDomainEventDispatcher(IMediator mediator, ILogger<MediatRDomainEventDispatcher> logger)
        {
            _Mediator = mediator;
            _Logger = logger;
        }

        public async Task DispatchAndClearEvents(IEnumerable<IHasDomainEvents> entitiesWithEvents)
        {
            foreach (IHasDomainEvents entity in entitiesWithEvents)
            {
                if (entity is HasDomainEventsBase hasDomainEvents)
                {
                    DomainEventBase[] events = hasDomainEvents.DomainEvents.ToArray();
                    hasDomainEvents.ClearDomainEvents();

                    foreach (DomainEventBase domainEvent in events)
                    {
                        await _Mediator.Publish(domainEvent).ConfigureAwait(false);
                    }
                }
                else
                {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
                    _Logger.LogError(
                      "Entity of type {EntityType} does not inherit from {BaseType}. Unable to clear domain events.",
                      entity.GetType().Name,
                      nameof(HasDomainEventsBase));
#pragma warning restore CA1848 // Use the LoggerMessage delegates
                }
            }
        }
    }
}
