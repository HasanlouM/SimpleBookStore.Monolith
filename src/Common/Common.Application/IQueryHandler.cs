﻿namespace Common.Application
{
    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(
            TQuery query, CancellationToken cancellation = default);
    }
}