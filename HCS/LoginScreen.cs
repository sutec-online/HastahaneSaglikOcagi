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
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Kullanıcı adını ve şifreyi kontrol ettir...
            if(Auth.Attempt(txtUsername.Text, txtPassword.Text)) {
                // Kullanıcı adı ve şifre doğru ise MainScreen() ekranını açtır
                Program.form = new MainScreen();
                Program.close = false;
                Close();
            } else{
                // Kullanıcı adı ve şifre hatalıysa mesaj göster.
                MessageBox.Show("Username or password is wrong!", "Authentication Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close(); // Programı kapat
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            // Veritabanı bağlantısını gerçekleştirmeden önce kullanıcının giriş yapmaması için butonu pasifleştir.
            btnLogin.Enabled = false;

            // Veritabanına bağlanana kadar dene...
            bool connected = false;
            while(!connected)
            {
                // Veritabanı bağlantısını gerçekleştir.
                if (Database.Connect("http://localhost:7474/db/data", "neo4j", "seymasa"))
                {
                    // Veritabanı bağlantısından sonra butonu tekrardan aktifleştir.
                    btnLogin.Enabled = true;
                    connected = true;
                }
                else
                {
                    // Veritabanı bağlantısı kurulamadığı için hata göster.
                    DialogResult result = MessageBox.Show("Unable to connect to the Neo4J Database.", "Database Connection Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        connected = false; // Bağlantı başarısız, tekrar dene...
                    } else
                    {
                        connected = true;
                        Close(); // Kullanıcı 'İptal' butonuna bastıysa artık denemekten vazgeç ve formu kapat...
                    }
                }
            }
        }
    }
}
