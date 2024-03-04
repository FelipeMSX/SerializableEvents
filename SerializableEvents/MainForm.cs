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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SecondForm secondForm = new SecondForm();
            secondForm.MdiParent = this;
            secondForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stringEventListenerComponent1.Raise("Aquiiiiiii");
            //stringEventListener1.OnEventRaised("Aquiii");
        }

    }
}
