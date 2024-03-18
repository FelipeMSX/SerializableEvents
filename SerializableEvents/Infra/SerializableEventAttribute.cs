using System;

namespace SerializableEvents.Infra
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SerializableEventAttribute : Attribute
    {
        public string Guid { get; }
        public Type EventType { get; }

        public SerializableEventAttribute(string guid, Type eventType)
        {
            Guid = guid;
            EventType = eventType;
        }
    }
}
