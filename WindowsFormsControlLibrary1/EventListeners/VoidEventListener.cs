using SerializableEventsCore.EventArgs;
using System;

namespace SerializableEventsCore.EventListeners
{
    [Serializable]
    public class VoidEventListener : EventListenerBase<Void, VoidEventArgs> { }
}
