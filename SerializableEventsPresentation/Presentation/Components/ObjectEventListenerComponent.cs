﻿using SerializableEvents.Core.EventArgs;
using System;

namespace SerializableEvents.Components
{

    public class ObjectEventListenerComponent : EventListenerBase, IEventListenerComponent<object, ObjectEventArgs>
    {
        public event EventHandler<ObjectEventArgs> OnEventTriggered;

        public ObjectEventListenerComponent()
        {
            _redirect = (obj) =>
            {
                OnEventTriggered?.Invoke(this,(ObjectEventArgs)obj);
            };

            EventType = typeof(SerializableEvents.Core.EventListeners.ObjectEventListener);
        }

        public void Raise(object obj)
        {
            ResourceName._eventListener.Raise(obj);
        }
    }
}