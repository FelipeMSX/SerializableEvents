﻿using DevComponents.DotNetBar;
using SerializableEvents.Presentation.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsPubSub.ModalSelector
{
    public partial class EventSelectorForm : Office2007Form, IEventSelectorView
    {

        public SerializableEvent SelectedItem
        {
            get => _eventBindingSource.Current as SerializableEvent;
            set
            {
                var item = _eventBindingSource.List.Cast<SerializableEvent>().FirstOrDefault(x => x.Guid == value.Guid);
                if (item != null)
                {
                    _eventBindingSource.Position = _eventBindingSource.IndexOf(item);
                    RefreshLabels(item);
                }
            }
        }

        public string ErrorMessage
        {
            get => warninBox.Text;
            set
            {
                warninBox.Text = value;
                warninBox.Visible = !string.IsNullOrEmpty(value);
            }
        }

        public bool CanSave
        {
            get => btnSave.Enabled;
            set => btnSave.Enabled = value;
        }

        public event EventHandler<NewSerializableEventArgs> AddNewEvent;
        public event EventHandler RemoveEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SelectedItemChangedEvent;

        private BindingSource _eventBindingSource;

        public EventSelectorForm()
        {
            InitializeComponent();
            lblEventId.Text = string.Empty;
            lblEventName.Text = string.Empty;
        }

        public void SetSerializableEventDataSource(BindingList<SerializableEvent> dataSource)
        {
            _eventBindingSource = new BindingSource();
            _eventBindingSource.DataSource = dataSource;
            _eventBindingSource.CurrentItemChanged += (e, s) =>
            {
                RefreshLabels((SerializableEvent)_eventBindingSource.Current);
            };

            cbbEvents.DataSource = _eventBindingSource;
            cbbEvents.SelectedIndex = -1;
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm();

            if (inputForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AddNewEvent?.Invoke(this, new NewSerializableEventArgs(inputForm.ObterNomeDoEvento()));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveEvent?.Invoke(this, EventArgs.Empty);
        }

        private void warninBox_CloseClick(object sender, EventArgs e)
        {
            ErrorMessage = string.Empty;
        }

        public void CloseView(DialogResult dialogResult)
        {
            DialogResult = dialogResult;
        }

        private void cbbEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedItemChangedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void RefreshLabels(SerializableEvent serializableEvent)
        {
            lblEventName.Text = serializableEvent.Name;
            lblEventId.Text = serializableEvent.Guid.ToString();
        }
    }
}
