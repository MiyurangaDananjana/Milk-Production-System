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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Milk_Production.UI
{
    public partial class new_user : Form
    {
        public new_user()
        {
            InitializeComponent();
        }

        private void new_user_Load(object sender, EventArgs e)
        {
            getUserData();
            loadData();
        }
        protected void getUserData()
        {
            string sql = "SELECT L.USER_ID,L.USER_NAME,U.USER_ROLE,L.CREATE_DATE FROM LOGIN L JOIN USER_ROLE U ON L.USER_ROLE = U.USER_ROLE_ID;";
            DataSet dataSet = Data.GetData(sql);
            dataGridView1.DataSource = dataSet.Tables[0];
            dataGridView1.Columns["USER_NAME"].HeaderText = "පරිශීලක හදුනා ගැනිමේ කේතය";
            dataGridView1.Columns["USER_NAME"].HeaderText = "පරිශීලකයගේ නම";
            dataGridView1.Columns["USER_ROLE"].HeaderText = "කාර්යභාරය";
            dataGridView1.Columns["CREATE_DATE"].HeaderText = "ඇතුලත් කල දිනය";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if(txtPassword.Text == txtRePassword.Text)
            {
                
                systemUser_DAL dal = new systemUser_DAL();
                dal.name = txtName.Text;
                dal.password = passwordHash.passHash(txtPassword.Text);
                dal.userRole = (int)cmbRole.SelectedValue;
                dal.createDate = DateTime.Now;
                string message = dal.SaveNewUser();
                loadData();
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Password Not match");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text == txtRePassword.Text)
            {
                systemUser_DAL dal = new systemUser_DAL();
                dal.name = txtName.Text;
                dal.name = txtPassword.Text;
               string message= dal.UpdateUserData();
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Password dose not match");
            }
          
        }

        protected void loadData()
        {
            cmbRole.DisplayMember = "USER_ROLE";
            cmbRole.ValueMember = "USER_ROLE_ID";
            string sql = "SELECT * FROM USER_ROLE";
            cmbRole.DataSource = Data.GetData(sql).Tables[0];
            cmbRole.Refresh();


        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row index
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                systemUser_DAL.userId = Convert.ToInt32(selectedRow.Cells["USER_ID"].Value.ToString());
                txtName.Text = selectedRow.Cells["USER_NAME"].Value.ToString();
                cmbRole.Text = selectedRow.Cells["USER_ROLE"].Value.ToString();
            }
           
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(systemUser_DAL.userId == 0)
            {
                MessageBox.Show("Select the user");

            }
            else
            {
                systemUser_DAL dal = new systemUser_DAL();
                string message = dal.DeleteUser();
                MessageBox.Show(message);
            }
        }
    }
}
