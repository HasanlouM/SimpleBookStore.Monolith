namespace Common.Domain
{
    public abstract class Entity<T>
    {
        protected Entity()
        {
        }

        public T Id { get; protected set; }
        public bool Deleted { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? ModifiedAt { get; protected set; }
    }
}