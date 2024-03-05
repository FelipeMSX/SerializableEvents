using SerializableEvents.Core.EventArgs;
using System;
using System.ComponentModel;

namespace SerializableEvents.Components
{
    [ToolboxItem(true)]
    public partial class StringEventListener : EventListenerBase, IEventListenerComponent<string, StringEventArgs>
    {
        public event EventHandler<StringEventArgs> OnEventTriggered;

        public StringEventListener()
        {
            _redirect = (obj) =>
            {
                OnEventTriggered?.Invoke(this, (StringEventArgs)obj);
            };

            EventType = typeof(SerializableEvents.Core.Listeners.StringListener);
        }


        public void Raise(string obj)
        {
            SerializableEvent.Raise(obj);
        }
    }
}
