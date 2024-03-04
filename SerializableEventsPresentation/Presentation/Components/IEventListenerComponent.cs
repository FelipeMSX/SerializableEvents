using SerializableEvents.Core.EventArgs;
using System;

namespace SerializableEvents.Components
{
    public interface IEventListenerComponent<TType, TArgs>
        //where TEventHandler : EventListenerBase<TType>
        where TArgs : GenericEventArgs<TType>
    {
        event EventHandler<TArgs> OnEventTriggered;

    }
}
