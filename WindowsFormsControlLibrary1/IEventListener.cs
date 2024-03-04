﻿using System;

namespace SerializableEventsCore
{
    public interface IEventListener
    {
        void Raise(object item);
        Guid Guid { get; }
        string Name { get; set; }

        void Register(IObserver listener);
        void Unregister(IObserver listener);
    }

    public interface IEventListener<TType> : IEventListener where TType : IGenericEventArgs
    {
        void Register(IObserver<TType> listener);
        void Unregister(IObserver<TType> listener);
    }
}
