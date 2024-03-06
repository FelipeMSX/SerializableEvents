using SerializableEvents.Core.EventArgs;
using System;
using System.ComponentModel;
using System.Data;

namespace SerializableEvents.Components
{
    [ToolboxItem(true)]
    public partial class DataTableEventListener : EventListenerBase, IEventListenerComponent<DataTable, DataTableEventArgs>
    {
        public event EventHandler<DataTableEventArgs> OnEventTriggered;

        public DataTableEventListener()
        {
            _redirect = (obj) =>
            {
                OnEventTriggered?.Invoke(this, (DataTableEventArgs)obj);
            };

            EventType = typeof(SerializableEvents.Core.Listeners.DataTableListener);
        }


        public void Raise(DataTable obj)
        {
            SerializableEvent.Raise(obj);
        }
    }
}
