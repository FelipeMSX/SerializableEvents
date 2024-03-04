using SerializableEventsCore.EventArgs;
using System;

namespace SerializableEventsCore.EventListeners
{
    [Serializable]
    public class StringEventListener : EventListenerBase<string, StringEventArgs> { }
}
