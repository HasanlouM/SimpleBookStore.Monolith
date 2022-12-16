using System.Linq.Expressions;

namespace Common.Application.Utils
{
    public static class ExpressionBuilder
    {
        public static Expression<Func<T, bool>> Create<T>(Expression<Func<T, bool>> exp)
        {
            return exp;
        }

        public static Expression<Func<T, bool>> And<T>(
            this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.AndAlso);
        }
        public static Expression<Func<T, bool>> Or<T>(
            this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.OrElse);
        }
        public static Expression<Func<T, bool>> Not<T>(
            this Expression<Func<T, bool>> expression)
        {
            var negated = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(negated, expression.Parameters);
        }
        static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            var map = first.Parameters
                .Select((f, i) => new { f, s = second.Parameters[i] })
                .ToDictionary(p => p.s, p => p.f);

            var secondBody = ParameterBinder.ReplaceParameters(map, second.Body);

            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        class ParameterBinder : ExpressionVisitor
        {
            private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

            ParameterBinder(Dictionary<ParameterExpression, ParameterExpression> map)
            {
                _map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
            }

            public static Expression ReplaceParameters(
                Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
            {
                return new ParameterBinder(map).Visit(exp);
            }

            protected override Expression VisitParameter(ParameterExpression p)
            {
                if (_map.TryGetValue(p, out var replacement))
                {
                    p = replacement;
                }

                return base.VisitParameter(p);
            }
        }
    }
}
