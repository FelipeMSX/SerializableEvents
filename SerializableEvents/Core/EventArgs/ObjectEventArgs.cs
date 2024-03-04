﻿namespace SerializableEvents.Core.EventArgs
{
    public class ObjectEventArgs : GenericEventArgs<object>
    {
        public ObjectEventArgs(object EventData) : base(EventData) { }
    }
}
