namespace HCS
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDischarged = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.rdiDischarged = new System.Windows.Forms.RadioButton();
            this.rdiNotDischarged = new System.Windows.Forms.RadioButton();
            this.rdiAll = new System.Windows.Forms.RadioButton();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewPatient = new System.Windows.Forms.ToolStripButton();
            this.dropReferences = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnPolyclinics = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDoctors = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbout = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPatients
            // 
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.AllowUserToOrderColumns = true;
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.firstName,
            this.surname,
            this.identity,
            this.shipmentDate,
            this.isDischarged});
            this.dgvPatients.Location = new System.Drawing.Point(12, 140);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.RowTemplate.Height = 24;
            this.dgvPatients.Size = new System.Drawing.Size(934, 399);
            this.dgvPatients.TabIndex = 0;
            this.dgvPatients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatients_CellClick);
            // 
            // no
            // 
            this.no.HeaderText = "No";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            // 
            // firstName
            // 
            this.firstName.HeaderText = "First Name";
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            // 
            // surname
            // 
            this.surname.HeaderText = "Surname";
            this.surname.Name = "surname";
            this.surname.ReadOnly = true;
            // 
            // identity
            // 
            this.identity.HeaderText = "Identity";
            this.identity.Name = "identity";
            this.identity.ReadOnly = true;
            // 
            // shipmentDate
            // 
            this.shipmentDate.HeaderText = "Shipment Date";
            this.shipmentDate.Name = "shipmentDate";
            this.shipmentDate.ReadOnly = true;
            // 
            // isDischarged
            // 
            this.isDischarged.HeaderText = "Is Discharged?";
            this.isDischarged.Name = "isDischarged";
            this.isDischarged.ReadOnly = true;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(106, 40);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(215, 22);
            this.dtpStart.TabIndex = 1;
            this.dtpStart.Value = new System.DateTime(2017, 1, 3, 18, 14, 51, 0);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(106, 94);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(215, 22);
            this.dtpEnd.TabIndex = 2;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(9, 40);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(91, 17);
            this.lblStart.TabIndex = 3;
            this.lblStart.Text = "Starting Date";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(9, 94);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(86, 17);
            this.lblEnd.TabIndex = 4;
            this.lblEnd.Text = "Ending Date";
            // 
            // rdiDischarged
            // 
            this.rdiDischarged.AutoSize = true;
            this.rdiDischarged.Location = new System.Drawing.Point(414, 38);
            this.rdiDischarged.Name = "rdiDischarged";
            this.rdiDischarged.Size = new System.Drawing.Size(101, 21);
            this.rdiDischarged.TabIndex = 5;
            this.rdiDischarged.Text = "Discharged";
            this.rdiDischarged.UseVisualStyleBackColor = true;
            // 
            // rdiNotDischarged
            // 
            this.rdiNotDischarged.AutoSize = true;
            this.rdiNotDischarged.Location = new System.Drawing.Point(414, 65);
            this.rdiNotDischarged.Name = "rdiNotDischarged";
            this.rdiNotDischarged.Size = new System.Drawing.Size(127, 21);
            this.rdiNotDischarged.TabIndex = 6;
            this.rdiNotDischarged.Text = "Not Discharged";
            this.rdiNotDischarged.UseVisualStyleBackColor = true;
            // 
            // rdiAll
            // 
            this.rdiAll.AutoSize = true;
            this.rdiAll.Checked = true;
            this.rdiAll.Location = new System.Drawing.Point(414, 92);
            this.rdiAll.Name = "rdiAll";
            this.rdiAll.Size = new System.Drawing.Size(44, 21);
            this.rdiAll.TabIndex = 7;
            this.rdiAll.TabStop = true;
            this.rdiAll.Text = "All";
            this.rdiAll.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(568, 42);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(93, 69);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(667, 41);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(93, 69);
            this.btnAll.TabIndex = 9;
            this.btnAll.Text = "All Patients";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(853, 41);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(93, 69);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewPatient,
            this.dropReferences,
            this.toolStripSeparator1,
            this.btnAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(958, 27);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNewPatient
            // 
            this.btnNewPatient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNewPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnNewPatient.Image")));
            this.btnNewPatient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewPatient.Name = "btnNewPatient";
            this.btnNewPatient.Size = new System.Drawing.Size(92, 24);
            this.btnNewPatient.Text = "New Patient";
            this.btnNewPatient.Click += new System.EventHandler(this.btnNewPatient_Click);
            // 
            // dropReferences
            // 
            this.dropReferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dropReferences.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPolyclinics,
            this.btnDoctors,
            this.btnUsers});
            this.dropReferences.Image = ((System.Drawing.Image)(resources.GetObject("dropReferences.Image")));
            this.dropReferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dropReferences.Name = "dropReferences";
            this.dropReferences.Size = new System.Drawing.Size(95, 24);
            this.dropReferences.Text = "References";
            // 
            // btnPolyclinics
            // 
            this.btnPolyclinics.Name = "btnPolyclinics";
            this.btnPolyclinics.Size = new System.Drawing.Size(181, 26);
            this.btnPolyclinics.Text = "Polyclinics";
            this.btnPolyclinics.Click += new System.EventHandler(this.btnPolyclinics_Click);
            // 
            // btnDoctors
            // 
            this.btnDoctors.Name = "btnDoctors";
            this.btnDoctors.Size = new System.Drawing.Size(181, 26);
            this.btnDoctors.Text = "Doctors";
            this.btnDoctors.Click += new System.EventHandler(this.btnDoctors_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(181, 26);
            this.btnUsers.Text = "Users";
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnAbout
            // 
            this.btnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(54, 24);
            this.btnAbout.Text = "About";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 554);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.rdiAll);
            this.Controls.Add(this.rdiNotDischarged);
            this.Controls.Add(this.rdiDischarged);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.dgvPatients);
            this.Name = "MainScreen";
            this.Text = "HCS | Main Screen";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn identity;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipmentDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDischarged;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.RadioButton rdiDischarged;
        private System.Windows.Forms.RadioButton rdiNotDischarged;
        private System.Windows.Forms.RadioButton rdiAll;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNewPatient;
        private System.Windows.Forms.ToolStripDropDownButton dropReferences;
        private System.Windows.Forms.ToolStripMenuItem btnPolyclinics;
        private System.Windows.Forms.ToolStripMenuItem btnDoctors;
        private System.Windows.Forms.ToolStripMenuItem btnUsers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAbout;
    }
}