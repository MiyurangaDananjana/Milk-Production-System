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
        }
        protected void loadData()
        {
           
            comboBox1.DisplayMember = "NAME";
            comboBox1.ValueMember = "SOCIETY_ID";

            string sql = "SELECT SOCIETY_ID,NAME FROM SOCIETY_TB";
            comboBox1.DataSource = Data.GetData(sql).Tables[0];
            comboBox1.Refresh();


        }
    }
}
