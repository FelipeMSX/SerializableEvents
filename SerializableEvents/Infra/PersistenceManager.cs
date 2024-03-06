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
        protected PersistenceManager() { }

        private static PersistenceManager _instance;

        public static PersistenceManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PersistenceManager();
                }
                return _instance;
            }
            set { _instance = value; }
        }

        public void Save(Dictionary<Guid, IEventListener> eventlisteners)
        {
            using (ResXResourceWriter resourceWriter = new ResXResourceWriter(Properties.Resources.FileName))
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

            MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory);
            Dictionary<Guid, IEventListener> eventListeners = new Dictionary<Guid, IEventListener>();

            using (ResXResourceReader rsxr = new ResXResourceReader(Properties.Resources.FileName))
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

        private void ForceCreateFile()
        {
            if (!File.Exists(Properties.Resources.FileName))
            {
                using (ResXResourceWriter resourceWriter = new ResXResourceWriter(Properties.Resources.FileName))
                {
                }
            }
        }
    }
}
