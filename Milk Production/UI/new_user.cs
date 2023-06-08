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
    public partial class new_user : Form
    {
        public new_user()
        {
            InitializeComponent();
        }

        private void new_user_Load(object sender, EventArgs e)
        {
            getUserData();
        }
        protected void getUserData()
        {
            string sql = "SELECT * FROM Admin_Login";
            DataSet dataSet = Data.GetData(sql);
            dataGridView1.DataSource = dataSet.Tables[0];
        }
    }
}
