using SerializableEvents.Core;
using System.Collections.Generic;
using System;

namespace SerializableEvents.Infra
{
    public interface IPersistence
    {
        Dictionary<Guid, IEventListener> EventListeners { get; }
        void Save();
        void LoadData();
    }
}
