using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HCSLibrary;

namespace HCS
{
    public partial class NewPatientScreen : Form
    {
        public NewPatientScreen()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Formdan bilgileri al
            long no = long.Parse(nupNo.Value.ToString()); // Hasta no
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string identity = txtIdentity.Text; // TCKN
            DateTime shipment = dtpShipment.Value; // shipment: Sevk 
            bool is_discharged = chkDischarged.Checked;

            if (name != "" && surname != "" && identity != "")
            {
                // Veritabanına yeni hastayı kayıt et
                PatientManager.Create(no, name, surname, identity, shipment, is_discharged);

                // Mesaj kutusu göster
                MessageBox.Show("New patient successfully created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ana ekrana geri dön (hasta listesine)
                Program.form = new MainScreen();
                Program.close = false;
                Close();
            }
        }
        private void NewPatientScreen_Load(object sender, EventArgs e)
        {
            long lastPatientNumber = PatientManager.LastId();
            nupNo.Value = lastPatientNumber + 1;
        }

        private void nupNo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NewPatientScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.form = new MainScreen();
            Program.close = false;
        }
    }
}
