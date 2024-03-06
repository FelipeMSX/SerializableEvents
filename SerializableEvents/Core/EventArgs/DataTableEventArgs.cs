using System.Data;

namespace SerializableEvents.Core.EventArgs
{
    public class DataTableEventArgs : GenericEventArgs<DataTable>
    {
        public DataTableEventArgs(DataTable EventData) : base(EventData) { }
    }
}
