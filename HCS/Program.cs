using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCS
{
    static class Program
    {

        public static Form form;
        public static bool close = true;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginScreen());

            while (!close)
            {
                close = true;
                Application.Run(form);
            }
        }

        public static bool DeleteConfirm(string text)
        {
            DialogResult result = MessageBox.Show(text, "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result == DialogResult.Yes;
        }
    }
}
