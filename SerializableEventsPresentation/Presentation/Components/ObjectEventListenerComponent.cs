using SerializableEvents.Core.EventArgs;
using System;
using System.ComponentModel;

namespace SerializableEvents.Components
{
    [ToolboxItem(true)]
    public class ObjectEventListenerComponent : EventListenerBase, IEventListenerComponent<object, ObjectEventArgs>
    {
        public event EventHandler<ObjectEventArgs> OnEventTriggered;

        public ObjectEventListenerComponent()
        {
            _redirect = (obj) =>
            {
                OnEventTriggered?.Invoke(this,(ObjectEventArgs)obj);
            };

            EventType = typeof(SerializableEvents.Core.EventListeners.ObjectEventListener);
        }

        public void Raise(object obj)
        {
            SerializableEvent.Raise(obj);
        }
    }
}
