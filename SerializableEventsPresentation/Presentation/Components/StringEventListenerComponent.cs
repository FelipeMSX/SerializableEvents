using SerializableEvents.Core;
using SerializableEvents.Core.EventArgs;
using System;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Windows.Forms;

namespace SerializableEvents.Components
{
    [ToolboxItem(true)]
    public partial class StringEventListenerComponent : EventListenerBase, IEventListenerComponent<string, StringEventArgs>
    {
        public event EventHandler<StringEventArgs> OnEventTriggered;

        public StringEventListenerComponent()
        {
            _redirect = (obj) =>
            {
                OnEventTriggered?.Invoke(this, (StringEventArgs)obj);
            };

            EventType = typeof(SerializableEvents.Core.EventListeners.StringEventListener);
        }


        public void Raise(string obj)
        {
            SerializableEvent.Raise(obj);
        }
    }
}
