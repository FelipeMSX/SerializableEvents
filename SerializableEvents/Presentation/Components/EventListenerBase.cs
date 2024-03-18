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
                if (Utils.IsDesignMode())
                    return;

                //Colocar validação de não inscrever se for design mode.
                if (ConstructorInjection)
                    AutoSubsbribe();
            }
        }

        //private SerializableEvent _serializableEventGrid;
        //[Browsable(true)]
        //[Description("Select the resource key that you would like to bind the text to.")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //[TypeConverter(typeof(ExpandableObjectConverter))]
        //[Editor(typeof(ResourceDropDownListPropertyGridEditor), typeof(System.Drawing.Design.UITypeEditor))]
        //[DefaultValue(null)]
        //public SerializableEvent SerializableEventGrid
        //{
        //    get => _serializableEventGrid;
        //    set
        //    {
        //        _serializableEventGrid = value;

        //        //if (Utils.IsDesignMode())
        //        //    return;

        //        ////Colocar validação de não inscrever se for design mode.
        //        //if (ConstructorInjection)
        //        //    AutoSubsbribe();
        //    }
        //}

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
            //Esse evento é chamado no close do form, caso ocorra um erro aqui só notificar e o fluxo deve continuar.
            try
            {
                SerializableEvent.Unsubscribe();
                SerializableEvent.OnEventTriggered -= ResourceName_OnEventTriggered;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar remover o evento de id {_serializableEvent?.Guid} - {ex.Message}");
            }
        }

        private void AutoSubsbribe()
        {
            //Não impedir a abertura do formulário em caso de erro
            try
            {
                SerializableEvent.Initialize();
                SerializableEvent.Subscribe();
                SerializableEvent.OnEventTriggered += ResourceName_OnEventTriggered;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar inscrever ao evento de id {_serializableEvent?.Guid} - {ex.Message}" );
            }
        }
    }
}
