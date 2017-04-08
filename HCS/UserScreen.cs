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
    public partial class UserScreen : Form
    {
        private User curUser;

        public UserScreen()
        {
            InitializeComponent();
        }

        private void changeVisible(bool visible)
        {
            lblName.Visible = visible;
            txtName.Visible = visible;
            lblSurname.Visible = visible;
            txtSurname.Visible = visible;
            lblPhone.Visible = visible;
            txtPhone.Visible = visible;
            lblTitle.Visible = visible;
            txtTitle.Visible = visible;
            lblPassword.Visible = visible;
            txtPassword.Visible = visible;
            chkAdmin.Visible = visible;
            btnDelete.Visible = visible;
            btnCreate.Visible = visible;
        }

        // Comboboxtaki kullanıcıları günceller
        private void refreshUsers()
        {
            cbxUsers.Items.Clear();
            // Combobox'ın içine veritabanından gelen Kullanıcıları dolduralım.
            foreach (User user in UserManager.All())
            {
                cbxUsers.Items.Add(user.username);
            }
        }

        private void UserScreen_Load(object sender, EventArgs e)
        {
            // Form açıldığında tüm form elementlerini gizle
            changeVisible(false);

            refreshUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = cbxUsers.Text;

            if (userName != "")
            {
                if (UserManager.Check(userName)) // Kullanıcı var mı diye kontrol et
                {
                    // Varsa, düzenleme formu
                    changeVisible(true); // formu görünür yap
                    curUser = UserManager.Get(userName); // Veritabanından o kullanıcıyı getir

                    txtName.Text = curUser.firstname;
                    txtSurname.Text = curUser.lastname;
                    txtPhone.Text = curUser.phone;
                    txtTitle.Text = curUser.title;
                    chkAdmin.Checked = curUser.admin;
                }
                else
                {
                    // Yoksa, oluşturma formu
                    txtName.Text = "";
                    txtSurname.Text = "";
                    txtPhone.Text = "";
                    txtTitle.Text = "";
                    chkAdmin.Checked = false;

                    changeVisible(true); // formu görünür yap
                    UserManager.Create(cbxUsers.Text);

                    // Combobox'ı yenile
                    cbxUsers.Items.Clear();
                    foreach (User user in UserManager.All())
                    {
                        cbxUsers.Items.Add(user.username);
                    }

                    // Düzenlenen kullanıcı olarak yeni eklenen kullanıcıyı seç
                    curUser = UserManager.Get(userName);

                    refreshUsers(); // Combobox'ı güncelle
                }
            }
        }

        // Güncelleme işlemi
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string oldUserName = curUser.username; // Önceki ismi tut (güncellerken buna göre güncelleyeceğiz)
            // Seçilen kullanıcı nesnesinin bilgilerini güncelle
            curUser.username = cbxUsers.Text;
            curUser.firstname = txtName.Text;
            curUser.lastname = txtSurname.Text;
            curUser.phone = txtPhone.Text;
            curUser.title = txtTitle.Text;
            curUser.admin = chkAdmin.Checked;
            if (txtPassword.Text != "")
            {
                curUser.password = txtPassword.Text;
            }

            // Veritabanında da bu işlemi yap
            Database.client.Cypher
                .Match("(user:User)")
                .Where((User user) => user.username == oldUserName)
                .Set("user = {curUser}")
                .WithParam("curUser", curUser)
                .ExecuteWithoutResults();

            refreshUsers(); // Combobox'ı güncelle (isim değişmiş olabilir)

            MessageBox.Show("User successfully updated!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Program.DeleteConfirm("Do you want delete this user?"))
            {
                UserManager.Delete(curUser); // Veritabanından kullanıcıyı sil

                MessageBox.Show("User successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refreshUsers(); // Combobox'ı güncelle

                changeVisible(false); // formu gizle
                cbxUsers.Text = ""; // Combobox'taki ismi sil
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UserScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.form = new MainScreen();
            Program.close = false;
        }
    }
}
