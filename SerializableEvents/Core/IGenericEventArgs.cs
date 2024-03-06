using System;

namespace SerializableEvents.Core
{

    public interface IGenericEventArgs
    {
        object Data { get; }
        DateTime CreatedAt { get; }
    }

    public interface IGenericEventArgs<TType> : IGenericEventArgs
    {
        new TType Data { get; }
    }
}
