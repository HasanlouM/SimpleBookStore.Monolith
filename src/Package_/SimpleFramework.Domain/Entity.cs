namespace SimpleFramework.Domain
{
    public abstract class Entity<TKey>
    {
        protected Entity()
        {
        }

        public TKey Id { get; protected set; }
        public bool Deleted { get; protected set; }
        public DateTime CreateAt { get; protected set; }
    }
}