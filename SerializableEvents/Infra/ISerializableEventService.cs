﻿using SerializableEvents.Core;
using SerializableEvents.Presentation.Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SerializableEvents.Infra
{
    public interface ISerializableEventService
    {
        IEventListener FindListender(Guid guid);
        void AddEntry(Guid guid, IEventListener listener);
        void RemoveEntry(Guid guid);
        void UpdateEntry(Guid guid, IEventListener listener);
        void Save();
        void LoadData();

        IEnumerable<KeyValuePair<Guid, IEventListener>> FindAll();
        IEnumerable<KeyValuePair<Guid, IEventListener>> FindByType(Type type);
    }
}
