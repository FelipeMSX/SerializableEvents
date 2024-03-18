namespace WindowsFormsPubSub.ModalSelector
{
    partial class EventSelectorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventSelectorForm));
            this.panelHeader = new DevComponents.DotNetBar.PanelEx();
            this.pnImage = new System.Windows.Forms.Panel();
            this.lblEventName = new DevComponents.DotNetBar.LabelX();
            this.lblEventId = new DevComponents.DotNetBar.LabelX();
            this.pnBottom = new DevComponents.DotNetBar.PanelEx();
            this.lblInfoSave = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.cbbEvents = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblEventsInfo = new DevComponents.DotNetBar.LabelX();
            this.btnCreateNew = new DevComponents.DotNetBar.ButtonX();
            this.warninBox = new DevComponents.DotNetBar.Controls.WarningBox();
            this.panelEvents = new System.Windows.Forms.Panel();
            this.btnRemove = new DevComponents.DotNetBar.ButtonX();
            this.panelHeader.SuspendLayout();
            this.pnBottom.SuspendLayout();
            this.panelEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelHeader.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelHeader.Controls.Add(this.pnImage);
            this.panelHeader.Controls.Add(this.lblEventName);
            this.panelHeader.Controls.Add(this.lblEventId);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(542, 98);
            this.panelHeader.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelHeader.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelHeader.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelHeader.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelHeader.Style.GradientAngle = 90;
            this.panelHeader.TabIndex = 1;
            // 
            // pnImage
            // 
            this.pnImage.BackgroundImage = global::SerializableEvents.Properties.Resources.EventIcon_64;
            this.pnImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnImage.Location = new System.Drawing.Point(12, 18);
            this.pnImage.Name = "pnImage";
            this.pnImage.Size = new System.Drawing.Size(71, 66);
            this.pnImage.TabIndex = 4;
            // 
            // lblEventName
            // 
            // 
            // 
            // 
            this.lblEventName.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor2;
            this.lblEventName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEventName.ForeColor = System.Drawing.Color.Gray;
            this.lblEventName.Location = new System.Drawing.Point(102, 47);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(393, 23);
            this.lblEventName.TabIndex = 3;
            this.lblEventName.Text = "[EVENT_TYPE_NAME]";
            // 
            // lblEventId
            // 
            // 
            // 
            // 
            this.lblEventId.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEventId.Location = new System.Drawing.Point(102, 18);
            this.lblEventId.Name = "lblEventId";
            this.lblEventId.Size = new System.Drawing.Size(393, 23);
            this.lblEventId.TabIndex = 0;
            this.lblEventId.Text = "[EVENT_TYPE_ID]";
            // 
            // pnBottom
            // 
            this.pnBottom.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnBottom.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnBottom.Controls.Add(this.lblInfoSave);
            this.pnBottom.Controls.Add(this.btnSave);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnBottom.Location = new System.Drawing.Point(0, 378);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(542, 72);
            this.pnBottom.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnBottom.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.pnBottom.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.pnBottom.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.pnBottom.Style.GradientAngle = 90;
            this.pnBottom.TabIndex = 3;
            // 
            // lblInfoSave
            // 
            // 
            // 
            // 
            this.lblInfoSave.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblInfoSave.Location = new System.Drawing.Point(12, 26);
            this.lblInfoSave.Name = "lblInfoSave";
            this.lblInfoSave.Size = new System.Drawing.Size(377, 23);
            this.lblInfoSave.Symbol = "";
            this.lblInfoSave.TabIndex = 2;
            this.lblInfoSave.Text = "Alterações são somente gravadas ao salvar.";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(455, 26);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Serializar";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbbEvents
            // 
            this.cbbEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbEvents.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbEvents.FormattingEnabled = true;
            this.cbbEvents.ItemHeight = 14;
            this.cbbEvents.Location = new System.Drawing.Point(12, 107);
            this.cbbEvents.Name = "cbbEvents";
            this.cbbEvents.Size = new System.Drawing.Size(518, 20);
            this.cbbEvents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbEvents.TabIndex = 0;
            this.cbbEvents.SelectedIndexChanged += new System.EventHandler(this.cbbEvents_SelectedIndexChanged);
            // 
            // lblEventsInfo
            // 
            // 
            // 
            // 
            this.lblEventsInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEventsInfo.Location = new System.Drawing.Point(12, 78);
            this.lblEventsInfo.Name = "lblEventsInfo";
            this.lblEventsInfo.Size = new System.Drawing.Size(229, 23);
            this.lblEventsInfo.Symbol = "";
            this.lblEventsInfo.TabIndex = 1;
            this.lblEventsInfo.Text = "Selecione um evento serializável abaixo:";
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCreateNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCreateNew.Location = new System.Drawing.Point(495, 66);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(35, 35);
            this.btnCreateNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCreateNew.Symbol = "";
            this.btnCreateNew.TabIndex = 2;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // warninBox
            // 
            this.warninBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(159)))));
            this.warninBox.ColorScheme = DevComponents.DotNetBar.Controls.eWarningBoxColorScheme.Yellow;
            this.warninBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.warninBox.Location = new System.Drawing.Point(0, 0);
            this.warninBox.Name = "warninBox";
            this.warninBox.OptionsButtonVisible = false;
            this.warninBox.Size = new System.Drawing.Size(540, 33);
            this.warninBox.TabIndex = 3;
            this.warninBox.Text = "<b>Warning Box</b> control with <i>text-markup</i> support.";
            this.warninBox.CloseClick += new System.EventHandler(this.warninBox_CloseClick);
            // 
            // panelEvents
            // 
            this.panelEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEvents.BackColor = System.Drawing.Color.Transparent;
            this.panelEvents.Controls.Add(this.btnRemove);
            this.panelEvents.Controls.Add(this.warninBox);
            this.panelEvents.Controls.Add(this.btnCreateNew);
            this.panelEvents.Controls.Add(this.lblEventsInfo);
            this.panelEvents.Controls.Add(this.cbbEvents);
            this.panelEvents.Location = new System.Drawing.Point(0, 104);
            this.panelEvents.Name = "panelEvents";
            this.panelEvents.Size = new System.Drawing.Size(540, 268);
            this.panelEvents.TabIndex = 2;
            // 
            // btnRemove
            // 
            this.btnRemove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRemove.Location = new System.Drawing.Point(455, 66);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(35, 35);
            this.btnRemove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRemove.Symbol = "";
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // EventSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 450);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.panelEvents);
            this.Controls.Add(this.panelHeader);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventSelectorForm";
            this.Text = "Serializable Event System";
            this.panelHeader.ResumeLayout(false);
            this.pnBottom.ResumeLayout(false);
            this.panelEvents.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelHeader;
        private DevComponents.DotNetBar.PanelEx pnBottom;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.LabelX lblEventId;
        private DevComponents.DotNetBar.LabelX lblEventName;
        private System.Windows.Forms.Panel pnImage;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbEvents;
        private DevComponents.DotNetBar.LabelX lblEventsInfo;
        private DevComponents.DotNetBar.ButtonX btnCreateNew;
        private DevComponents.DotNetBar.Controls.WarningBox warninBox;
        private System.Windows.Forms.Panel panelEvents;
        private DevComponents.DotNetBar.ButtonX btnRemove;
        private DevComponents.DotNetBar.LabelX lblInfoSave;
    }
}