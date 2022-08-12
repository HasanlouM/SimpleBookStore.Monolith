namespace SimpleFramework.Domain
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>
    {
        private List<IDomainEvent> _uncommittedEvents;

        protected AggregateRoot()
        {
            _uncommittedEvents = new List<IDomainEvent>();
        }

        public IReadOnlyCollection<IDomainEvent> UncommittedEvents => _uncommittedEvents.AsReadOnly();

        public void Causes(DomainEvent<TKey> @event)
        {
            Guard.NotNull(@event, nameof(@event));

            _uncommittedEvents.Add(@event);
        }

        public void ClearEvents()
        {
            _uncommittedEvents = new List<IDomainEvent>();
        }
    }
}
