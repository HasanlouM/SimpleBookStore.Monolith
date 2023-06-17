using Autofac;

namespace BookStore.Application.Test.Integration.Utils;

public class ContainerBuilder
{
    private readonly Autofac.ContainerBuilder _container;

    private ContainerBuilder()
    {
        _container = new Autofac.ContainerBuilder();
    }

    public static ContainerBuilder New()
    {
        return new ContainerBuilder();
    }

    public ContainerBuilder Register<T>(T instance)
    {
        _container.Register(i => instance);
        return this;
    }

    public ILifetimeScope Build()
    {
        return _container.Build();
    }
}