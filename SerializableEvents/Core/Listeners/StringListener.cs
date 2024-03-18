using SerializableEvents.Core.EventArgs;
using SerializableEvents.Infra;
using System;

namespace SerializableEvents.Core.Listeners
{
    [SerializableEventAttribute("09ac4f98-09ee-42a3-9024-671d292e34f2", typeof(StringListener))]
    public class StringListener : EventListenerBase<string, StringEventArgs>
    {
        public StringListener(Guid guid) : base(guid) { }
    }
}
