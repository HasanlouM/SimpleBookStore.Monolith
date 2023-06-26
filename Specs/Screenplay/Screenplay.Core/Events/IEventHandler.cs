namespace Screenplay.Core.Events
{
    public interface IEventHandler
    {
        void Handle(IEvent @event);
    }
}
