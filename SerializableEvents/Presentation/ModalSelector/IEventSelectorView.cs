using System;

namespace SerializableEvents.Presentation.Model
{
    internal interface IEventSelectorView : IView
    {
        string EventName { get; set; }

        EventEntry SelectedEventyEntry { get; }

        void SetSerializableEventDataSource(object bindingSource);
        void SetSelectedEventyEntryByIndex(int index);


        event EventHandler AddNewEvent;
        event EventHandler RemoveEvent;
        event EventHandler SaveEvent;

    }
}
