﻿using SerializableEvents.Core;
using SerializableEvents.Model;
using SerializableEvents.Presentation;
using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;

namespace SerializableEvents.Components
{
    [ToolboxItem(false)]
    [DesignerSerializer(typeof(SerializableEventCodeDomSerializer), typeof(CodeDomSerializer))]
    public partial class EventListenerBase : Component
    {
        [Description("Descreva o que esse evento faz, essa informação é somente para documentação.")]
        [DefaultValue(null)]
        public string Description { get; set; }

        [ReadOnly(true), Browsable(false)]
        public Type EventType { get; protected set; }

        [Browsable(true)]
        [Description("Select the resource key that you would like to bind the text to.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Editor(typeof(ResourceDropDownListPropertyEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [DefaultValue(null)]
        public SerializableEvent SerializableEvent { get; set; }

        protected Action<IGenericEventArgs> _redirect;

        private void ResourceName_OnEventTriggered(IGenericEventArgs obj)
        {
            _redirect?.Invoke(obj);
        }

        public void Subscribe(object sender, EventArgs e)
        {
            MessageBox.Show("inscrito");
            SerializableEvent.Initialize();
            SerializableEvent.Subscribe();
            SerializableEvent.OnEventTriggered += ResourceName_OnEventTriggered;
        }

        public void Unsubscribe(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("removed");
            SerializableEvent.Unsubscribe();
            SerializableEvent.OnEventTriggered -= ResourceName_OnEventTriggered;
        }
    }
}
