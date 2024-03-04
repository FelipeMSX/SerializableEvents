using SerializableEvents.Core.EventArgs;
using System;

namespace SerializableEvents.Core.EventListeners
{
    [Serializable]
    public class ObjectEventListener : EventListenerBase<object, ObjectEventArgs> { }
}
