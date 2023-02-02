using Events;

namespace Interfaces
{
    public interface IEventBase
    {
        void RaiseEvent();
        void RegisterListener(EventListener listener);
        void UnregisterListener(EventListener listener);
    }
}