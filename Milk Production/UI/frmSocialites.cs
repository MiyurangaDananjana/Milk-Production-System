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
            soMemeber.Name=txtSoname.Text;
            soMemeber.SocietyId = (int)cmbSocit.SelectedValue;
            string message = soMemeber.newSocietyMemeber(soMemeber);
            MessageBox.Show(message);
            loadDataGrid();
        }

        protected void loadDataGrid()
        {
            string sql = "SELECT M.MEMBER_ID,M.MEMBER_NAME, S.NAME FROM MEMBER M JOIN SOCIETY S ON M.SOCIETY_ID = S.SOCIETY_ID ";
            DataSet dataSet = Data.GetData(sql);
            dataGridView1.DataSource = dataSet.Tables[0];
            dataGridView1.Columns["MEMBER_ID"].HeaderText = "අංකය";
            dataGridView1.Columns["MEMBER_NAME"].HeaderText = "සාමාජික නම";
            dataGridView1.Columns["NAME"].HeaderText = "සමිතියේ නම";

        }
    }
}
