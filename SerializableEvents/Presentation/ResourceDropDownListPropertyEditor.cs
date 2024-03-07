using SerializableEvents.Components;
using SerializableEvents.Core;
using SerializableEvents.Model;
using SerializableEvents.Presentation.Model;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using WindowsFormsPubSub.ModalSelector;

namespace SerializableEvents.Presentation
{
    class ResourceDropDownListPropertyEditor : UITypeEditor
    {
        IWindowsFormsEditorService _service;

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            // We're using a drop down style UITypeEditor.
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {

                _service = ((IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService)));

                EventListenerBase eventlistener = context.Instance as EventListenerBase;
                EventSelectorForm form = new EventSelectorForm(eventlistener);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    EventEntry eventEntry = form.SelectedEventyEntry;
                    SerializableEvent eventComponent = new SerializableEvent
                    {
                        Guid = eventEntry.Guid,
                        Name = eventEntry.Name
                    };


                    return eventComponent;
                }
            }

            return value;
        }
    }
}
