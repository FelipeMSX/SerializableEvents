using SerializableEvents.Core.EventArgs;
using SerializableEvents.Infra;
using System;

namespace SerializableEvents.Core.Listeners
{
    [SerializableEventAttribute("7ba1e308-63c2-4bb9-a642-51d19f5e9c1a", typeof(ObjectListener))]
    public class ObjectListener : EventListenerBase<object, ObjectEventArgs>
    {
        public ObjectListener(Guid guid) : base(guid) { }
    }
}
