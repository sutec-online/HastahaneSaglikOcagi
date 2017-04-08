namespace HCS
{
    partial class NewPatientScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtIdentity = new System.Windows.Forms.TextBox();
            this.dtpShipment = new System.Windows.Forms.DateTimePicker();
            this.chkDischarged = new System.Windows.Forms.CheckBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.nupNo = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nupNo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Surname";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Identity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Shipment Date";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(139, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 22);
            this.txtName.TabIndex = 6;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(139, 81);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(200, 22);
            this.txtSurname.TabIndex = 7;
            // 
            // txtIdentity
            // 
            this.txtIdentity.Location = new System.Drawing.Point(139, 123);
            this.txtIdentity.Name = "txtIdentity";
            this.txtIdentity.Size = new System.Drawing.Size(200, 22);
            this.txtIdentity.TabIndex = 8;
            // 
            // dtpShipment
            // 
            this.dtpShipment.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpShipment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShipment.Location = new System.Drawing.Point(139, 164);
            this.dtpShipment.Name = "dtpShipment";
            this.dtpShipment.Size = new System.Drawing.Size(200, 22);
            this.dtpShipment.TabIndex = 9;
            // 
            // chkDischarged
            // 
            this.chkDischarged.AutoSize = true;
            this.chkDischarged.Location = new System.Drawing.Point(139, 205);
            this.chkDischarged.Name = "chkDischarged";
            this.chkDischarged.Size = new System.Drawing.Size(128, 21);
            this.chkDischarged.TabIndex = 10;
            this.chkDischarged.Text = "Is Discharged ?";
            this.chkDischarged.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(97, 244);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(170, 31);
            this.btnCreate.TabIndex = 11;
            this.btnCreate.Text = "Create New Patient";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // nupNo
            // 
            this.nupNo.Enabled = false;
            this.nupNo.Location = new System.Drawing.Point(139, 7);
            this.nupNo.Name = "nupNo";
            this.nupNo.ReadOnly = true;
            this.nupNo.Size = new System.Drawing.Size(200, 22);
            this.nupNo.TabIndex = 12;
            this.nupNo.ValueChanged += new System.EventHandler(this.nupNo_ValueChanged);
            // 
            // NewPatientScreen
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 287);
            this.Controls.Add(this.nupNo);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.chkDischarged);
            this.Controls.Add(this.dtpShipment);
            this.Controls.Add(this.txtIdentity);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewPatientScreen";
            this.Text = "HCS | New Patient Screen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewPatientScreen_FormClosed);
            this.Load += new System.EventHandler(this.NewPatientScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtIdentity;
        private System.Windows.Forms.DateTimePicker dtpShipment;
        private System.Windows.Forms.CheckBox chkDischarged;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.NumericUpDown nupNo;
    }
}