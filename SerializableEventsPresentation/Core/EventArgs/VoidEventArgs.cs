namespace SerializableEvents.Core.EventArgs
{
    public class VoidEventArgs : GenericEventArgs<Void>
    {
        public readonly static VoidEventArgs VoidEmpty = new VoidEventArgs(Void.Empty);

        public VoidEventArgs(Void EventData) : base(EventData) { }
    }
}
