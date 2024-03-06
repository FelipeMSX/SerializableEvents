using SerializableEvents.Core.EventArgs;
using System;

namespace SerializableEvents.Core.Listeners
{
    [Serializable]
    public class VoidListener : EventListenerBase<Void, VoidEventArgs> { }
}
