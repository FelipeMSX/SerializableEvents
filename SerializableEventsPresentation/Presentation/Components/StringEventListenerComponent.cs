using SerializableEvents.Core;
using SerializableEvents.Core.EventArgs;
using System;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Windows.Forms;

namespace SerializableEvents.Components
{
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

            if (this.GetService(typeof(IDesignerHost)) is IDesignerHost host)
            {
                IComponent componentHost = host.RootComponent;
                if (componentHost is ContainerControl)
                {
                    var test = (componentHost as ContainerControl).FindForm();
                }
            }
            ResourceName._eventListener.Raise(obj);
        }
    }
}
