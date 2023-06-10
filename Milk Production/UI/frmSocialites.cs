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

namespace Milk_Production.UI
{
    public partial class frmSocialites : Form
    {
        public frmSocialites()
        {
            InitializeComponent();
        }

        private void frmSocialites_Load(object sender, EventArgs e)
        {
            loadData();
            loadDataGrid();
        }
        protected void loadData()
        {

            cmbSocit.DisplayMember = "NAME";
            cmbSocit.ValueMember = "SOCIETY_ID";
            string sql = "SELECT SOCIETY_ID,NAME FROM SOCIETY";
            cmbSocit.DataSource = Data.GetData(sql).Tables[0];
            cmbSocit.Refresh();


        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SocietyMember soMemeber = new SocietyMember();
            soMemeber.Name = txtSoname.Text;

            // Check if the textbox is empty
            if (string.IsNullOrEmpty(soMemeber.Name))
            {
                MessageBox.Show("Please enter a value for the Name textbox.");
                return;
            }

            // Check if the selected value is null or empty
            if (cmbSocit.SelectedValue == null || cmbSocit.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Please select a value for the Society combobox.");
                return;
            }

            soMemeber.SocietyId = (int)cmbSocit.SelectedValue;
            string message = soMemeber.newSocietyMemeber(soMemeber);
            MessageBox.Show(message);
            loadDataGrid();

        }

        protected void loadDataGrid()
        {
            string sql = "SELECT M.MEMBER_ID, M.MEMBER_NAME, S.NAME FROM MEMBER M JOIN SOCIETY S ON M.SOCIETY_ID = S.SOCIETY_ID";
            DataSet dataSet = Data.GetData(sql);

            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                dataGridView1.DataSource = dataSet.Tables[0];
                dataGridView1.Columns["MEMBER_ID"].HeaderText = "අංකය";
                dataGridView1.Columns["MEMBER_NAME"].HeaderText = "සාමාජික නම";
                dataGridView1.Columns["NAME"].HeaderText = "සමිතියේ නම";
            }
            else
            {
                MessageBox.Show("Error occurred while retrieving data from the database.");
            }


        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SocietyMember societyMember = new SocietyMember();
            societyMember.Name = txtSoname.Text;
            societyMember.SocietyId = (int)cmbSocit.SelectedValue;

            // Check if any required fields are empty
            if (string.IsNullOrWhiteSpace(societyMember.Name))
            {
                MessageBox.Show("Please enter a valid name.");
                return;
            }

            string message = societyMember.updateSocietyMemeber(societyMember);
            loadDataGrid();
            MessageBox.Show(message);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                SocietyMember.Id = Convert.ToInt32(selectedRow.Cells["MEMBER_ID"].Value);
                txtSoname.Text = selectedRow.Cells["MEMBER_NAME"].Value.ToString();
                cmbSocit.Text = selectedRow.Cells["NAME"].Value.ToString();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SocietyMember societyMember = new SocietyMember();
            string message = societyMember.deleteSocietyMemeber();
            MessageBox.Show(message);   



        }
    }
}
