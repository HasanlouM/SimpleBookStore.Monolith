using Autofac;
using Common.Application;

namespace Common.Infrastructure
{
    public class CommandBus : ICommandBus
    {
        private readonly ILifetimeScope _scope;

        public CommandBus(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public async Task<TResult> Dispatch<TCommand, TResult>(TCommand command, CancellationToken token)
            where TCommand : ICommand
        {
            var handlerType = typeof(ICommandHandler<,>)
                .MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = _scope.Resolve(handlerType);

            return await handler.HandleAsync((dynamic)command, token);
        }

        public async Task Dispatch<T>(T command, CancellationToken token) where T : ICommand
        {
            var handler = _scope.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command, token);
        }
    }
}