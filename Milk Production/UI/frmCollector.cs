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
            dataGridView1.DataSource = dataSet.Tables[0];

            dataGridView1.Columns["MILK_COLLECTOR_ID"].HeaderText = "අංකය";
            dataGridView1.Columns["COLLECTOR_NAME"].HeaderText = "සාමාජික නම";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SocietyMember soMemeber = new SocietyMember();
            soMemeber.Name = txtSoname.Text;
            string message = soMemeber.saveNewCollector(soMemeber);
            MessageBox.Show(message);
            loadData();
        }
    }
}
