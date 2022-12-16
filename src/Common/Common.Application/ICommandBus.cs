namespace Common.Application
{
    public interface ICommandBus
    {
        Task<TResult> Dispatch<TCommand, TResult>(TCommand command)
            where TCommand : ICommand;

        Task Dispatch<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}