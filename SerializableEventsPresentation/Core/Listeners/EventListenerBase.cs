using System;
using System.Collections.Generic;

namespace SerializableEvents.Core.Listeners
{
    [Serializable]
    public abstract class EventListenerBase<TType, TArgs> :
        IEventListener<TArgs> where TArgs : IGenericEventArgs<TType>
    {
        public Guid Guid { get; } = Guid.NewGuid();

        public string Name { get; set; }

        [NonSerialized]
        private List<IObserver> _listeners;

        public void Raise(TType item)
        {
            ((IEventListener)this).Raise(item);
        }

        public void Register(IObserver<TArgs> listener)
        {
            ((IEventListener)this).Register(listener);
        }

        public void Unregister(IObserver<TArgs> listener)
        {
            ((IEventListener)this).Unregister(listener);
        }

        void IEventListener.Raise(object item)
        {
            CheckBeforeUsage();

            IGenericEventArgs<TType> args = (TArgs)Activator.CreateInstance(typeof(TArgs), item);

            for (int i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].OnEventRised(args);
        }

        void IEventListener.Register(IObserver listener)
        {
            CheckBeforeUsage();

            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        void IEventListener.Unregister(IObserver listener)
        {
            CheckBeforeUsage();

            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }

        private void CheckBeforeUsage()
        {
            if (_listeners != null)
                return;

            _listeners = new List<IObserver>();
        }
    }
}
