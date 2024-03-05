using SerializableEvents.Core.EventArgs;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace SerializableEvents.Components
{
    //[ToolboxBitmap(typeof(Resources), "EventSystemIcon_16.ico")]
    //[ToolboxBitmap(nameof(Resources.EventSystemIcon_16))]
    [ToolboxBitmapAttribute(typeof(DataRowEventListener), "EventSystemIcon_16")]
    [ToolboxItem(true)]
    public partial class DataRowEventListener : EventListenerBase, IEventListenerComponent<DataRow, DataRowEventArgs>
    {
        public event EventHandler<DataRowEventArgs> OnEventTriggered;

        public DataRowEventListener()
        {
            _redirect = (obj) =>
            {
                OnEventTriggered?.Invoke(this, (DataRowEventArgs)obj);
            };

            EventType = typeof(SerializableEvents.Core.Listeners.DataRowListener);
        }


        public void Raise(DataRow obj)
        {
            SerializableEvent.Raise(obj);
        }
    }
}
