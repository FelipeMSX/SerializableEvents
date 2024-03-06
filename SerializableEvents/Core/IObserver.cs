namespace SerializableEvents.Core
{
    public interface IObserver
    {
        void OnEventRised(IGenericEventArgs item);
    }

    public interface IObserver<in TArgs> : IObserver where TArgs : IGenericEventArgs
    {
        void OnEventRised(TArgs item);
    }
}
