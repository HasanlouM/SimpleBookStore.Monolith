namespace Common.Domain
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj is T valueObject)
            {
                return IsEquals(valueObject);
            }

            return false;

        }

        private bool IsEquals(ValueObject<T> other)
        {
            return GetEqualityComponents()
                .SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) => current * 23 + (obj?.GetHashCode() ?? 0));
        }

        public static bool operator ==(ValueObject<T> first, ValueObject<T> second)
        {
            if (first is null && second is null)
            {
                return true;
            }

            if (first is null || second is null)
            {
                return false;
            }

            return first.Equals(second);
        }

        public static bool operator !=(ValueObject<T> first, ValueObject<T> second)
        {
            return !(first == second);
        }
    }
}