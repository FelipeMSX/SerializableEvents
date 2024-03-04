using SerializableEvents.Core.EventArgs;
using System;

namespace SerializableEvents.Core.EventListeners
{
    [Serializable]
    public class VoidEventListener : EventListenerBase<Void, VoidEventArgs> { }
}
