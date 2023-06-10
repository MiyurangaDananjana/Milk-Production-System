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
    public partial class frmCollector : Form
    {
        public frmCollector()
        {
            InitializeComponent();
        }

        private void frmCollector_Load(object sender, EventArgs e)
        {
            loadData();
        }

        protected void loadData()
        {
            string sql = "SELECT * FROM MILK_COLLECTOR ";
            DataSet dataSet = Data.GetData(sql);
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                dataGridView1.DataSource = dataSet.Tables[0];
                dataGridView1.Columns["MILK_COLLECTOR_ID"].HeaderText = "අංකය";
                dataGridView1.Columns["COLLECTOR_NAME"].HeaderText = "සාමාජික නම";
            }
            else
            {
                MessageBox.Show("Error occurred while retrieving data from the database.");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SocietyMember soMemeber = new SocietyMember();
            soMemeber.Name = txtSoname.Text;
            if (string.IsNullOrEmpty(txtSoname.Text))
            {
                MessageBox.Show("Textbox is empty. Please enter the value");
            }
            else
            {
                string message = soMemeber.saveNewCollector(soMemeber);
                MessageBox.Show(message);
                loadData();
            }

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SocietyMember soMemeber = new SocietyMember();
            soMemeber.Name = txtSoname.Text;
            if (string.IsNullOrEmpty(txtSoname.Text))
            {
                MessageBox.Show("Textbox is empty. Please enter the value");
            }
            else
            {
                string message = soMemeber.updateCollector(soMemeber);
                MessageBox.Show(message);
                loadData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0) 
            {

                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                SocietyMember.Id = Convert.ToInt32(selectedRow.Cells["MILK_COLLECTOR_ID"].Value);
                txtSoname.Text = selectedRow.Cells["COLLECTOR_NAME"].Value.ToString();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SocietyMember societyMember = new SocietyMember();
            societyMember.deleteCollector(societyMember);
        }
    }
}
