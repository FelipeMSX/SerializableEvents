using SerializableEvents.Components;
using SerializableEvents.Core;
using SerializableEvents.Model;
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


        /// </summary>
        /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
        /// <param name="provider">A service provider object through which editing services may be obtained.</param>
        /// <param name="value">An instance of the value being edited.</param>
        /// <returns>The new value of the object. If the value of the object hasn't changed, this method should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                // This service is in charge of popping our ListBox.
                _service = ((IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService)));



                EventListenerBase eventlistener = context.Instance as EventListenerBase;
                //t.t
                EventSelectorForm form = new EventSelectorForm(eventlistener);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    IEventListener eventlistner = form.ObterEventListener();
                    SerializableEvent eventComponent = new SerializableEvent();
                    eventComponent.Guid = eventlistner.Guid;
                    eventComponent.Name = eventlistner.Name;


                   return eventComponent;
                }

                    if (_service != null)
                {
                //    //System.Resources.ResourceManager MyResourceClass = new System.Resources.ResourceManager("ApplauzUltimateTool.Properties.Resources", typeof(Resources).Assembly);

                //    ResourceManager MyResourceClass = new ResourceManager(typeof(Resources));

                //    ResourceSet resourceSet = MyResourceClass.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

                //    List<KeyValuePair<string,object>> _list = new List<KeyValuePair<string, object>>();

                //    foreach (DictionaryEntry entry in resourceSet)
                //    {
                //        string resourceKey = entry.Key.ToString();
                //        object resource = entry.Value;
                //        _list.Add(new KeyValuePair<string, object>(resourceKey, resource));
                //    }

                //    var list = new ListBox();
                //    list.Click += ListBox_Click;

                //    foreach (KeyValuePair<string, object> item in _list)
                //    {
                //        list.Items.Add(item);
                //    }
                //    if (value != null)
                //    {
                //        list.SelectedValue = value;
                //    }

                //    // Drop the list control.
                //    _service.DropDownControl(list);

                //    if (list.SelectedItem != null && list.SelectedIndices.Count == 1)
                //    {
                //        list.SelectedItem = list.SelectedItem;
                //        value = list.SelectedItem;
                //    }

                //    list.Click -= ListBox_Click;
                }

            }

            return value;
        }

        private void ListBox_Click(object sender, System.EventArgs e)
        {
            if (_service != null)
                _service.CloseDropDown();

        }
    }
}
