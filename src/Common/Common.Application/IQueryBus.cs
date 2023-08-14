namespace Common.Application
{
    public interface IQueryBus
    {
        Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken token);
    }
}