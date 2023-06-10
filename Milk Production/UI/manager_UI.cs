using Milk_Production.DAL;
using Milk_Production.Resources;
using Milk_Production.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
            loadSociety();
            DateTime dateTime = DateTime.Now;
            string dateFormat = "yyyy/MM/dd";
            string formateDate = dateTime.ToString(dateFormat);
            txtDate.Text = formateDate;

            string timeFormat = "hh:mm tt";
            string formateTime = dateTime.ToString(timeFormat);
            txtTime.Text = formateTime;
            loadCollector();
            loadDataGrid();

        }


        protected void loadSociety()
        {
            try
            {
                cmbSocite.DisplayMember = "NAME";
                cmbSocite.ValueMember = "SOCIETY_ID";
                string sql = "SELECT * FROM SOCIETY";
                cmbSocite.DataSource = Data.GetData(sql).Tables[0];
                cmbSocite.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new_user frm = new new_user();
            frm.ShowDialog();
        }

        protected void loadGrid()
        {
            try
            {
                string sql = "SELECT * FROM InsertingAndCheckingTable";
                DataSet dataSet = Data.GetData(sql);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


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



        private void cmbSocite_Click(object sender, EventArgs e)
        {
            int selectionValue = (int)cmbSocite.SelectedValue;
            loadMember(selectionValue);
        }

        private void loadMember(int id)
        {


            try
            {
                cmbMemeber.DisplayMember = "MEMBER_NAME";
                cmbMemeber.ValueMember = "MEMBER_ID";
                string sql = $"SELECT MEMBER_ID,MEMBER_NAME FROM MEMBER WHERE SOCIETY_ID = {id};";
                cmbMemeber.DataSource = Data.GetData(sql).Tables[0];
                cmbMemeber.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmCollector frm = new frmCollector();
            frm.ShowDialog();
        }

        protected void loadCollector()
        {
            try
            {
                cmbCollector.DisplayMember = "COLLECTOR_NAME";
                cmbCollector.ValueMember = "MILK_COLLECTOR_ID";
                string sql = $"SELECT * FROM MILK_COLLECTOR";
                cmbCollector.DataSource = Data.GetData(sql).Tables[0];
                cmbCollector.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }

        }

        protected void loadDataGrid()
        {
            try
            {
                string sql = "SELECT ID,SO.NAME,M.MEMBER_NAME,D.BTS,D.TS,D.SAMPLE_NO,D.GIVEN_MILK,D.LACATOR_METER_REDING_NUMBER,D.MILK_FAT,D.VALUE_PER_L,D.AMOUNT_PAID, MC.COLLECTOR_NAME,D.COLLECTING_DATE,D.COLLECTING_TIME  FROM DAILY_MILK_COLLECTION D JOIN MEMBER M ON D.MEMBER_ID = M.MEMBER_ID JOIN SOCIETY SO ON M.SOCIETY_ID = SO.SOCIETY_ID  JOIN MILK_COLLECTOR MC ON D.COLLECTOR_ID = MC.MILK_COLLECTOR_ID\r\n";
                DataSet dataSet = Data.GetData(sql);
                dataGridView1.DataSource = dataSet.Tables[0];
                dataGridView1.Columns["NAME"].HeaderText = "සමිතියේ නම";
                dataGridView1.Columns["MEMBER_NAME"].HeaderText = "සාමාජිකයාගේ නම";
                dataGridView1.Columns["BTS"].HeaderText = "BTS";
                dataGridView1.Columns["TS"].HeaderText = "TS";
                dataGridView1.Columns["SAMPLE_NO"].HeaderText = "සාම්පල අංකය";
                dataGridView1.Columns["GIVEN_MILK"].HeaderText = "ලබාදුන් කිරි ප්‍රමාණය(ලීටර්)";
                dataGridView1.Columns["LACATOR_METER_REDING_NUMBER"].HeaderText = "ක්ෂෙත්‍ර ලැක්‍ට‍ො මීටර් පාඨාංකය";
                dataGridView1.Columns["MILK_FAT"].HeaderText = "මේදය (%)";
                dataGridView1.Columns["VALUE_PER_L"].HeaderText = "ලිටරයක වටිනාකම";
                dataGridView1.Columns["AMOUNT_PAID"].HeaderText = "වටිනාකම";
                dataGridView1.Columns["COLLECTOR_NAME"].HeaderText = "එකතුකරන්නාගේ නම";
                dataGridView1.Columns["COLLECTING_DATE"].HeaderText = "දිනය";
                dataGridView1.Columns["COLLECTING_TIME"].HeaderText = "ට්‍රක්  රථයට කිරි භාර දුන් වේලාව";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            dailyMilkCollection milkCollection = new dailyMilkCollection();

            // Validate and assign values from inputs
            if (cmbMemeber.SelectedValue != null && int.TryParse(cmbMemeber.SelectedValue.ToString(), out int memberId))
            {
                milkCollection.MemberID = memberId;
            }
            else
            {
                MessageBox.Show("වලංගු නොවන සාමාජික ID.");
                return;
            }

            if (decimal.TryParse(txtBts.Text, out decimal bts))
            {
                milkCollection.BTS = bts;
            }
            else
            {
                MessageBox.Show("වලංගු නොවන BTS අගය.");
                return;
            }

            // Similarly, perform validation for other input fields

            // Check if any required fields are empty
            if (string.IsNullOrEmpty(txtBts.Text) || string.IsNullOrEmpty(txtTs.Text) || string.IsNullOrEmpty(txtSampleNumber.Text)
                || string.IsNullOrEmpty(txtGivenMilk.Text) || string.IsNullOrEmpty(txtlrNumber.Text) || string.IsNullOrEmpty(txtFat.Text)
                || string.IsNullOrEmpty(txtValuePerLiter.Text) || string.IsNullOrEmpty(txtAmount.Text) || string.IsNullOrEmpty(txtDate.Text)
                || string.IsNullOrEmpty(txtTime.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Assign values to the milkCollection object
            milkCollection.TS = Convert.ToDecimal(txtTs.Text);
            milkCollection.SampleNo = Convert.ToInt32(txtSampleNumber.Text);
            milkCollection.GivenMilk = Convert.ToDecimal(txtGivenMilk.Text);
            milkCollection.LactometerReadingNumber = Convert.ToInt32(txtlrNumber.Text);
            milkCollection.MilkFat = Convert.ToInt32(txtFat.Text);
            milkCollection.ValuePerLiter = Convert.ToDecimal(txtValuePerLiter.Text);
            milkCollection.AmountPaid = Convert.ToDecimal(txtAmount.Text);

            if (cmbCollector.SelectedValue != null && int.TryParse(cmbCollector.SelectedValue.ToString(), out int collectorId))
            {
                milkCollection.collectorId = collectorId;
            }
            else
            {
                MessageBox.Show("වලංගු නොවන එකතුකරන්නාගේ ID.");
                return;
            }

            if (DateTime.TryParse(txtDate.Text, out DateTime collectionDate))
            {
                milkCollection.CollectionDate = collectionDate;
            }
            else
            {
                MessageBox.Show("වලංගු නොවන එකතු කිරීමේ දිනය.");
                return;
            }

            if (DateTime.TryParse(txtTime.Text, out DateTime collectionTime))
            {
                milkCollection.CollectionTime = collectionTime;
            }
            else
            {
                MessageBox.Show("වලංගු නොවන එකතු කිරීමේ කාලය.");
                return;
            }

            // Generate the insertQuery
            string insertQuery = milkCollection.CreateInsertQuery(milkCollection);
            loadDataGrid();
            MessageBox.Show(insertQuery);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmReportDownload frm = new frmReportDownload();
            frm.ShowDialog();
        }


      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
            if (e.RowIndex > 0) // Ensure a valid row index
            {

                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                dailyMilkCollection.ID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
                cmbSocite.Text = selectedRow.Cells["NAME"].Value.ToString();
                cmbMemeber.Text = selectedRow.Cells["MEMBER_NAME"].Value.ToString();
                txtBts.Text = selectedRow.Cells["BTS"].Value.ToString();
                txtTs.Text = selectedRow.Cells["TS"].Value.ToString();
                txtSampleNumber.Text = selectedRow.Cells["SAMPLE_NO"].Value.ToString();
                txtGivenMilk.Text = selectedRow.Cells["GIVEN_MILK"].Value.ToString();
                txtlrNumber.Text = selectedRow.Cells["LACATOR_METER_REDING_NUMBER"].Value.ToString();
                txtFat.Text = selectedRow.Cells["MILK_FAT"].Value.ToString();
                txtValuePerLiter.Text = selectedRow.Cells["VALUE_PER_L"].Value.ToString();
                txtAmount.Text = selectedRow.Cells["AMOUNT_PAID"].Value.ToString();
                cmbCollector.Text = selectedRow.Cells["COLLECTOR_NAME"].Value.ToString();
                txtDate.Text = DateTime.Parse(selectedRow.Cells["COLLECTING_DATE"].Value.ToString()).ToString("yyyy/MM/dd");
                txtTime.Text = selectedRow.Cells["COLLECTING_TIME"].Value.ToString();

            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            dailyMilkCollection milkCollection = new dailyMilkCollection();

            // Validate and assign values from inputs
            if (cmbMemeber.SelectedValue != null && int.TryParse(cmbMemeber.SelectedValue.ToString(), out int memberId))
            {
                milkCollection.MemberID = memberId;
            }
            else
            {
                MessageBox.Show("වලංගු නොවන සාමාජික ID.");
                return;
            }

            if (decimal.TryParse(txtBts.Text, out decimal bts))
            {
                milkCollection.BTS = bts;
            }
            else
            {
                MessageBox.Show("වලංගු නොවන BTS අගය.");
                return;
            }

            // Similarly, perform validation for other input fields

            // Check if any required fields are empty
            if (string.IsNullOrEmpty(txtBts.Text) || string.IsNullOrEmpty(txtTs.Text) || string.IsNullOrEmpty(txtSampleNumber.Text)
                || string.IsNullOrEmpty(txtGivenMilk.Text) || string.IsNullOrEmpty(txtlrNumber.Text) || string.IsNullOrEmpty(txtFat.Text)
                || string.IsNullOrEmpty(txtValuePerLiter.Text) || string.IsNullOrEmpty(txtAmount.Text) || string.IsNullOrEmpty(txtDate.Text)
                || string.IsNullOrEmpty(txtTime.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Assign values to the milkCollection object
            milkCollection.TS = Convert.ToDecimal(txtTs.Text);
            milkCollection.SampleNo = Convert.ToInt32(txtSampleNumber.Text);
            milkCollection.GivenMilk = Convert.ToDecimal(txtGivenMilk.Text);
            milkCollection.LactometerReadingNumber = Convert.ToInt32(txtlrNumber.Text);
            milkCollection.MilkFat = Convert.ToInt32(txtFat.Text);
            milkCollection.ValuePerLiter = Convert.ToDecimal(txtValuePerLiter.Text);
            milkCollection.AmountPaid = Convert.ToDecimal(txtAmount.Text);

            if (cmbCollector.SelectedValue != null && int.TryParse(cmbCollector.SelectedValue.ToString(), out int collectorId))
            {
                milkCollection.collectorId = collectorId;
            }
            else
            {
                MessageBox.Show("වලංගු නොවන එකතුකරන්නාගේ ID.");
                return;
            }

            if (DateTime.TryParse(txtDate.Text, out DateTime collectionDate))
            {
                milkCollection.CollectionDate = collectionDate;
            }
            else
            {
                MessageBox.Show("වලංගු නොවන එකතු කිරීමේ දිනය.");
                return;
            }

            if (DateTime.TryParse(txtTime.Text, out DateTime collectionTime))
            {
                milkCollection.CollectionTime = collectionTime;
            }
            else
            {
                MessageBox.Show("වලංගු නොවන එකතු කිරීමේ කාලය.");
                return;
            }

            // Generate the updateQuery
            string updateQuery = milkCollection.CreateUpdateQuery(milkCollection);
            loadDataGrid();
            MessageBox.Show(updateQuery);

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            dailyMilkCollection dailyMilkCollection = new dailyMilkCollection();
            string message = dailyMilkCollection.deletedailyMilkCollection();
            MessageBox.Show(message);
        }
    }
}
