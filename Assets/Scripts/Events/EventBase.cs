using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu]
    public class EventBase : ScriptableObject
    {
        private List<EventBaseListener> _listeners = new List<EventBaseListener>();

        public void Raise()
        {
            for (int i = 0; i < _listeners.Count; i++)
            {
                _listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(EventBaseListener listener)
        {
            _listeners.Add(listener);
        }

        public void UnregisterListener(EventBaseListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}