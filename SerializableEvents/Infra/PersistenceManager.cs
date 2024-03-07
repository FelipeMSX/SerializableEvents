using SerializableEvents.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
                }
                return _instance;
            }
            set { _instance = value; }
        }

        private string _filePath;

        protected PersistenceManager() { }

        public void Save(Dictionary<Guid, IEventListener> eventlisteners)
        {
            using (ResXResourceWriter resourceWriter = new ResXResourceWriter(_filePath))
            {
                foreach (var item in eventlisteners)
                {
                    resourceWriter.AddResource(item.Key.ToString(), item.Value);
                }
                resourceWriter.Generate();
            }
        }

        public Dictionary<Guid, IEventListener> LoadData()
        {
            ForceCreateFile();

            Dictionary<Guid, IEventListener> eventListeners = new Dictionary<Guid, IEventListener>();

            using (ResXResourceReader rsxr = new ResXResourceReader(_filePath))
            {
                eventListeners = new Dictionary<Guid, IEventListener>();
                //Find all serialized events
                foreach (DictionaryEntry entry in rsxr)
                {
                    try
                    {
                        eventListeners.Add(new Guid(entry.Key.ToString()), (IEventListener)entry.Value);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        break;
                    }
                }
            }
            return eventListeners;
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
    }
}
