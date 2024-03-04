namespace SerializableEvents.Core
{
    public interface IObserver
    {
        void OnEventRised(IGenericEventArgs item);
    }

    public interface IObserver<in T> : IObserver where T : IGenericEventArgs
    {
        void OnEventRised(T item);
    }
}
