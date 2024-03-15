using SerializableEvents.Core;
using SerializableEvents.Presentation;
using SerializableEvents.Presentation.Model;
using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Windows.Forms;

namespace SerializableEvents.Components
{
    [ToolboxItem(false)]
    [DesignerSerializer(typeof(SerializableEventCodeDomSerializer), typeof(CodeDomSerializer))]
    [ToolboxBitmapAttribute(typeof(EventListenerBase), "EventSystemIcon_16")]
    public partial class EventListenerBase : Component
    {
        [Description("Descreva o que esse evento faz, essa informação é somente para documentação.")]
        [DefaultValue(null)]
        public string Description { get; set; }

        [Description("Indica se o listener vai inscrever assim que instanciar o objeto, caso contrário, vai inscrever no show do formulário.")]
        [DefaultValue(false)]
        public bool ConstructorInjection { get; set; }

        [ReadOnly(true), Browsable(false)]
        public Type EventType { get; protected set; }

        private SerializableEvent _serializableEvent;
        [Browsable(true)]
        [Description("Select the resource key that you would like to bind the text to.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Editor(typeof(ResourceDropDownListPropertyEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [DefaultValue(null)]
        public SerializableEvent SerializableEvent
        {
            get => _serializableEvent;
            set
            {
                _serializableEvent = value;
                //Colocar validação de não inscrever se for design mode.
                //if (ConstructorInjection)
                //    AutoSubsbribe();
            }
        }

        private SerializableEvent _serializableEventGrid;
        [Browsable(true)]
        [Description("Select the resource key that you would like to bind the text to.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Editor(typeof(ResourceDropDownListPropertyGridEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [DefaultValue(null)]
        public SerializableEvent SerializableEventGrid
        {
            get => _serializableEventGrid;
            set
            {
                _serializableEventGrid = value;
                //Colocar validação de não inscrever se for design mode.
                if (ConstructorInjection)
                    AutoSubsbribe();
            }
        }

        protected Action<IGenericEventArgs> _redirect;

        private void ResourceName_OnEventTriggered(IGenericEventArgs obj)
        {
            _redirect?.Invoke(obj);
        }

        public void Subscribe(object sender, EventArgs e)
        {
            if (!ConstructorInjection)
                AutoSubsbribe();
        }

        public void Unsubscribe(object sender, FormClosedEventArgs e)
        {
            SerializableEvent.Unsubscribe();
            SerializableEvent.OnEventTriggered -= ResourceName_OnEventTriggered;
        }

        private void AutoSubsbribe()
        {
            SerializableEvent.Initialize();
            SerializableEvent.Subscribe();
            SerializableEvent.OnEventTriggered += ResourceName_OnEventTriggered;
        }
    }
}
