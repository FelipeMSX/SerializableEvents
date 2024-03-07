using System;
using System.ComponentModel;

namespace SerializableEvents.Presentation.Model
{
    public readonly struct EventEntry
    {
        [DisplayName("ID")]
        public Guid Guid { get; }

        [DisplayName("Nome")]
        public string Name { get; }

        public EventEntry(Guid guid, string name)
        {
            Guid = guid;
            Name = name;
        }
    }
}
