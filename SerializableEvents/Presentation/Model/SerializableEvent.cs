using SerializableEvents.Core;
using SerializableEvents.Infra;
using System;
using System.ComponentModel;

namespace SerializableEvents.Presentation.Model
{
    [Serializable]
    public class SerializableEvent : IObserver
    {
        [DisplayName("ID")]
        [ReadOnly(true)]
        public Guid Guid { get; set; }

        [DisplayName("Nome")]
        [ReadOnly(true)]
        public string Name { get; set; }

        public event Action<IGenericEventArgs> OnEventTriggered;

        [NonSerialized]
        private IEventListener _eventListener;

        [NonSerialized]
        private ISerializableEventService _service;

        //Handle exceptions
        public void Initialize()
        {
            _service = new SerializableEventService();
            _eventListener = _service.FindListender(Guid);
        }

        public void Subscribe()
        {
            _eventListener.Register(this);
        }

        public void Unsubscribe()
        {
            _eventListener.Unregister(this);
        }

        public void OnEventRised(IGenericEventArgs item)
        {
            OnEventTriggered?.Invoke(item);
        }

        public void Raise(object obj)
        {
            _eventListener.Raise(obj);
        }

        public override string ToString()
        {
            return $"{Guid} - {Name}";
        }
    }
}
