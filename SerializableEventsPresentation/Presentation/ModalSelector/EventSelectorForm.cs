using SerializableEvents.Components;
using SerializableEvents.Core;
using SerializableEvents.Core.EventListeners;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace WindowsFormsPubSub.ModalSelector
{
    public partial class EventSelectorForm : DevComponents.DotNetBar.Office2007Form
    {

        private const string RESOURCE_PATH = "C:\\Users\\felip\\source\\repos\\SerializableEvents\\SerializableEvents\\Properties\\SerializableEventResources.resx";

        private Dictionary<string, IEventListener> _events = new Dictionary<string, IEventListener>();
        private List<DislayEvent> _itens = new List<DislayEvent>();

        private EventListenerBase _eventListenerBase;
        public EventSelectorForm(EventListenerBase eventListenerBase)
        {
            _eventListenerBase = eventListenerBase;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create(RESOURCE_PATH, "aquiii");
        }

        private IEventListener CreateEvent(Type type)
        {
            IEventListener eventType = (IEventListener)Activator.CreateInstance(type);

            MessageBox.Show("Evento criado com sucesso" + eventType.Guid);

            return eventType;
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

                    _itens.Add(new DislayEvent(itemConverted.Name, itemConverted.Guid));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    break;
                }
            }
            dataGridViewX1.DataSource = _itens;

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

        private void itemPanel2_ItemClick(object sender, EventArgs e)
        {

        }

        private void panelEx2_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            ListResources();
        }

        private void command1_Executed(object sender, EventArgs e)
        {

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

                StringEventListener stringEventListener = new StringEventListener() { Name = "String Event" };
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
                    //resx.AddResource("EventObject", objectEventListener);


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

        private void buttonX3_Click(object sender, EventArgs e)
        {
            CreateEvent(_eventListenerBase.EventType);
        }
    }
}
