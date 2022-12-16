namespace Common.Domain
{
    public abstract class DomainEvent<T>
    {
        protected DomainEvent(T id)
        {
            AggregateId = id;
        }

        public T AggregateId { get; private set; }
    }
}
