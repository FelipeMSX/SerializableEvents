using System;

namespace SerializableEventsCore
{

    public interface IGenericEventArgs
    {
        object Data { get; }
        DateTime CreatedAt { get; }
    }

    public interface IGenericEventArgs<T> : IGenericEventArgs
    {
        new T Data { get; }
    }
}
