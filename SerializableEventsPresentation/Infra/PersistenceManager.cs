using SerializableEvents.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Windows.Forms;

namespace SerializableEvents.Infra
{
    public class PersistenceManager
    {
        private const string RESOURCE_PATH = "C:\\Users\\felip\\source\\repos\\SerializableEvents\\SerializableEvents\\Properties\\SerializableEventResources.resx";

        protected PersistenceManager() { }

        private static PersistenceManager _instance;

        private static Dictionary<Guid, IEventListener> _eventListeners;

        public static PersistenceManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PersistenceManager();

                    ResXResourceReader rsxr = new ResXResourceReader(RESOURCE_PATH);
                    _eventListeners = new Dictionary<Guid, IEventListener>();
                    //Find all persisteds events
                    foreach (DictionaryEntry entry in rsxr)
                    {
                        try
                        {
                            _eventListeners.Add(new Guid(entry.Key.ToString()), (IEventListener)entry.Value);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            break;
                        }
                    }
                }
                return _instance;
            }
            set { _instance = value; }
        }

        public IEventListener FindListender(Guid guid)
        {
            return _eventListeners[guid];
        }
    }
}
