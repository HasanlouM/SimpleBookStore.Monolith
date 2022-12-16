namespace Common.Application
{
    public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand
    {
        Task<TResult> HandleAsync(
            TCommand command, CancellationToken cancellation = default);
    }

    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(
            TCommand command, CancellationToken cancellation = default);
    }
}
