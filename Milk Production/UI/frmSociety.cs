using Milk_Production.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Milk_Production.UI
{
    public partial class frmSociety : Form
    {
        public frmSociety()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtSoname.Text != null && txtAddressLine1 != null)
            {
                Society_DAL dal = new Society_DAL();
                dal.Name = txtSoname.Text;
                dal.AddressLine1 = txtAddressLine1.Text;
                dal.AddressLine2 = txtAddressLine2.Text;
                string message = dal.SaveSociety();
                loadGrid();
                clearTextBox();
                MessageBox.Show($"{message}");
            }
            else
            {
                MessageBox.Show("Check the textbox");
            }




        }
        protected void clearTextBox()
        {
            txtSoname.Text = string.Empty;
            txtAddressLine1.Text = string.Empty;
            txtAddressLine2.Text = string.Empty;
        }

        private void frmSociety_Load(object sender, EventArgs e)
        {
            loadGrid();
            clearTextBox();

        }

        protected void loadGrid()
        {
            string sql = "SELECT * FROM SOCIETY";
            DataSet dataSet = Data.GetData(sql);
            dataGridView1.DataSource = dataSet.Tables[0];

            dataGridView1.Columns["SOCIETY_ID"].HeaderText = "සමිති කේතය";
            dataGridView1.Columns["NAME"].HeaderText = "සමිතියේ නම";
            dataGridView1.Columns["ADDRESS_LINE_1"].HeaderText = "ලිපින පේලි 1";
            dataGridView1.Columns["ADDRESS_LINE_2"].HeaderText = "ලිපින පේලි 2";
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0) // Ensure a valid row index
            {

                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                Society_DAL.SocietyId = selectedRow.Cells["SOCIETY_ID"].Value.ToString();
                txtSoname.Text = selectedRow.Cells["NAME"].Value.ToString();
                txtAddressLine1.Text = selectedRow.Cells["ADDRESS_LINE_1"].Value.ToString();
                txtAddressLine2.Text = selectedRow.Cells["ADDRESS_LINE_2"].Value.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Society_DAL dal = new Society_DAL();
            string message = dal.deleteSociety();
            loadGrid();
            MessageBox.Show($"{message}");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (Society_DAL.SocietyId != null)
            {
                Society_DAL dal = new Society_DAL();
                dal.Name = txtSoname.Text;
                dal.AddressLine1 = txtAddressLine1.Text;
                dal.AddressLine2 = txtAddressLine2.Text;

                string message = dal.updateSociety();
                loadGrid();
                MessageBox.Show($"{message}");

            }
            else
            {
                MessageBox.Show("Please Select !");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
