using SerializableEvents.Core.EventArgs;
using SerializableEvents.Infra;
using System;
using System.Data;

namespace SerializableEvents.Core.Listeners
{
    [SerializableEventAttribute("6f00972e-aab5-48de-a7c2-285ae4c6e833", typeof(DataTableListener))]
    public class DataTableListener : EventListenerBase<DataTable, DataTableEventArgs>
    {
        public DataTableListener(Guid guid) : base(guid) { }
    }
}
