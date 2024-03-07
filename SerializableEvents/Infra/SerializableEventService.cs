using SerializableEvents.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SerializableEvents.Infra
{
    public class SerializableEventService : ISerializableEventService
    {
        //Não vou implementar dependency injection nesse projeto, vamos de Singleton mesmo;
        private IPersistence _persistenceService;

        public SerializableEventService()
        {
            _persistenceService = PersistenceManager.Instance;
        }

        public IEventListener FindListender(Guid guid)
        {
            return _persistenceService.EventListeners[guid];
        }

        public void AddEntry(Guid guid, IEventListener listener)
        {
            _persistenceService.EventListeners.Add(guid, listener);
        }

        public void RemoveEntry(Guid guid)
        {
            _persistenceService.EventListeners.Remove(guid);
        }

        public void UpdateEntry(Guid guid, IEventListener listener)
        {
            RemoveEntry(guid);
            AddEntry(guid, listener);
        }

        public void Save()
        {
            _persistenceService.Save();
        }

        public void LoadData()
        {
            _persistenceService.LoadData();
        }

        public IEnumerable<KeyValuePair<Guid, IEventListener>> FindAll()
        {
            foreach (var listener in _persistenceService.EventListeners)
            {
                yield return listener;
            }
        }

        public IEnumerable<KeyValuePair<Guid, IEventListener>> FindByType(Type type)
        {

            IEnumerable<KeyValuePair<Guid, IEventListener>> typeList = _persistenceService.EventListeners.Where(x => x.Value.GetType() == type);
            foreach (var listener in typeList)
            {
                yield return listener;
            }
        }
    }
}
