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
    public partial class System_Login_UI : Form
    {
        public System_Login_UI()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            AppConttroler app = new AppConttroler();

            int login = app.login(userName, password);
            if (login == (int)UserRole.Admin)
            {
                manager_UI ui = new manager_UI();
                this.Hide();
                ui.button1.Enabled = false;
                ui.Show();

            }
            else if (login == (int)UserRole.User)
            {
                manager_UI ui = new manager_UI();
                this.Hide();
                ui.BtnDelete.Enabled = false;
                ui.BtnDeleteAll.Enabled = false;
                ui.BtnUpdate.Enabled = false;
                ui.Show();

            }
            else
            {
                MessageBox.Show("Check user name and password !");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void System_Login_UI_Load(object sender, EventArgs e)
        {

        }
    }
}
