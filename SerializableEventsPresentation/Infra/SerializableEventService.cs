using SerializableEvents.Core;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SerializableEvents.Infra
{
    public class SerializableEventService : ISerializableEventService
    {
        //Não vou implementar dependency injection nesse projeto, vamos de Singleton mesmo;
        private IPersistence _persistenceService;

        private Dictionary<Guid, IEventListener> _eventListeners;


        public SerializableEventService()
        {
            _persistenceService = PersistenceManager.Instance;
            _eventListeners = _persistenceService.LoadData();
        }

        public IEventListener FindListender(Guid guid)
        {
            return _eventListeners[guid];
        }

        public void AddEntry(Guid guid, IEventListener listener)
        {
            _eventListeners.Add(guid, listener);
        }

        public void RemoveEntry(Guid guid)
        {
            _eventListeners.Remove(guid);
        }

        public void UpdateEntry(Guid guid, IEventListener listener)
        {
            RemoveEntry(guid);
            AddEntry(guid, listener);
        }

        public void Save()
        {
            _persistenceService.Save(_eventListeners);
        }

        public void LoadData()
        {
            _eventListeners = _persistenceService.LoadData();
        }

        public IEnumerable<KeyValuePair<Guid, IEventListener>> GetAll()
        {
            foreach (var listener in _eventListeners)
            {
                yield return listener;
            }
        }
    }
}
