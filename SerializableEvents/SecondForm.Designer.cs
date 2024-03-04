namespace SerializableEvents
{
    partial class SecondForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecondForm));
            this.txtConsole = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.stringEventListenerComponent1 = new SerializableEvents.Components.StringEventListenerComponent();
            this.SuspendLayout();
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtConsole.Border.Class = "TextBoxBorder";
            this.txtConsole.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtConsole.Location = new System.Drawing.Point(12, 205);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(408, 55);
            this.txtConsole.TabIndex = 0;
            // 
            // stringEventListenerComponent1
            // 
            this.stringEventListenerComponent1.Description = null;
            this.stringEventListenerComponent1.EventName = null;
            this.stringEventListenerComponent1.ResourceName = ((SerializableEventsPresentation.Temp.EventComponent)(resources.GetObject("stringEventListenerComponent1.ResourceName")));
            this.stringEventListenerComponent1.OnEventTriggered += new System.EventHandler<SerializableEvents.Core.EventArgs.StringEventArgs>(this.stringEventListenerComponent1_OnEventTriggered);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.stringEventListenerComponent1.Unsubscribe);
            this.Shown += new System.EventHandler(this.stringEventListenerComponent1.Subscribe);
            // 
            // SecondForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 272);
            this.Controls.Add(this.txtConsole);
            this.Name = "SecondForm";
            this.Text = "Second";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtConsole;
        private Components.StringEventListenerComponent stringEventListenerComponent1;
    }
}

