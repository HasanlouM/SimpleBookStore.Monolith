using Autofac;

namespace SimpleFramework.Application
{
    public class QueryBus : IQueryBus
    {
        private readonly ILifetimeScope _scope;

        public QueryBus(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query)
        {
            var handlerType = typeof(IQueryHandler<,>)
                .MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _scope.Resolve(handlerType);

            return await handler.HandleAsync((dynamic)query, CancellationToken.None);
        }
    }
}