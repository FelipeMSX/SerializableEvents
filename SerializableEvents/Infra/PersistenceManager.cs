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
            set { _instance = value; }
        }

        private string _filePath;

        private bool _isLoaded;


        public Dictionary<Guid, IEventListener> EventListeners { get; private set; }

        protected PersistenceManager() { }

        public void Save()
        {
            using (ResXResourceWriter resourceWriter = new ResXResourceWriter(_filePath))
            {
                foreach (var item in EventListeners)
                {
                    resourceWriter.AddResource(item.Key.ToString(), item.Value);
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
                        EventListeners.Add(new Guid(entry.Key.ToString()), (IEventListener)entry.Value);
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
    }
}
