using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerializableEvents
{
    public partial class SecondForm : Form
    {
        private StringBuilder sb;
        public SecondForm()
        {
            InitializeComponent();
            sb = new StringBuilder();
        }

        private void stringEventListener1_OnEventTriggered(object sender, SerializableEvents.Core.EventArgs.StringEventArgs e)
        {

        }

        private void stringEventListenerComponent1_OnEventTriggered(object sender, SerializableEvents.Core.EventArgs.StringEventArgs e)
        {
            sb.Append("Append Test");
            txtConsole.Text = sb.ToString();
        }
    }
}
