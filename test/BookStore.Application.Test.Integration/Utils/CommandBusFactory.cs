using Autofac;
using Common.Application;
using Common.Infrastructure;

namespace BookStore.Application.Test.Integration.Utils;

public static class CommandBusFactory
{
    public static ICommandBus New(ILifetimeScope scope = null)
    {
        scope ??= ContainerBuilder.New().Build();

        return new CommandBus(scope);
    }
}