using SerializableEvents.Components;
using SerializableEvents.Core;
using SerializableEvents.Infra;
using System;
using System.ComponentModel;
using System.Linq;

namespace SerializableEvents.Presentation.Model
{
    internal class EventSelectorPresenter : Presenter<IEventSelectorView>
    {
        private ISerializableEventService _serializableEventService;

        private BindingList<EventEntry> _listeners = new BindingList<EventEntry>();

        private EventListenerBase _eventListenerBase;


        public EventSelectorPresenter(IEventSelectorView view, EventListenerBase eventListenerBase) : base(view)
        {
            _serializableEventService = new SerializableEventService();
            _eventListenerBase = eventListenerBase;

            view.EventName = _eventListenerBase.EventType.Name;
            view.AddNewEvent += OnAddNewEvent;
            view.SaveEvent += OnSaveEvent;

            Initialize();
        }

        private void OnSaveEvent(object sender, EventArgs e)
        {
            _serializableEventService.Save();
        }

        private void OnAddNewEvent(object sender, System.EventArgs e)
        {
            InputForm inputForm = new InputForm();

            if (inputForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IEventListener genericListener = (IEventListener)Activator.CreateInstance(_eventListenerBase.EventType);
                genericListener.Name = inputForm.ObterNomeDoEvento();
                _serializableEventService.AddEntry(genericListener.Guid, genericListener);

                EventEntry entry = new EventEntry(genericListener.Guid, genericListener.Name);
                _listeners.Add(entry);
          
            }
        }

        private void Initialize()
        {
            foreach (var item in _serializableEventService.FindByType(_eventListenerBase.EventType))
            {
                EventEntry entry = new EventEntry(item.Value.Guid, item.Value.Name);
                _listeners.Add(entry);
            }

            View.SetSerializableEventDataSource(_listeners);

            if (_eventListenerBase.SerializableEvent != null)
            {
                EventEntry entry = new EventEntry(_eventListenerBase.SerializableEvent.Guid, _eventListenerBase.SerializableEvent.Name);
                //Notificar event aqui
                EventEntry entryMatch = _listeners.FirstOrDefault(x => x.Guid == entry.Guid);
                View.SetSelectedEventyEntryByIndex(_listeners.IndexOf(entryMatch));
            }

        }
    }
}
