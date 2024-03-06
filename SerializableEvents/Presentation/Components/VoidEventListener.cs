using SerializableEvents.Core.EventArgs;
using System;
using System.ComponentModel;

namespace SerializableEvents.Components
{
    [ToolboxItem(true)]
    public class VoidEventListener : EventListenerBase, IEventListenerComponent<SerializableEvents.Core.Void, VoidEventArgs>
    {
        public event EventHandler<VoidEventArgs> OnEventTriggered;

        public VoidEventListener()
        {
            _redirect = (obj) =>
            {
                OnEventTriggered?.Invoke(this, VoidEventArgs.VoidEmpty);
            };

            EventType = typeof(SerializableEvents.Core.Listeners.VoidListener);
        }

        public void Raise()
        {
            SerializableEvent.Raise(SerializableEvents.Core.Void.Empty);
        }
    }
}
