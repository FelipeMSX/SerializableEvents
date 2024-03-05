using System;

namespace SerializableEvents.Core
{
    public interface IEventListener
    {
        void Raise(object item);
        Guid Guid { get; }
        string Name { get; set; }

        void Register(IObserver listener);
        void Unregister(IObserver listener);
    }

    public interface IEventListener<out TArgs> : IEventListener where TArgs : IGenericEventArgs
    {
        void Register(IObserver<TArgs> listener);
        void Unregister(IObserver<TArgs> listener);
    }
}
