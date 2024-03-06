﻿using SerializableEvents.Core;
using SerializableEvents.Infra;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace SerializableEvents.Model
{
    [Serializable]
    public class SerializableEvent : IObserver
    {
        [ReadOnly(true)]
        public Guid Guid { get; set; }
        
        [ReadOnly(true)]
        public string Name { get; set; }

        public event Action<IGenericEventArgs> OnEventTriggered;

        private IEventListener _eventListener;

        private ISerializableEventService _service = new SerializableEventService();
        //Handle exceptions
        public void Initialize()
        {
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
            return Name;
        }
    }
}