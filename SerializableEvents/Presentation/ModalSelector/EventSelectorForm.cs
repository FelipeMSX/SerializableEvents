using DevComponents.DotNetBar;
using SerializableEvents.Components;
using SerializableEvents.Core;
using SerializableEvents.Presentation.Model;
using System;
using System.Windows.Forms;
using System.Linq;
namespace WindowsFormsPubSub.ModalSelector
{
    public partial class EventSelectorForm : DevComponents.DotNetBar.Office2007Form, IEventSelectorView
    {

        public string EventName { get => lblEventNameType.Text; set => lblEventNameType.Text = value; }
        public EventEntry SelectedEventyEntry
        {
            get => (EventEntry)eventEntryBindingSource.Current;
        }

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

            //itemPanelEvents.DataBindings.Add("Name",)
        }

        private void AssociateAndRaiseViewEvents()
        {
            //btnCreateNew.Click += (e, s) => { AddNewEvent?.Invoke(this, EventArgs.Empty); };
            //btnSave.Click += (e, s) => { SaveEvent?.Invoke(this, EventArgs.Empty); };

        }

        public void SetSerializableEventDataSource(object dataSource)
        {
            //DataTable DTable = new DataTable();
            //DTable.Columns.Add("Guid", typeof(Guid));
            //DTable.Columns.Add("Name", typeof(string));
            eventEntryBindingSource.DataSource = dataSource;
            eventEntryBindingSource.ResetBindings(false);
            var test = eventEntryBindingSource.DataSource;
            //var Entry1 = new EventEntry(Guid.NewGuid(), "AAAAAAAAAAAAAAAAA");
            //var Entry2 = new EventEntry(Guid.NewGuid(), "BBBBBBBBBBBBBBBBB");
            //var Entry3 = new EventEntry(Guid.NewGuid(), "CCCCCCCCCCCCCCCCC");

            //DTable.Rows.Add(new object[] { Guid.NewGuid(), "CCCCCCCCCCCCCCCCC" });
            //DTable.Rows.Add(new object[] { Guid.NewGuid(), "AAAAAAAAAAAAAAAAA" });
            //DTable.Rows.Add(new object[] { Guid.NewGuid(), "BBBBBBBBBBBBBBBBB" });


            //eventEntryBindingSource.Add(new EventEntry(Guid.NewGuid(), "AAAAAAAAAAAAAAAAA"));
            //eventEntryBindingSource.Add(new EventEntry(Guid.NewGuid(), "BBBBBBBBBBBBBBBBB"));
            //eventEntryBindingSource.Add(new EventEntry(Guid.NewGuid(), "CCCCCCCCCCCCCCCCC"));

            //itemPanelEvents.DataSource = bindingSource;
            //dataGridViewX1.DataSource = bindingSource;
            //comboBox1.DataSource =bindingSource;
            //comboBoxEx1.DataSource = bindingSource;
            //comboBoxEx1.DisplayMember = "Name";
            //comboBox1.DisplayMember = "Name";


            //comboBoxEx1.DataBindings.Add("DisplayMember", bindingSource.DataSource, "Name");
            //comboBoxEx1.DataBindings.ad
            //bindingSource.CurrentChanged += (s, e) =>
            //{
            //    //MessageBox.Show("CurrentChanged Aqui");
            //};

            //bindingSource.CurrentItemChanged += (s, e) =>
            //{
            //    //MessageBox.Show("CurrentItemChanged Aqui");
            //};
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

        //private void CreateEventEntry(IEventListener eventType)
        //{
        //    ButtonItem buttonItem = new ButtonItem();
        //    buttonItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
        //    buttonItem.FixedSize = new System.Drawing.Size(300, 82);
        //    buttonItem.Image = global::SerializableEvents.Properties.Resources.EventIcon_64;
        //    buttonItem.ImageFixedSize = new System.Drawing.Size(48, 48);
        //    buttonItem.Name = eventType.Guid.ToString();
        //    buttonItem.Text = $"<br />{eventType.Guid}<p><font color=\"#84A2C6\" size=\"8\">{eventType.Name}</font></p>";
        //    buttonItem.Command = commandSelectedItem;
        //    buttonItem.CommandParameter = eventType;
        //    itemPanelEvents.Items.Add(buttonItem);
        //    itemPanelEvents.Refresh();
        //}

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
            AddNewEvent?.Invoke(this, EventArgs.Empty);

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
            SaveEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {

        }

        private void itemPanelEvents_BindingContextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("hahaha");
        }

        private void itemPanelEvents_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void itemPanelEvents_DataSourceChanged(object sender, EventArgs e)
        {
        }

        private void itemPanelEvents_ItemAdded(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            var test = (BindingSource)itemPanelEvents.DataSource;

            MessageBox.Show(((EventEntry)test.Current).Name);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            var test = (BindingSource)itemPanelEvents.DataSource;
            test.ResetCurrentItem();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void SetSelectedEventyEntryByIndex(int index)
        {
            eventEntryBindingSource.Position = index;
        }
    }
}
