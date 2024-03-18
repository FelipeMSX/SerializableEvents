using Newtonsoft.Json;
using SerializableEvents.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace SerializableEvents.Infra
{
    public class PersistenceManager : IPersistence
    {
        private static PersistenceManager _instance;

        public static PersistenceManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PersistenceManager();
                    _instance.BuildPath();
                    _instance.LoadData();
                }
                return _instance;
            }
        }

        private string _filePath;

        private bool _isLoaded;

        public Dictionary<Guid, IEventListener> EventListeners { get; private set; }


        //Não vou usar injeção de dependência
        private SerializableEventsCacheService _cacheService;

        protected PersistenceManager()
        {
            _cacheService = SerializableEventsCacheService.Instance;
        }

        public void Save()
        {
            using (ResXResourceWriter resourceWriter = new ResXResourceWriter(_filePath))
            {
                foreach (var item in EventListeners)
                {
                    var itemToSave = new SaveEventData()
                    {
                        Id = item.Value.Guid,
                        Name = item.Value.Name,
                        ListenerTypeName = item.Value.GetType().ToString(),
                    };

                    string serializedValue = JsonConvert.SerializeObject(itemToSave, Formatting.Indented);
                    resourceWriter.AddResource(item.Key.ToString(), serializedValue);
                }
                resourceWriter.Generate();
            }
        }

        public void LoadData()
        {
            if (_isLoaded)
            {
                return;
            }
            ForceCreateFile();

            EventListeners = new Dictionary<Guid, IEventListener>();

            using (ResXResourceReader rsxr = new ResXResourceReader(_filePath))
            {
                EventListeners = new Dictionary<Guid, IEventListener>();
                //Find all serialized events
                foreach (DictionaryEntry entry in rsxr)
                {
                    try
                    {
                        SaveEventData serializedValue = JsonConvert.DeserializeObject<SaveEventData>(entry.Value.ToString());
                        SerializableEventCacheEntry cacheEntry = _cacheService.Find(serializedValue.ListenerTypeName);
                        //IGenericEventArgs<TType> args = (TArgs)Activator.CreateInstance(typeof(TArgs), item);

                        IEventListener listener = (IEventListener)Activator.CreateInstance(cacheEntry.EventType, serializedValue.Id);
                        listener.Name = serializedValue.Name;
                        //ObjectListener objectListener = new ObjectListener(serializedValue.Id) { Name = serializedValue.Name };
                        EventListeners.Add(new Guid(entry.Key.ToString()), listener);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        break;
                    }
                }
            }
            _isLoaded = true;
        }


        private void BuildPath()
        {
            _filePath = Properties.Resources.FileName;
        }

        private void ForceCreateFile()
        {
            if (!File.Exists(_filePath))
            {
                using (ResXResourceWriter resourceWriter = new ResXResourceWriter(_filePath))
                {
                }
            }
        }

        [Serializable]
        public class SaveEventData
        {
            public Guid Id { get; set; }
            public string ListenerTypeName { get; set; }
            public string Name { get; set; }
        }
    }
}
