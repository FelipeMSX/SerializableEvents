using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace SerializableEvents.Infra
{
    public class SerializableEventsCacheService
    {

        private static SerializableEventsCacheService _instance;

        public static SerializableEventsCacheService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SerializableEventsCacheService();
                }
                return _instance;
            }
        }

        private Dictionary<string, SerializableEventCacheEntry> _cachedInstances;

        protected SerializableEventsCacheService()
        {
            _cachedInstances = new Dictionary<string, SerializableEventCacheEntry>();

            foreach (Type eventType in GetTypesWithHelpAttribute())
            {
                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(eventType);

                foreach (var attribute in attrs)
                {
                    if (attribute is SerializableEventAttribute serializableAttribute)
                    {
                        SerializableEventCacheEntry cacheEntry = 
                            new SerializableEventCacheEntry(new Guid(serializableAttribute.Guid), serializableAttribute.EventType);
                        _cachedInstances.Add(serializableAttribute.EventType.ToString(), cacheEntry);
                    }
                }
            }

            MessageBox.Show($"Cached Entries: {_cachedInstances.Count}");
        }

        public SerializableEventCacheEntry Find(string eventTypeName)
        {
            return _cachedInstances[eventTypeName.ToString()];
        }

        private IEnumerable<Type> GetTypesWithHelpAttribute()
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.GetCustomAttributes(typeof(SerializableEventAttribute), true).Length > 0)
                {
                    yield return type;
                }
            }
        }

    }
    public readonly struct SerializableEventCacheEntry
    {
        public Type EventType { get; }
        public Guid Guid { get; }

        public SerializableEventCacheEntry(Guid guid, Type eventType)
        {
            Guid = guid;
            EventType = eventType;
        }
    }
}
