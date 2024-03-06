using SerializableEvents.Core;
using System.Collections.Generic;
using System;

namespace SerializableEvents.Infra
{
    public interface IPersistence
    {
        void Save(Dictionary<Guid, IEventListener> eventlisteners);
        Dictionary<Guid, IEventListener> LoadData();
    }
}
