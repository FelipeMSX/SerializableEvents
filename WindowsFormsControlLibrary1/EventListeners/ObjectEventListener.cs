using SerializableEventsCore.EventArgs;
using System;

namespace SerializableEventsCore.EventListeners
{
    [Serializable]
    public class ObjectEventListener : EventListenerBase<object, ObjectEventArgs> { }
}
