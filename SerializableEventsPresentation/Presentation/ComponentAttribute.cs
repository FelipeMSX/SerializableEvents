namespace SerializableEventsPresentation
{
    [System.AttributeUsage(System.AttributeTargets.Class)
    ]
    public class EventComponentAttribute : System.Attribute
    {
        private string Name;

        public EventComponentAttribute(string name)
        {
            Name = name;
        }
    }
}
