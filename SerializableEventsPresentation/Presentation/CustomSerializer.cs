using SerializableEvents.Components;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerializableEventsPresentation
{
    public class MyCodeDomSerializer : CodeDomSerializer
    {
        public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
        {
            // This is how we associate the component with the serializer.
            CodeDomSerializer baseClassSerializer = (CodeDomSerializer)manager.
            GetSerializer(typeof(EventListenerBase).BaseType, typeof(CodeDomSerializer));

            /* This is the simplest case, in which the class just calls the base class
                to do the work. */
            return baseClassSerializer.Deserialize(manager, codeObject);
        }

        public override object Serialize(IDesignerSerializationManager manager, object value)
        {
            /* Associate the component with the serializer in the same manner as with
                Deserialize */
            CodeDomSerializer baseClassSerializer = (CodeDomSerializer)manager.
                GetSerializer(typeof(EventListenerBase).BaseType, typeof(CodeDomSerializer));

            object codeObject = baseClassSerializer.Serialize(manager, value);

            /* Anything could be in the codeObject.  This sample operates on a
                CodeStatementCollection. */
            if (codeObject is CodeStatementCollection)
            {
                CodeStatementCollection statements = (CodeStatementCollection)codeObject;

                try
                {
                    //var x = (CodeVariableDeclarationStatement)statements[0];

                    var name = value.ToString().Split(' ')[0];

                    //CodeVariableReferenceExpression variableRef1 =
                    //     new CodeVariableReferenceExpression();

                    CodeFieldReferenceExpression fieldRef1 = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), name);

                    CodeDelegateCreateExpression createDelegate1 = new CodeDelegateCreateExpression(
                    new CodeTypeReference("System.Windows.Forms.FormClosedEventHandler"), fieldRef1, "Unsubscribe");

                    // Attaches an EventHandler delegate pointing to TestMethod to the TestEvent event.
                    CodeAttachEventStatement attachStatement1 = new CodeAttachEventStatement(new CodeThisReferenceExpression(), "FormClosed", createDelegate1);
                    statements.Add(attachStatement1);

                    CodeFieldReferenceExpression fieldRef2 = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), name);

                    CodeDelegateCreateExpression createDelegate2 = new CodeDelegateCreateExpression(
                    new CodeTypeReference("System.EventHandler"), fieldRef2, "Subscribe");

                    // Attaches an EventHandler delegate pointing to TestMethod to the TestEvent event.
                    CodeAttachEventStatement attachStatement2 = new CodeAttachEventStatement(new CodeThisReferenceExpression(), "Shown", createDelegate2);
                    statements.Add(attachStatement2);

                }
                catch (Exception)
                {
                    MessageBox.Show("erro ao converter valor");
                }


            }
            return codeObject;
        }
    }
}
