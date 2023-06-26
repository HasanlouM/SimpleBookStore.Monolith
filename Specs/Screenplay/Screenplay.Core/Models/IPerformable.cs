using Screenplay.Core.Models.Actors;

namespace Screenplay.Core.Models
{
    /// <summary>
    /// A task or interaction that can be performed by an actor.
    /// </summary>
    public interface IPerformable
    {
        void PerformAs<T>(T actor) where T : Actor;
    }
}
