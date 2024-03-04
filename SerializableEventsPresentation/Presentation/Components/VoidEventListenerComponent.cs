using SerializableEvents.Core.EventArgs;
using System;

namespace SerializableEvents.Components
{

    public class VoidEventListenerComponent : EventListenerBase, IEventListenerComponent<SerializableEvents.Core.Void, VoidEventArgs>
    {
        public event EventHandler<VoidEventArgs> OnEventTriggered;

        public VoidEventListenerComponent()
        {
            _redirect = (obj) =>
            {
                OnEventTriggered?.Invoke(this, VoidEventArgs.VoidEmpty);
            };

            EventType = typeof(SerializableEvents.Core.EventListeners.VoidEventListener);
        }

        public void Raise()
        {
            ResourceName._eventListener.Raise(SerializableEvents.Core.Void.Empty);
        }
    }
}
