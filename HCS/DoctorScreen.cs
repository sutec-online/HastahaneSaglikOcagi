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
    public partial class DoctorScreen : Form
    {
        private Doctor doct;

        public DoctorScreen()
        {
            InitializeComponent();
        }

        private void changeVisible(bool visible)
        {
            chkStatus.Visible = visible;
            btnDelete.Visible = visible;
            btnCreate.Visible = visible;
        }

        // Comboboxtaki doktorları günceller
        private void refreshDoctors()
        {
            cbxDoctors.Items.Clear();
            // Combobox'ın içine veritabanından gelen doktorları dolduralım.
            foreach (Doctor doctor in DoctorManager.All())
            {
                cbxDoctors.Items.Add(doctor.name);
            }
        }

        private void DoctorScreen_Load(object sender, EventArgs e)
        {
            // Form açıldığında tüm form elementlerini gizle
            changeVisible(false);

            refreshDoctors();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string doctorName = cbxDoctors.Text;

            if (doctorName != "")
            {


                if (DoctorManager.Check(doctorName)) // Doktor var mı diye kontrol et
                {
                    // Varsa, düzenleme formu
                    changeVisible(true); // formu görünür yap
                    doct = DoctorManager.Get(doctorName); // Veritabanından o doktoru getir

                    chkStatus.Checked = doct.status;
                }
                else
                {
                    // Yoksa, oluşturma formu
                    chkStatus.Checked = true; // Formu eski hale getir

                    changeVisible(true); // formu görünür yap
                    DoctorManager.Create(cbxDoctors.Text);

                    // Combobox'ı yenile
                    cbxDoctors.Items.Clear();
                    foreach (Doctor doctor in DoctorManager.All())
                    {
                        cbxDoctors.Items.Add(doctor.name);
                    }

                    // Düzenlenen doktor olarak yeni eklenen doktoru seç
                    doct = DoctorManager.Get(doctorName);

                    refreshDoctors(); // Combobox'ı güncelle
                }
            }
        }
        // Güncelleme işlemi
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string oldName = doct.name; // Önceki ismi tut (güncellerken buna göre güncelleyeceğiz)
            // Seçilen doktor nesnesinin bilgilerini güncelle
            doct.name = cbxDoctors.Text;
            doct.status = chkStatus.Checked;

            // Veritabanında da bu işlemi yap
            Database.client.Cypher
                .Match("(doctor:Doctor)")
                .Where((Doctor doctor) => doctor.name == oldName)
                .Set("doctor = {doct}")
                .WithParam("doct", doct)
                .ExecuteWithoutResults();

            refreshDoctors(); // Combobox'ı güncelle (isim değişmiş olabilir)

            MessageBox.Show("Doctor successfully updated!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(Program.DeleteConfirm("Do you want delete this doctor? All patient actions who belongs to this doctor also be deleted."))
            {
                DoctorManager.Delete(doct); // Veritabanından doktoru sil

                MessageBox.Show("Doctor successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refreshDoctors(); // Combobox'ı güncelle

                changeVisible(false); // formu gizle
                chkStatus.Checked = true; // formu boş hale al
                cbxDoctors.Text = ""; // Combobox'taki ismi sil
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoctorScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.form = new MainScreen();
            Program.close = false;
        }
    }
}
