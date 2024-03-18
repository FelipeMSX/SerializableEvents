using SerializableEvents.Core.EventArgs;
using SerializableEvents.Infra;
using System;

namespace SerializableEvents.Core.Listeners
{
    [SerializableEventAttribute("b4007e67-eaa8-44b8-ba51-b45c3eeb8a1a", typeof(VoidListener))]
    public class VoidListener : EventListenerBase<Void, VoidEventArgs>
    {
        public VoidListener(Guid guid) : base(guid) { }
    }
}
