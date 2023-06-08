using Milk_Production.Resources;
using Milk_Production.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Milk_Production
{
    public partial class manager_UI : Form
    {
        public manager_UI()
        {
            InitializeComponent();
        }

        private void manager_UI_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            loadGrid();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            new_user frm = new new_user();
            frm.ShowDialog();
        }

        protected void loadGrid()
        {
            string sql = "SELECT * FROM InsertingAndCheckingTable";
            DataSet dataSet = Data.GetData(sql);
            dataGridView1.DataSource = dataSet.Tables[0];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExportExcel exportExcel = new ExportExcel();
            exportExcel.ExportToExcel(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmSociety frm = new frmSociety();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSocialites frm = new frmSocialites();
            frm.ShowDialog();
        }
    }
}
