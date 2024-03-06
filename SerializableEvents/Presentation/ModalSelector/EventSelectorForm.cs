using DevComponents.DotNetBar;
using SerializableEvents.Components;
using SerializableEvents.Core;
using SerializableEvents.Core.Listeners;
using SerializableEvents.Presentation.ModalSelector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace WindowsFormsPubSub.ModalSelector
{
    public partial class EventSelectorForm : DevComponents.DotNetBar.Office2007Form, IEventSelectorView
    {

        public string EventName { get => lblEventNameType.Text; set => lblEventNameType.Text = value; }


        private IEventListener _selectedEventListener;

        private EventSelectorPresenter _presenter;


        public event EventHandler AddNewEvent;
        public event EventHandler RemoveEvent;
        public event EventHandler SaveEvent;

        public EventSelectorForm(EventListenerBase eventListenerBase)
        {
            InitializeComponent();

            _presenter = new EventSelectorPresenter(this, eventListenerBase);


            //panelHeader.Text = _eventListenerBase.EventType.Name;
            //LoadData();
            ////FindSelectedItem;
            ////Shows something if the selected event has been delete

            //if (_eventListenerBase.SerializableEvent != null)
            //{

            //    //_selectedEventListener = selectedListener;
            //}
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnCreateNew.Click += (e, s) => { AddNewEvent?.Invoke(this, EventArgs.Empty); };
            btnSave.Click += (e, s) => { SaveEvent?.Invoke(this, EventArgs.Empty); };

        }

        public void SetSerializableEventBindingSource(BindingSource bindingSource)
        {
            itemPanelEvents.DataSource = bindingSource;
            dataGridViewX1.DataSource = bindingSource;
        }

        private void LoadData()
        {

        }

        //<br />43cefaf1-3378-488f-8976-0742556b018f<p><font color = "#84A2C6" size="8">Configurar envio de alerta(s) por e-mail</font></p>


        private void CreateEvent(Type type)
        {
            //IEventListener eventType = (IEventListener)Activator.CreateInstance(type);

            //eventType.Name = DateTime.Now.ToString();
            ////MessageBox.Show("Evento criado com sucesso" + eventType.Guid);

            //_events.Add(eventType.Guid.ToString(), eventType);
            //CreateEventEntry(eventType);
        }

        private void CreateEventEntry(IEventListener eventType)
        {
            ButtonItem buttonItem = new ButtonItem();
            buttonItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            buttonItem.FixedSize = new System.Drawing.Size(300, 82);
            buttonItem.Image = global::SerializableEvents.Properties.Resources.EventIcon_64;
            buttonItem.ImageFixedSize = new System.Drawing.Size(48, 48);
            buttonItem.Name = eventType.Guid.ToString();
            buttonItem.Text = $"<br />{eventType.Guid}<p><font color=\"#84A2C6\" size=\"8\">{eventType.Name}</font></p>";
            buttonItem.Command = commandSelectedItem;
            buttonItem.CommandParameter = eventType;
            itemPanelEvents.Items.Add(buttonItem);
            itemPanelEvents.Refresh();
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="resxFileName">Indicates the complete resource file name including its path</param>
        ///// <param name="oString">The string parmaeter introduced by the developer or the user </param>
        ///// <param name="imagePath">Indicates the complete image file including its path</param>
        //public void Create(string resFileName, string oString)
        //{
        //    try
        //    {
        //        //ResXResourceReader
        //        //Image oImage = Image.FromFile(imagePath);
        //        ResXResourceWriter resourceWriter = new ResXResourceWriter(resFileName);
        //        resourceWriter.AddResource("myString22", oString);
        //        resourceWriter.Generate();
        //        resourceWriter.Close();
        //        MessageBox.Show("Entry has been created");
        //    }
        //    //if the file path is wrong or dosn't found
        //    catch (FileNotFoundException caught)
        //    {
        //        MessageBox.Show("Source: " + caught.Source + " Message: " + caught.Message);
        //    }
        //}



        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            //CreateEvent(_eventListenerBase.EventType);

        }

        private void commandSelectedItem_Executed(object sender, EventArgs e)
        {
            _selectedEventListener = null;
            ICommandSource command = (ICommandSource)sender;
            IEventListener selectedListener = (IEventListener)command.CommandParameter;

            foreach (ButtonItem item in itemPanelEvents.Items)
            {
                if ((item).Name == selectedListener.Guid.ToString())
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }

            }

            _selectedEventListener = selectedListener;

        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        public IEventListener ObterEventListener()
        {
            return _selectedEventListener;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedEventListener == null)
            {
                MessageBox.Show("É obrigatório escolher um item para poder salvar", "Definir item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {

        }


    }
}
