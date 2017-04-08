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
    public partial class PolyclinicScreen : Form
    {
        private Polyclinic poly;

        public PolyclinicScreen()
        {
            InitializeComponent();
        }

        private void changeVisible(bool visible)
        {
            lblDesc.Visible = visible;
            txtDesc.Visible = visible;
            chkStatus.Visible = visible;
            btnDelete.Visible = visible;
            btnCreate.Visible = visible;
        }

        // Comboboxtaki poliklinikleri günceller
        private void refreshPolyclinics()
        {
            cbxPolyclinics.Items.Clear();
            // Combobox'ın içine veritabanından gelen Polyclinic leri dolduralım.
            foreach (Polyclinic polyclinic in PolyclinicManager.All())
            {
                cbxPolyclinics.Items.Add(polyclinic.name);
            }
        }

        private void PolyclinicScreen_Load(object sender, EventArgs e)
        {
            // Form açıldığında tüm form elementlerini gizle
            changeVisible(false);

            refreshPolyclinics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string polyclinicName = cbxPolyclinics.Text;
            if (polyclinicName != "")
            {
                if (PolyclinicManager.Check(polyclinicName)) // Poliklinik var mı diye kontrol et
                {
                    // Varsa, düzenleme formu
                    changeVisible(true); // formu görünür yap
                    poly = PolyclinicManager.Get(polyclinicName); // Veritabanından o polikliniği getir

                    txtDesc.Text = poly.description;
                    chkStatus.Checked = poly.status;
                }
                else
                {
                    // Yoksa, oluşturma formu
                    txtDesc.Text = ""; // Formu eski hale getir
                    chkStatus.Checked = true; // Formu eski hale getir

                    changeVisible(true); // formu görünür yap
                    PolyclinicManager.Create(cbxPolyclinics.Text);

                    // Combobox'ı yenile
                    cbxPolyclinics.Items.Clear();
                    foreach (Polyclinic polyclinic in PolyclinicManager.All())
                    {
                        cbxPolyclinics.Items.Add(polyclinic.name);
                    }

                    // Düzenlenen poliklinik olarak yeni eklenen polikliniği seç
                    poly = PolyclinicManager.Get(polyclinicName);

                    refreshPolyclinics(); // Combobox'ı güncelle
                }
            }
        }
        // Güncelleme işlemi
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string oldName = poly.name; // Önceki ismi tut (güncellerken buna göre güncelleyeceğiz)
            // Seçilen poliklinik nesnesinin bilgilerini güncelle
            poly.name = cbxPolyclinics.Text;
            poly.description = txtDesc.Text;
            poly.status = chkStatus.Checked;

            // Veritabanında da bu işlemi yap
            Database.client.Cypher
                .Match("(polyclinic:Polyclinic)")
                .Where((Polyclinic polyclinic) => polyclinic.name == oldName)
                .Set("polyclinic = {poly}")
                .WithParam("poly", poly)
                .ExecuteWithoutResults();

            refreshPolyclinics(); // Combobox'ı güncelle (isim değişmiş olabilir)

            MessageBox.Show("Polyclinic successfully updated!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Program.DeleteConfirm("Do you want delete this polyclinic? The polyclinic's patient actions also be deleted."))
            {
                PolyclinicManager.Delete(poly); // Veritabanından polikliniği sil

                MessageBox.Show("Polyclinic successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refreshPolyclinics(); // Combobox'ı güncelle

                changeVisible(false); // formu gizle
                txtDesc.Text = ""; // formu boş hale al
                chkStatus.Checked = true; // formu boş hale al
                cbxPolyclinics.Text = ""; // Combobox'taki ismi sil
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PolyclinicScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.form = new MainScreen();
            Program.close = false;
        }
    }
}
