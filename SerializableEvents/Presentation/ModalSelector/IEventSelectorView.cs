using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SerializableEvents.Presentation.Model
{
    internal interface IEventSelectorView : IView
    {
        string ErrorMessage { get; set; }

        bool CanSave { get; set; }

        SerializableEvent SelectedItem { get; set; }

        void SetSerializableEventDataSource(BindingList<SerializableEvent> bindingSource);

        event EventHandler<NewSerializableEventArgs> AddNewEvent;
        event EventHandler RemoveEvent;
        event EventHandler SaveEvent;
        event EventHandler SelectedItemChangedEvent;

        void CloseView(DialogResult dialogResult);
    }

    public class NewSerializableEventArgs : EventArgs
    {
        public string NewEventName { get; }

        public NewSerializableEventArgs(string newEventName)
        {
            NewEventName = newEventName;
        }
    }
}
