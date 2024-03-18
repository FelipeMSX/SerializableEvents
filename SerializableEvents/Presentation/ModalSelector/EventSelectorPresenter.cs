using SerializableEvents.Components;
using SerializableEvents.Core;
using SerializableEvents.Infra;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SerializableEvents.Presentation.Model
{
    internal class EventSelectorPresenter : Presenter<IEventSelectorView>
    {
        private readonly ISerializableEventService _serializableEventService;

        private readonly BindingList<SerializableEvent> _listeners = new BindingList<SerializableEvent>();

        private readonly Type _eventType;

        private readonly SerializableEvent _serializableEvent;

        public EventSelectorPresenter(IEventSelectorView view, Type eventType, SerializableEvent serializableEvent) : base(view)
        {
            _serializableEventService = new SerializableEventService();
            _serializableEvent = serializableEvent;
            _eventType = eventType;
            View.CanSave = false;

            Initialize();

            view.AddNewEvent += OnAddNewEvent;
            view.SaveEvent += OnSaveEvent;
            view.RemoveEvent += OnRemoveEvent;
            view.SelectedItemChangedEvent += OnSelectedItemChangedEvent;
            view.ErrorMessage = string.Empty;
        }

        private void OnSelectedItemChangedEvent(object sender, EventArgs e)
        {
            View.CanSave = View.SelectedItem != null;
        }

        private void OnRemoveEvent(object sender, EventArgs e)
        {
            if (View.SelectedItem == null)
            {
                View.ErrorMessage = "Defina um item antes de selecionar essa ação";
                return;
            }

            DialogResult result = MessageBox.Show($"Deseja realmente remover o evento{View.SelectedItem.Name}", "Confirmar exclusão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            var itemParaRemover = View.SelectedItem;
            if (result == DialogResult.OK)
            {
                _listeners.Remove(itemParaRemover);
                _serializableEventService.RemoveEntry(itemParaRemover.Guid);
            }

            View.CanSave = false;
        }

        private void OnSaveEvent(object sender, EventArgs e)
        {
            if (View.SelectedItem == null)
            {
                View.ErrorMessage = "Só é possível salvar com um item selecionado";
                return;
            }

            _serializableEventService.Save();
            View.CloseView(DialogResult.OK);
        }

        private void OnAddNewEvent(object sender, NewSerializableEventArgs e)
        {
            IEventListener genericListener = (IEventListener)Activator.CreateInstance(_eventType, Guid.NewGuid());
            genericListener.Name = e.NewEventName;
            _serializableEventService.AddEntry(genericListener.Guid, genericListener);
            SerializableEvent serialzalbeEvent = CreteSerializableEventFromListener(genericListener.Guid, genericListener.Name);
            _listeners.Add(serialzalbeEvent);
            SetSelectedEvent(serialzalbeEvent);
        }

        private void Initialize()
        {
            foreach (var item in _serializableEventService.FindByType(_eventType))
            {
                _listeners.Add(CreteSerializableEventFromListener(item.Value.Guid, item.Value.Name));
            }

            View.SetSerializableEventDataSource(_listeners);
            //Abrindo com dados
            if (_serializableEvent != null)
            {
                SerializableEvent eventEntry = CreteSerializableEventFromListener(_serializableEvent.Guid, _serializableEvent.Name);
                //Notificar event aqui
                SetSelectedEvent(eventEntry);
            }
        }

        private void SetSelectedEvent(SerializableEvent serializableEvent)
        {
            SerializableEvent entryMatch = _listeners.FirstOrDefault(x => x.Guid == serializableEvent.Guid);
            View.SelectedItem = entryMatch;
            View.CanSave = true;
        }

        private SerializableEvent CreteSerializableEventFromListener(Guid guid, string name)
        {
            return new SerializableEvent()
            {
                Guid = guid,
                Name = name,
            };
        }
    }
}
