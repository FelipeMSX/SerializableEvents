using System.Data;

namespace SerializableEvents.Core.EventArgs
{
    public class DataRowEventArgs : GenericEventArgs<DataRow>
    {
        public DataRowEventArgs(DataRow EventData) : base(EventData) { }
    }
}
