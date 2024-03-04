using SerializableEvents.Core;
using SerializableEventsPresentation;
using SerializableEventsPresentation.Temp;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;
using WindowsFormsControlLibrary1.SerializablePubSub;

namespace SerializableEvents.Components
{
    [DesignerSerializer(typeof(MyCodeDomSerializer), typeof(CodeDomSerializer))]
    public partial class EventListenerBase : Component, IDisposable
    {
        [Description("Descreva o que esse evento faz, essa informação é somente para documentação.")]
        public string Description { get; set; }

        [Description("Texto que deve ser exibido ao usuário.")]
        public string EventName { get; set; }

        [ReadOnly(true)]
        public Type EventType { get; protected set; }

        private EventComponent mResourceName;
        [Browsable(true)]
        [Editor(typeof(ResourceDropDownListPropertyEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Description("Select the resource key that you would like to bind the text to.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public EventComponent ResourceName
        {
            get { return mResourceName; }
            set
            {
                mResourceName = value;
            }
        }

        protected Action<IGenericEventArgs> _redirect;

        private void ResourceName_OnEventTriggered(IGenericEventArgs obj)
        {
            _redirect?.Invoke(obj);
        }

        public void Subscribe(object sender, EventArgs e)
        {
            MessageBox.Show("inscrito");
            ResourceName.Initialize();
            ResourceName.Subscribe();
            ResourceName.OnEventTriggered += ResourceName_OnEventTriggered;
        }

        public void Unsubscribe(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("removed");
            ResourceName.Unsubscribe();
            ResourceName.OnEventTriggered -= ResourceName_OnEventTriggered;
        }


        bool isInFormsDesignerMode = (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
    }
}
