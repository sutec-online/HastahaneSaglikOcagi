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
    public partial class PatientScreen : Form
    {

        protected Patient patient;

        public PatientScreen(Patient patient)
        {
            this.patient = patient;
            InitializeComponent();
        }

        private void refreshActions()
        {
            decimal total = 0;
            dataGridView1.Rows.Clear();
            long patId = patient.id;
            foreach (var act in Database.client.Cypher.Match("(action:Action)-[:BELONGS_TO]-(patient:Patient), (action:Action)-[:BELONGS_TO]->(polyclinic:Polyclinic), (action:Action)-[:BELONGS_TO]->(doctor: Doctor)").Where((Patient patient) => patient.id == patId).Return((action, polyclinic, doctor) => new { Action = action.As<HCSLibrary.Action>(), Polyclinic = polyclinic.CollectAs<Polyclinic>(), Doctor = doctor.CollectAs<Doctor>() }).Results)
            {
                dataGridView1.Rows.Add(act.Polyclinic.Single().name, act.Action.order.ToString(), act.Action.dateTime.ToString(), act.Action.action, act.Doctor.Single().name, act.Action.quantity.ToString(), act.Action.price);
                total += decimal.Parse(act.Action.price) * act.Action.quantity;
            }
            lblTotalPrice.Text = total.ToString() + " TL";
        }

        private void PatientScreen_Load(object sender, EventArgs e)
        {
            Text = "HCS | " + patient.name + " " + patient.surname + "(" + patient.id + ") Patient Screen"; // Form'un ismini düzenle

            // Formdaki hasta bilgilerini getir
            txtName.Text = patient.name;
            txtSurname.Text = patient.surname;
            txtIdentity.Text = patient.identity;
            dtpShipment.Value = patient.shipment;
            chkDischarged.Checked = patient.is_discharged;

            // Action(İşlem) eklemedeki Policlinics ve Doctors comboboxlarını doldur.
            // Policlinic
            cbxPoliclinic.Items.Clear();
            foreach (Polyclinic polyclinic in PolyclinicManager.All())
            {
                cbxPoliclinic.Items.Add(polyclinic.name);
            }
            // Doctor
            cbxDoctor.Items.Clear();
            foreach (Doctor doctor in DoctorManager.All())
            {
                cbxDoctor.Items.Add(doctor.name);
            }

            refreshActions();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            long oldId = patient.id;

            // Formdaki girilen bilgilerle hasta nesnesini güncelle
            patient.name = txtName.Text;
            patient.surname = txtSurname.Text;
            patient.identity = txtIdentity.Text;
            patient.shipment = dtpShipment.Value;
            patient.is_discharged = chkDischarged.Checked;

            // Veritabanındaki hastayı güncelle
            Database.client.Cypher
                .Match("(patient:Patient)")
                .Where((Patient patient) => patient.id == oldId)
                .Set("patient = {patient}")
                .WithParam("patient", patient)
                .ExecuteWithoutResults();

            // Güncellendi mesajını göster
            MessageBox.Show("Patient successfully updated!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Program.DeleteConfirm("Do you want delete this patient? The patient's actions also be deleted."))
            {
                PatientManager.Delete(patient); // Veritabanından hasta sil

                MessageBox.Show("Patient successfully deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
        }
        private void btnDischarge_Click(object sender, EventArgs e)
        {
            long oldId = patient.id;

            // Hastanın taburcu durumunu değiştir
            patient.is_discharged = !patient.is_discharged;

            // Veritabanındaki hastayı güncelle
            Database.client.Cypher
                .Match("(patient:Patient)")
                .Where((Patient patient) => patient.id == oldId)
                .Set("patient = {patient}")
                .WithParam("patient", patient)
                .ExecuteWithoutResults();

            // Güncellendi mesajını göster
            MessageBox.Show("Patient discharge status successfully updated!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Checkbox'ı aç/kapa
            chkDischarged.Checked = patient.is_discharged;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string polyclinicName = cbxPoliclinic.Text;
            string doctorName = cbxDoctor.Text;
            if (cbxPoliclinic.SelectedIndex != -1 && cbxDoctor.SelectedIndex != -1 && cbxAction.SelectedIndex != -1 && txtPrice.Text != "")
            {
                Polyclinic policlinic = PolyclinicManager.Get(polyclinicName);
                Doctor doctor = DoctorManager.Get(doctorName);

                PatientManager.AddAction(patient, policlinic, doctor, nupOrder.Value, cbxAction.Text, nupQuantity.Value, txtPrice.Text);

                MessageBox.Show("Action successfully added!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refreshActions();
            }
        }

        Bitmap bmp;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
