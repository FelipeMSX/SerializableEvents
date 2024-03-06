using SerializableEvents.Components;
using SerializableEvents.Core;
using SerializableEvents.Core.Listeners;
using SerializableEvents.Infra;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SerializableEvents.Presentation.ModalSelector
{
    internal class EventSelectorPresenter : Presenter<IEventSelectorView>
    {
        private ISerializableEventService _serializableEventService;

        private IList<EventEntry> _listeners = new List<EventEntry>();

        private BindingSource _listenersBindingSource;

        private EventListenerBase _eventListenerBase;

        public EventSelectorPresenter(IEventSelectorView view, EventListenerBase eventListenerBase) : base(view)
        {
            _serializableEventService = new SerializableEventService();
            _eventListenerBase = eventListenerBase;

            view.EventName = _eventListenerBase.EventType.Name;
            view.AddNewEvent += View_AddNewEvent;
            Initialize();

        }

        private void View_AddNewEvent(object sender, System.EventArgs e)
        {
            InputForm inputForm = new InputForm();

            if(inputForm.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                EventEntry entry = new EventEntry(Guid.NewGuid(), inputForm.ObterNomeDoEvento());
                _listenersBindingSource.Add(entry);
            }
        }

        private void Initialize()
        {
            foreach (var item in _serializableEventService.GetAll())
            {
                EventEntry entry = new EventEntry(item.Value.Guid, item.Value.Name);
                _listeners.Add(entry);
            }

            _listenersBindingSource = new BindingSource();
            _listenersBindingSource.DataSource = _listeners;

            View.SetSerializableEventBindingSource(_listenersBindingSource);
        }
    }
}
