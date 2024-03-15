using SerializableEvents.Components;
using SerializableEvents.Core;
using SerializableEvents.Presentation.Model;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using WindowsFormsPubSub.ModalSelector;

namespace SerializableEvents.Presentation
{
    class ResourceDropDownListPropertyGridEditor : UITypeEditor
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
                IEventSelectorView form = new EventSelectorFormWithGrid();
                var presenter = new EventSelectorPresenter(form, eventlistener.EventType, eventlistener.SerializableEvent);

                if (presenter.ShowDialog() == DialogResult.OK)
                {
                    return form.SelectedItem;
                }
            }

            return value;
        }
    }
}
