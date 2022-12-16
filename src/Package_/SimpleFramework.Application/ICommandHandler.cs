namespace SimpleFramework.Application
{
    public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand
    {
        Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
    }

    public interface ICommandHandler<in TCommand>
    {
        Task HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}
