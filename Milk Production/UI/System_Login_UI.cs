using Milk_Production.DAL;
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
            try
            {
                string userName = txtUserName.Text;
                string password =  passwordHash.passHash(txtPassword.Text);

                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("කරුණාකර පරිශීලක නාමය සහ මුරපදය යන දෙකම ඇතුළත් කරන්න.");
                }
                else
                {
                    AppConttroler app = new AppConttroler();
                    int login = app.login(userName, password);
                    if (login == (int)UserRole.Admin)
                    {
                        manager_UI ui = new manager_UI();
                        ui.button1.Enabled = false;
                        this.Hide();
                        ui.ShowDialog();
                    }
                    else if (login == (int)UserRole.User)
                    {
                        this.Close();
                        manager_UI ui = new manager_UI();
                        ui.BtnDelete.Enabled = false;
                        ui.BtnUpdate.Enabled = false;
                        ui.btnNewUser.Enabled = false;
                        ui.btnReportDownload.Enabled = false;
                        this.Hide();
                        ui.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("වලංගු නොවන පරිශීලක නාමයක් හෝ මුරපදයක්!");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }
           
        }

        private void System_Login_UI_Load(object sender, EventArgs e)
        {
            //lblconnectioncheck.Text = Data.checkConnection();
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }
    }
}
