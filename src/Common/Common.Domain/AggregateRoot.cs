using Common.Domain.Core;

namespace Common.Domain
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>
    {
        private List<DomainEvent<TKey>> _uncommittedEvents;

        protected AggregateRoot()
        {
            _uncommittedEvents = new List<DomainEvent<TKey>>();
        }

        public IReadOnlyList<DomainEvent<TKey>> UncommittedEvents =>
            _uncommittedEvents.AsReadOnly();

        protected void Causes(DomainEvent<TKey> @event)
        {
            Guard.NotNull(@event, nameof(@event));

            _uncommittedEvents.Add(@event);
        }

        public void ClearEvents()
        {
            _uncommittedEvents = new List<DomainEvent<TKey>>();
        }
    }
}