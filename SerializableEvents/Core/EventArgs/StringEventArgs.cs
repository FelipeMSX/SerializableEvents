namespace SerializableEvents.Core.EventArgs
{
    public class StringEventArgs : GenericEventArgs<string>
    {
        public StringEventArgs(string EventData) : base(EventData) { }
    }
}
