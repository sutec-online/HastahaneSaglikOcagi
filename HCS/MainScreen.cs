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
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        /*
         * Hakkında butonu
         */
        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("'Health Clinic System' program is developed by Şeyma Sarıgil. All rights reserved. Copyright 2017", "Copyright", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /*
         * Uygulamadan Çık butonu
         */
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*
         * Sayfa ilk kez açıldığında tüm hastaları getir.
         */
        private void MainScreen_Load(object sender, EventArgs e)
        {
            //PatientManager.Create(2, "Şeyma", "Sarıgil", "12345678900", new DateTime(2017,01,03,18,33,00), true);

            /**
             * Kullanıcının yönetici olup olmadığını kontrol et.
             * Yönetici değilse referanslar kısmını gizle
             */
            dropReferences.Visible = Auth.User.admin ? true : false;

            /**
             * Tüm Hastaları dataGridView'e ekle
             */
            dgvPatients.Rows.Clear();
            addToDataGridView(PatientManager.All());
        }
        
        /**
         * Tüm hastalar butonuna tıklanınca...
         */
        private void btnAll_Click(object sender, EventArgs e)
        {
            dgvPatients.Rows.Clear(); // tabloyu tamamen temizle
            addToDataGridView(PatientManager.All());
        }

        private void addToDataGridView(IEnumerable<Patient> patients)
        {
            foreach (Patient patient in patients) // Tüm hastaları veritabanından çek
            {
                // Her hastayı tabloya teker teker ekle.
                dgvPatients.Rows.Add(patient.id, patient.name, patient.surname, patient.identity, patient.shipment, patient.is_discharged ? true : false);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime start = dtpStart.Value;
            DateTime end = dtpEnd.Value;

            if (rdiAll.Checked)
            {
                // Eğer tüm hastalar istenmişse...
                dgvPatients.Rows.Clear();
                addToDataGridView(PatientManager.Filter(start, end));
            } else
            {
                // Taburcu olan veya olmayan hastalar istenmişse...
                dgvPatients.Rows.Clear();
                addToDataGridView(PatientManager.Filter(start, end, rdiDischarged.Checked));
            }
        }

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            Program.form = new NewPatientScreen();
            Program.close = false;
            Close();
        }

        private void btnPolyclinics_Click(object sender, EventArgs e)
        {
            Program.form = new PolyclinicScreen();
            Program.close = false;
            Close();
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            Program.form = new DoctorScreen();
            Program.close = false;
            Close();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Program.form = new UserScreen();
            Program.close = false;
            Close();
        }

        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                Patient patient = PatientManager.GetById(long.Parse(dgvPatients.Rows[e.RowIndex].Cells[0].Value.ToString()));
                PatientScreen patientScreen = new PatientScreen(patient);
                patientScreen.Show();
                patientScreen.Closed += PatientForm_Closed;
            }
        }

        void PatientForm_Closed(object sender, EventArgs e)
        {
            dgvPatients.Rows.Clear();
            addToDataGridView(PatientManager.All());
        }
    }
}
