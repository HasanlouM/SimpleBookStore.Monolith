namespace BookStore.Application.Test.Integration.Utils;

internal interface ITask<in TRequest, TResult>
{
    Task<TResult> Perform(TRequest command);
}

internal interface ITask<in TRequest>
{
    Task Perform(TRequest command);
}