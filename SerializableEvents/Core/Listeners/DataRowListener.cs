using SerializableEvents.Core.EventArgs;
using SerializableEvents.Infra;
using System;
using System.Data;

namespace SerializableEvents.Core.Listeners
{
    [SerializableEventAttribute("12eb7890-352c-40f5-bd2d-e82727e84573", typeof(DataRowListener))]
    public class DataRowListener : EventListenerBase<DataRow, DataRowEventArgs> 
    {
        public DataRowListener(Guid guid) : base(guid) { }
    }
}
