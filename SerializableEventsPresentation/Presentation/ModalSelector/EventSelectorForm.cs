using DevComponents.DotNetBar;
using SerializableEvents.Components;
using SerializableEvents.Core;
using SerializableEvents.Core.Listeners;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace WindowsFormsPubSub.ModalSelector
{
    public partial class EventSelectorForm : DevComponents.DotNetBar.Office2007Form
    {

        private const string RESOURCE_PATH = "C:\\Users\\felip\\source\\repos\\SerializableEvents\\SerializableEvents\\Properties\\SerializableEventResources.resx";

        private Dictionary<string, IEventListener> _events = new Dictionary<string, IEventListener>();

        private EventListenerBase _eventListenerBase;


        private IEventListener _selectedEventListener;
        public EventSelectorForm(EventListenerBase eventListenerBase)
        {
            _eventListenerBase = eventListenerBase;
            InitializeComponent();


            panelHeader.Text = _eventListenerBase.EventType.Name;
            LoadData();
            //FindSelectedItem;
            //Shows something if the selected event has been delete

            if (_eventListenerBase.SerializableEvent != null)
            {
   
                //_selectedEventListener = selectedListener;
            }
        }

        private void LoadData()
        {
 
        }

        //<br />43cefaf1-3378-488f-8976-0742556b018f<p><font color = "#84A2C6" size="8">Configurar envio de alerta(s) por e-mail</font></p>


        private IEventListener CreateEvent(Type type)
        {
            IEventListener eventType = (IEventListener)Activator.CreateInstance(type);

            eventType.Name = DateTime.Now.ToString();
            //MessageBox.Show("Evento criado com sucesso" + eventType.Guid);

            _events.Add(eventType.Guid.ToString(), eventType);
            CreateEventEntry(eventType);

            return eventType;
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="resxFileName">Indicates the complete resource file name including its path</param>
        /// <param name="oString">The string parmaeter introduced by the developer or the user </param>
        /// <param name="imagePath">Indicates the complete image file including its path</param>
        public void Create(string resFileName, string oString)
        {
            try
            {
                //ResXResourceReader
                //Image oImage = Image.FromFile(imagePath);
                ResXResourceWriter resourceWriter = new ResXResourceWriter(resFileName);
                resourceWriter.AddResource("myString22", oString);
                resourceWriter.Generate();
                resourceWriter.Close();
                MessageBox.Show("Entry has been created");
            }
            //if the file path is wrong or dosn't found
            catch (FileNotFoundException caught)
            {
                MessageBox.Show("Source: " + caught.Source + " Message: " + caught.Message);
            }
        }


        public void ListResources()
        {
            ResXResourceReader rsxr = new ResXResourceReader(RESOURCE_PATH);

            // Iterate through the resources and display the contents to the console.
            foreach (DictionaryEntry entry in rsxr)
            {
                try
                {
                    _events.Add(entry.Key.ToString(), (IEventListener)entry.Value);

                }
                catch (Exception)
                {
                }
                //if(d.Value != null)
                //{
                //    MessageBox.Show("Type Check" + (d.Value)?.GetType()?.ToString());
                //}
                //Console.WriteLine(d.Key.ToString() + ":\t" );

            }

            foreach (var item in _events)
            {
                //if(item.Value as EventListenerBase<object>)
                //{

                //}
                try
                {
                    var itemConverted = (IEventListener)item.Value;

                    //_itens.Add(new DislayEvent(itemConverted.Name, itemConverted.Guid));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    break;
                }
            }
            //dataGridViewX1.DataSource = _itens;

        }

        public readonly struct DislayEvent
        {
            public string Name { get; }
            public Guid Guid { get; }

            public DislayEvent(string name, Guid guid)
            {
                Name = name;
                Guid = guid;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                //ResXResourceReader
                //Image oImage = Image.FromFile(imagePath);
                //ResXResourceWriter resourceWriter = new ResXResourceWriter(RESOURCE_PATH);
                //StringEventListener stringEventListener = new StringEventListener();
                //Car c = new Car("Hyundai", "HB20",2017);

                //// Insert code to set properties and fields of the object.  
                //XmlSerializer mySerializer = new
                //XmlSerializer(typeof(StringEventListener));
                //// To write to a file, create a StreamWriter object.  
                //StreamWriter myWriter = new StreamWriter("myFileName.xml");
                //mySerializer.Serialize(myWriter, stringEventListener);
                //myWriter.Close();
                //var newNode = new ResXDataNode(stringEventListener.Guid.ToString(), c);
                //resourceWriter.AddResource(newNode);
                //resourceWriter.Generate();
                //resourceWriter.Close();

                // Instantiate an Automobile object.

                StringListener stringEventListener = new StringListener() { Name = "String Event" };
                //ObjectEventListener objectEventListener = new ObjectEventListener() { Name = "String Object" };

                // Define a resource file named CarResources.resx.
                using (ResXResourceWriter resx = new ResXResourceWriter(RESOURCE_PATH))
                {
                    //resx.AddResource("Title", "Classic American Cars");
                    //resx.AddResource("HeaderString1", "Make");
                    //resx.AddResource("HeaderString2", "Model");
                    //resx.AddResource("HeaderString3", "Year");
                    //resx.AddResource("HeaderString4", "Doors");
                    //resx.AddResource("HeaderString5", "Cylinders");
                    //resx.AddResource("Information", SystemIcons.Information);
                    //resx.AddResource("EarlyAuto1", car1);
                    //resx.AddResource("EarlyAuto2", car2);
                    resx.AddResource(stringEventListener.Guid.ToString(), stringEventListener);



                }

                MessageBox.Show("Entry has been created");
            }
            //if the file path is wrong or dosn't found
            catch (FileNotFoundException caught)
            {
                MessageBox.Show("Source: " + caught.Source + " Message: " + caught.Message);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            CreateEvent(_eventListenerBase.EventType);

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
