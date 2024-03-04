using System ;

namespace SerializableEventsCore.EventArgs
{
    public abstract class GenericEventArgs<T> : System.EventArgs, IGenericEventArgs<T>
    {
        public T Data { get; private set; }
        object IGenericEventArgs.Data => Data;

        public DateTime CreatedAt { get; } 

        public GenericEventArgs(T eventData)
        {
            CreatedAt = DateTime.Now;
            Data = eventData;
        }
    }
}
