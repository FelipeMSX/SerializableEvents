using SerializableEvents.Core.EventArgs;
using System;

namespace SerializableEvents.Core.EventListeners
{
    [Serializable]
    public class StringEventListener : EventListenerBase<string, StringEventArgs> { }
}
