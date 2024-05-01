namespace ARWMIO
{
    partial class formMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.dsList = new System.Data.DataSet();
            this.dtIOSource = new System.Data.DataTable();
            this.col_InputID = new System.Data.DataColumn();
            this.col_OutputID = new System.Data.DataColumn();
            this.col_delay = new System.Data.DataColumn();
            this.col_volume = new System.Data.DataColumn();
            this.col_panning = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.bsIOSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbInputDevice = new System.Windows.Forms.ListBox();
            this.lbOutputDevice = new System.Windows.Forms.ListBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wASAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbInputID = new System.Windows.Forms.TextBox();
            this.tbOutputID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPitch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPanning = new System.Windows.Forms.TextBox();
            this.lblVolume = new System.Windows.Forms.Label();
            this.lblDelay_ms = new System.Windows.Forms.Label();
            this.tbVolume = new System.Windows.Forms.TextBox();
            this.tbDelay_ms = new System.Windows.Forms.TextBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pbVolume = new System.Windows.Forms.ProgressBar();
            this.timer10ms = new System.Windows.Forms.Timer(this.components);
            this.dataColumn2 = new System.Data.DataColumn();
            this.delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delay_smpl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDelay_smpl = new System.Windows.Forms.Label();
            this.tbDelay_smpl = new System.Windows.Forms.TextBox();
            this.pitchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panningDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outputIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIOSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIOSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsList
            // 
            this.dsList.DataSetName = "NewDataSet";
            this.dsList.Locale = new System.Globalization.CultureInfo("");
            this.dsList.Tables.AddRange(new System.Data.DataTable[] {
            this.dtIOSource});
            // 
            // dtIOSource
            // 
            this.dtIOSource.Columns.AddRange(new System.Data.DataColumn[] {
            this.col_InputID,
            this.col_OutputID,
            this.col_delay,
            this.col_volume,
            this.col_panning,
            this.dataColumn1,
            this.dataColumn2});
            this.dtIOSource.TableName = "IOSource";
            // 
            // col_InputID
            // 
            this.col_InputID.Caption = "InputID";
            this.col_InputID.ColumnName = "inputID";
            // 
            // col_OutputID
            // 
            this.col_OutputID.Caption = "OutputID";
            this.col_OutputID.ColumnName = "outputID";
            // 
            // col_delay
            // 
            this.col_delay.AllowDBNull = false;
            this.col_delay.Caption = "delay (ms)";
            this.col_delay.ColumnName = "delay";
            this.col_delay.DataType = typeof(int);
            this.col_delay.DefaultValue = 0;
            // 
            // col_volume
            // 
            this.col_volume.AllowDBNull = false;
            this.col_volume.Caption = "Volume";
            this.col_volume.ColumnName = "volume";
            this.col_volume.DataType = typeof(float);
            this.col_volume.DefaultValue = 1F;
            // 
            // col_panning
            // 
            this.col_panning.AllowDBNull = false;
            this.col_panning.Caption = "Panning";
            this.col_panning.ColumnName = "panning";
            this.col_panning.DataType = typeof(float);
            this.col_panning.DefaultValue = 0F;
            // 
            // dataColumn1
            // 
            this.dataColumn1.AllowDBNull = false;
            this.dataColumn1.Caption = "Pitch";
            this.dataColumn1.ColumnName = "pitch";
            this.dataColumn1.DataType = typeof(float);
            this.dataColumn1.DefaultValue = 1F;
            // 
            // bsIOSource
            // 
            this.bsIOSource.DataMember = "IOSource";
            this.bsIOSource.DataSource = this.dsList;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inputIDDataGridViewTextBoxColumn,
            this.outputIDDataGridViewTextBoxColumn,
            this.delay,
            this.delay_smpl,
            this.volumeDataGridViewTextBoxColumn,
            this.panningDataGridViewTextBoxColumn,
            this.pitchDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bsIOSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 414);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(963, 282);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lbInputDevice
            // 
            this.lbInputDevice.FormattingEnabled = true;
            this.lbInputDevice.Location = new System.Drawing.Point(12, 27);
            this.lbInputDevice.Name = "lbInputDevice";
            this.lbInputDevice.Size = new System.Drawing.Size(402, 251);
            this.lbInputDevice.TabIndex = 1;
            this.lbInputDevice.SelectedIndexChanged += new System.EventHandler(this.lbInputDevice_SelectedIndexChanged);
            // 
            // lbOutputDevice
            // 
            this.lbOutputDevice.FormattingEnabled = true;
            this.lbOutputDevice.Location = new System.Drawing.Point(570, 27);
            this.lbOutputDevice.Name = "lbOutputDevice";
            this.lbOutputDevice.Size = new System.Drawing.Size(402, 251);
            this.lbOutputDevice.TabIndex = 2;
            this.lbOutputDevice.SelectedIndexChanged += new System.EventHandler(this.lbOutputDevice_SelectedIndexChanged);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.deviceToolStripMenuItem,
            this.playStopToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(987, 24);
            this.menu.TabIndex = 15;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.testToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // deviceToolStripMenuItem
            // 
            this.deviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wASAPIToolStripMenuItem});
            this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            this.deviceToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.deviceToolStripMenuItem.Text = "Device";
            // 
            // wASAPIToolStripMenuItem
            // 
            this.wASAPIToolStripMenuItem.Name = "wASAPIToolStripMenuItem";
            this.wASAPIToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.wASAPIToolStripMenuItem.Text = "WASAPI";
            this.wASAPIToolStripMenuItem.Click += new System.EventHandler(this.wASAPIToolStripMenuItem_Click);
            // 
            // playStopToolStripMenuItem
            // 
            this.playStopToolStripMenuItem.Name = "playStopToolStripMenuItem";
            this.playStopToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.playStopToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.playStopToolStripMenuItem.Text = "Play/Stop";
            this.playStopToolStripMenuItem.Click += new System.EventHandler(this.playStopToolStripMenuItem_Click);
            // 
            // tbInputID
            // 
            this.tbInputID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIOSource, "inputID", true));
            this.tbInputID.Location = new System.Drawing.Point(12, 284);
            this.tbInputID.Name = "tbInputID";
            this.tbInputID.Size = new System.Drawing.Size(402, 20);
            this.tbInputID.TabIndex = 20;
            // 
            // tbOutputID
            // 
            this.tbOutputID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIOSource, "outputID", true));
            this.tbOutputID.Location = new System.Drawing.Point(570, 284);
            this.tbOutputID.Name = "tbOutputID";
            this.tbOutputID.Size = new System.Drawing.Size(402, 20);
            this.tbOutputID.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(425, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Pitch";
            // 
            // tbPitch
            // 
            this.tbPitch.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIOSource, "pitch", true));
            this.tbPitch.Location = new System.Drawing.Point(428, 249);
            this.tbPitch.Name = "tbPitch";
            this.tbPitch.Size = new System.Drawing.Size(126, 20);
            this.tbPitch.TabIndex = 6;
            this.tbPitch.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Panning";
            // 
            // tbPanning
            // 
            this.tbPanning.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIOSource, "panning", true));
            this.tbPanning.Location = new System.Drawing.Point(428, 195);
            this.tbPanning.Name = "tbPanning";
            this.tbPanning.Size = new System.Drawing.Size(126, 20);
            this.tbPanning.TabIndex = 5;
            this.tbPanning.Text = "0";
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(425, 125);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(42, 13);
            this.lblVolume.TabIndex = 25;
            this.lblVolume.Text = "Volume";
            // 
            // lblDelay_ms
            // 
            this.lblDelay_ms.AutoSize = true;
            this.lblDelay_ms.Location = new System.Drawing.Point(425, 27);
            this.lblDelay_ms.Name = "lblDelay_ms";
            this.lblDelay_ms.Size = new System.Drawing.Size(56, 13);
            this.lblDelay_ms.TabIndex = 24;
            this.lblDelay_ms.Text = "Delay (ms)";
            // 
            // tbVolume
            // 
            this.tbVolume.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIOSource, "volume", true));
            this.tbVolume.Location = new System.Drawing.Point(428, 141);
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(126, 20);
            this.tbVolume.TabIndex = 4;
            this.tbVolume.Text = "1";
            // 
            // tbDelay_ms
            // 
            this.tbDelay_ms.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIOSource, "delay", true));
            this.tbDelay_ms.Location = new System.Drawing.Point(428, 46);
            this.tbDelay_ms.Name = "tbDelay_ms";
            this.tbDelay_ms.Size = new System.Drawing.Size(126, 20);
            this.tbDelay_ms.TabIndex = 3;
            this.tbDelay_ms.Text = "0";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(12, 310);
            this.tbID.Multiline = true;
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(960, 20);
            this.tbID.TabIndex = 30;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 385);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.Filter = "XML Files (*xml)|*.xml";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.Filter = "XML Files (*xml)|*.xml";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(93, 385);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(417, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(498, 387);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 20);
            this.textBox1.TabIndex = 33;
            // 
            // pbVolume
            // 
            this.pbVolume.Location = new System.Drawing.Point(12, 336);
            this.pbVolume.Name = "pbVolume";
            this.pbVolume.Size = new System.Drawing.Size(106, 23);
            this.pbVolume.TabIndex = 34;
            // 
            // timer10ms
            // 
            this.timer10ms.Interval = 10;
            this.timer10ms.Tick += new System.EventHandler(this.timer10ms_Tick);
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "delay (smpl.)";
            this.dataColumn2.ColumnName = "delay_smpl";
            this.dataColumn2.DataType = typeof(int);
            this.dataColumn2.DefaultValue = "0";
            // 
            // delay
            // 
            this.delay.DataPropertyName = "delay";
            this.delay.HeaderText = "delay (ms)";
            this.delay.Name = "delay";
            this.delay.Width = 50;
            // 
            // delay_smpl
            // 
            this.delay_smpl.DataPropertyName = "delay_smpl";
            this.delay_smpl.HeaderText = "delay (smpl.)";
            this.delay_smpl.Name = "delay_smpl";
            // 
            // lblDelay_smpl
            // 
            this.lblDelay_smpl.AutoSize = true;
            this.lblDelay_smpl.Location = new System.Drawing.Point(425, 74);
            this.lblDelay_smpl.Name = "lblDelay_smpl";
            this.lblDelay_smpl.Size = new System.Drawing.Size(67, 13);
            this.lblDelay_smpl.TabIndex = 36;
            this.lblDelay_smpl.Text = "Delay (smpl.)";
            // 
            // tbDelay_smpl
            // 
            this.tbDelay_smpl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIOSource, "delay_smpl", true));
            this.tbDelay_smpl.Location = new System.Drawing.Point(428, 93);
            this.tbDelay_smpl.Name = "tbDelay_smpl";
            this.tbDelay_smpl.Size = new System.Drawing.Size(126, 20);
            this.tbDelay_smpl.TabIndex = 35;
            this.tbDelay_smpl.Text = "0";
            // 
            // pitchDataGridViewTextBoxColumn
            // 
            this.pitchDataGridViewTextBoxColumn.DataPropertyName = "pitch";
            this.pitchDataGridViewTextBoxColumn.HeaderText = "pitch";
            this.pitchDataGridViewTextBoxColumn.Name = "pitchDataGridViewTextBoxColumn";
            this.pitchDataGridViewTextBoxColumn.Width = 50;
            // 
            // panningDataGridViewTextBoxColumn
            // 
            this.panningDataGridViewTextBoxColumn.DataPropertyName = "panning";
            this.panningDataGridViewTextBoxColumn.HeaderText = "panning";
            this.panningDataGridViewTextBoxColumn.Name = "panningDataGridViewTextBoxColumn";
            this.panningDataGridViewTextBoxColumn.Width = 60;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "volume";
            this.volumeDataGridViewTextBoxColumn.HeaderText = "volume";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.Width = 60;
            // 
            // outputIDDataGridViewTextBoxColumn
            // 
            this.outputIDDataGridViewTextBoxColumn.DataPropertyName = "outputID";
            this.outputIDDataGridViewTextBoxColumn.HeaderText = "outputID";
            this.outputIDDataGridViewTextBoxColumn.Name = "outputIDDataGridViewTextBoxColumn";
            this.outputIDDataGridViewTextBoxColumn.Width = 300;
            // 
            // inputIDDataGridViewTextBoxColumn
            // 
            this.inputIDDataGridViewTextBoxColumn.DataPropertyName = "inputID";
            this.inputIDDataGridViewTextBoxColumn.HeaderText = "inputID";
            this.inputIDDataGridViewTextBoxColumn.Name = "inputIDDataGridViewTextBoxColumn";
            this.inputIDDataGridViewTextBoxColumn.Width = 300;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 708);
            this.Controls.Add(this.lblDelay_smpl);
            this.Controls.Add(this.tbDelay_smpl);
            this.Controls.Add(this.pbVolume);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPitch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPanning);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.lblDelay_ms);
            this.Controls.Add(this.tbVolume);
            this.Controls.Add(this.tbDelay_ms);
            this.Controls.Add(this.tbOutputID);
            this.Controls.Add(this.tbInputID);
            this.Controls.Add(this.lbOutputDevice);
            this.Controls.Add(this.lbInputDevice);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "formMain";
            this.Text = "ARWMIO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.Load += new System.EventHandler(this.formMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIOSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIOSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Data.DataSet dsList;
        private System.Data.DataTable dtIOSource;
        private System.Data.DataColumn col_InputID;
        private System.Data.DataColumn col_OutputID;
        private System.Data.DataColumn col_delay;
        private System.Data.DataColumn col_volume;
        private System.Data.DataColumn col_panning;
        private System.Data.DataColumn dataColumn1;
        private System.Windows.Forms.BindingSource bsIOSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox lbInputDevice;
        private System.Windows.Forms.ListBox lbOutputDevice;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox tbInputID;
        private System.Windows.Forms.TextBox tbOutputID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPitch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPanning;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.Label lblDelay_ms;
        private System.Windows.Forms.TextBox tbVolume;
        private System.Windows.Forms.TextBox tbDelay_ms;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.ToolStripMenuItem playStopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wASAPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar pbVolume;
        private System.Windows.Forms.Timer timer10ms;
        private System.Data.DataColumn dataColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn delay;
        private System.Windows.Forms.DataGridViewTextBoxColumn delay_smpl;
        private System.Windows.Forms.Label lblDelay_smpl;
        private System.Windows.Forms.TextBox tbDelay_smpl;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outputIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn panningDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pitchDataGridViewTextBoxColumn;
    }
}

