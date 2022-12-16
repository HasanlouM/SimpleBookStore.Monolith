using Autofac;

namespace SimpleFramework.Application
{
    public class CommandBus : ICommandBus
    {
        private readonly ILifetimeScope _scope;

        public CommandBus(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public async Task<TResult> Dispatch<TCommand, TResult>(TCommand command)
        {
            var handlerType = typeof(ICommandHandler<,>)
                .MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = _scope.Resolve(handlerType);

            return await handler.HandleAsync((dynamic)command, CancellationToken.None);
        }

        public async Task Dispatch<T>(T command)
        {
            var handler = _scope.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command, CancellationToken.None);
        }
    }
}