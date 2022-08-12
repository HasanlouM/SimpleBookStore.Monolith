namespace SimpleFramework.Domain
{
    public abstract class DomainEvent<TKey> : IDomainEvent
    {
        protected DomainEvent(TKey id)
        {
            AggregateId = id;
        }

        public TKey AggregateId { get; private set; }
    }
}
