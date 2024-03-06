using SerializableEvents.Core.EventArgs;
using System;
using System.Data;

namespace SerializableEvents.Core.Listeners
{
    [Serializable]
    public class DataRowListener : EventListenerBase<DataRow, DataRowEventArgs> { }
}
