using System.Text.RegularExpressions;
using Common.Domain.Core.Exceptions;

namespace Common.Domain.Core
{
    public static class Guard
    {
        public static void MinLength(string source, int minLength, string paramName)
        {
            if (source.Length < minLength)
            {
                throw new MinLengthException(paramName, minLength);
            }
        }

        public static void MaxLength(string source, int maxLength, string paramName)
        {
            if (source.Length > maxLength)
            {
                throw new MaxLengthException(paramName, maxLength);
            }
        }

        public static void NotNullOrEmpty(string source, string name)
        {
            NotNull(source, name);
            NotEmpty(source, name);
        }

        public static void NotNullOrDefault(short? source, string name)
        {
            if (source == null || source == default)
            {
                throw new NotNullException(name);
            }
        }

        public static void NotNullOrDefault(int? source, string name)
        {
            if (source == null || source == 0)
            {
                throw new NotNullException(name);
            }
        }

        public static void NotNullOrDefault(long? source, string name)
        {
            if (source == null || source == 0)
            {
                throw new NotNullException(name);
            }
        }

        public static void NotNullOrDefault(decimal? source, string name)
        {
            if (source == null || source == default(decimal))
            {
                throw new NotNullException(name);
            }
        }

        public static void NotNullOrDefault(double? source, string name)
        {
            if (source == null || source == default(double))
            {
                throw new NotNullException(name);
            }
        }

        public static void NotNullOrDefault(Guid? source, string name)
        {
            if (source == null || source == Guid.Empty)
            {
                throw new NotNullException(name);
            }
        }

        public static void NotNullOrDefault(Guid source, string name)
        {
            if (source == Guid.Empty)
            {
                throw new NotEmptyException(name);
            }
        }

        public static void NotNullOrDefault(DateTime? source, string name)
        {
            if (source == null || source == default(DateTime))
            {
                throw new NotNullException(name);
            }
        }

        public static void NotNullOrDefault(DateOnly? source, string name)
        {
            if (source == null || source == default(DateOnly))
            {
                throw new NotNullException(name);
            }
        }

        public static void NotNullOrDefault(DateTimeOffset? source, string name)
        {
            if (source == null || source == default(DateTimeOffset))
            {
                throw new NotNullException(name);
            }
        }

        public static void NotNull(object source, string name)
        {
            if (source is null)
            {
                throw new NotNullException(name);
            }
        }

        public static void NotEmpty(string source, string name)
        {
            if (source == string.Empty)
            {
                throw new NotEmptyException(name);
            }
        }

        public static void NotEmpty<T>(this IEnumerable<T> source, string name)
        {
            if (source is null || !source.Any())
            {
                throw new NotEmptyException(name);
            }
        }

        public static void ValidEnum<T>(T @enum, string name) where T : Enum
        {
            var enumType = @enum.GetType();
            var isValid = Enum.IsDefined(enumType, @enum);

            if (!isValid)
            {
                throw new InvalidParameterException(name);
            }
        }

        public static void ValidMobile(string source, string name)
        {
            NotNullOrEmpty(source, name);

            var isValid = Match(source, "09[0-9]{9}");
            if (!isValid)
            {
                throw new InvalidParameterException(name);
            }
        }

        public static void IsDigit(string source, string name)
        {
            NotNullOrEmpty(source, name);

            var isValid = Match(source, @"^[0-9]+$");
            if (!isValid)
            {
                throw new NotDigitException(name);
            }
        }

        public static void ValidEmail(string source, string name)
        {
            NotNullOrEmpty(source, name);

            var isValid = Match(source, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (!isValid)
            {
                throw new InvalidParameterException(name);
            }
        }

        public static void ValidDomain(string source, string name)
        {
            NotNullOrEmpty(source, name);

            var isValid = Match(source, @"(localhost)|(http[s]?:\/\/|[a-z]*\.[a-z]{3}\.[a-z]{2})([a-z]*\.[a-z]{3})|([a-z]*\.[a-z]*\.[a-z]{3}\.[a-z]{2})|([a-z]+\.[a-z]{3})");
            if (!isValid)
            {
                throw new InvalidParameterException(name);
            }
        }

        public static void GreaterThan(decimal source, decimal second, string name)
        {
            NotNullOrDefault(source, name);
            NotNullOrDefault(second, name);
            if (source <= second)
            {
                throw new InvalidParameterException(name);
            }
        }

        public static void GreaterThan(DateTime source, DateTime second, string name)
        {
            if (source < second)
            {
                throw new InvalidParameterException(name);
            }
        }

        public static void GreaterThan(DateTimeOffset source, DateTimeOffset second, string name)
        {
            if (source < second)
            {
                throw new InvalidParameterException(name);
            }
        }

        public static void ValidDate(string source, string name)
        {
            NotNullOrEmpty(source, name);

            var isValid = Match(source, @"^(\d{4})\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$");
            if (!isValid)
            {
                throw new InvalidParameterException(name);
            }
        }

        public static void OnlyAlphaNumeric(string source, string name)
        {
            NotNullOrEmpty(source, name);
            var isValid = Match(source.Trim(), @"^([a-zA-Z0-9\u0600-\u06FF]+\s*)*$", TimeSpan.FromSeconds(1.5));
            if (!isValid)
            {
                throw new InvalidParameterException(name);
            }
        }

        internal static bool Match(string text, string pattern)
        {
            return Match(text, pattern, TimeSpan.FromSeconds(1.5));
        }

        internal static bool Match(string text, string pattern, TimeSpan timeout)
        {
            try
            {
                return Regex.Match(text, pattern, RegexOptions.None, timeout).Success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void RangeInclusive<T>(T from, T to, T source, string name) where T : IComparable<T>
        {

            if (Comparer<T>.Default.Compare(source, from) == -1 || Comparer<T>.Default.Compare(source, to) == 1)
            {
                throw new OutOfRangeException(name);
            }
        }
    }
}
