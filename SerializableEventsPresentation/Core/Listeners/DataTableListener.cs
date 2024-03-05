using SerializableEvents.Core.EventArgs;
using System;
using System.Data;

namespace SerializableEvents.Core.Listeners
{
    [Serializable]
    public class DataTableListener : EventListenerBase<DataTable, DataTableEventArgs> { }
}
