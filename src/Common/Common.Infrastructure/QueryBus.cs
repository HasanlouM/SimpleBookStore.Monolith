﻿using Autofac;
using Common.Application;

namespace Common.Infrastructure
{
    public class QueryBus : IQueryBus
    {
        private readonly ILifetimeScope _scope;

        public QueryBus(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken token)
        {
            var handlerType = typeof(IQueryHandler<,>)
                .MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _scope.Resolve(handlerType);

            return await handler.HandleAsync((dynamic)query, token);
        }
    }
}