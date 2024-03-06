using SerializableEvents.Core.EventArgs;
using System;

namespace SerializableEvents
{
    public interface IEventListenerComponent<TType, TArgs>
        //where TEventHandler : EventListenerBase<TType>
        where TArgs : GenericEventArgs<TType>
    {
        event EventHandler<TArgs> OnEventTriggered;

    }
}
