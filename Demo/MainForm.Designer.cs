namespace Demo
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.stringEventListener1 = new SerializableEvents.Components.StringEventListener();
            this.SuspendLayout();
            // 
            // stringEventListener1
            // 
            this.stringEventListener1.SerializableEvent = ((SerializableEvents.Model.SerializableEvent)(resources.GetObject("stringEventListener1.SerializableEvent")));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.stringEventListener1.Unsubscribe);
            this.Shown += new System.EventHandler(this.stringEventListener1.Subscribe);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private SerializableEvents.Components.StringEventListener stringEventListener1;
    }
}

