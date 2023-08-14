namespace Common.Application
{
    public interface ICommandBus
    {
        Task<TResult> Dispatch<TCommand, TResult>(TCommand command, CancellationToken token)
            where TCommand : ICommand;

        Task Dispatch<TCommand>(TCommand command, CancellationToken token)
            where TCommand : ICommand;
    }
}