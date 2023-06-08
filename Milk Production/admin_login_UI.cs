using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milk_Production
{
    public partial class admin_login_UI : Form
    {
        public admin_login_UI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            AppConttroler app = new AppConttroler();

            bool loginResult = app.systemLogin(userName, password);
            if (loginResult)
            {
                manager_UI ui = new manager_UI();
                this.Close();
                ui.Show();

            }
            else
            {
                MessageBox.Show("Check user name and password !");
            }
        }
    }
}
