namespace SimpleFramework.Application
{
    public interface ICommandBus
    {
        Task<TResult> Dispatch<TCommand, TResult>(TCommand command);
        Task Dispatch<T>(T command);
    }
}