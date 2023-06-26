namespace Screenplay.Core.Events
{
    public interface ISelfDescriptiveEvent : IEvent, ICanDescribeMyself
    {
    }
}
