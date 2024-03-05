using SerializableEvents.Core.EventArgs;
using System;
using System.ComponentModel;

namespace SerializableEvents.Components
{
    [ToolboxItem(true)]
    public class ObjectEventListener : EventListenerBase, IEventListenerComponent<object, ObjectEventArgs>
    {
        public event EventHandler<ObjectEventArgs> OnEventTriggered;

        public ObjectEventListener()
        {
            _redirect = (obj) =>
            {
                OnEventTriggered?.Invoke(this,(ObjectEventArgs)obj);
            };

            EventType = typeof(SerializableEvents.Core.Listeners.ObjectListener);
        }

        public void Raise(object obj)
        {
            SerializableEvent.Raise(obj);
        }
    }
}
