using System;
using System.Windows.Forms;

namespace SerializableEvents.Presentation.ModalSelector
{
    internal interface IEventSelectorView : IView
    {
        string EventName { get; set; }

        void SetSerializableEventBindingSource(BindingSource bindingSource);

        event EventHandler AddNewEvent;
        event EventHandler RemoveEvent;
        event EventHandler SaveEvent;

    }
}
