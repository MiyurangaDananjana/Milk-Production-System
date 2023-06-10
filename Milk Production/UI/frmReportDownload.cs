using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace Milk_Production.UI
{
    public partial class frmReportDownload : Form
    {
        public frmReportDownload()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string from = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string to = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                string query = $"SELECT SO.NAME,M.MEMBER_NAME, D.BTS, D.TS, D.SAMPLE_NO, D.GIVEN_MILK, D.LACATOR_METER_REDING_NUMBER, D.MILK_FAT, D.VALUE_PER_L, D.AMOUNT_PAID, MC.COLLECTOR_NAME, D.COLLECTING_DATE FROM DAILY_MILK_COLLECTION D JOIN MEMBER M ON D.MEMBER_ID = M.MEMBER_ID JOIN SOCIETY SO ON M.SOCIETY_ID = SO.SOCIETY_ID  JOIN MILK_COLLECTOR MC ON D.COLLECTOR_ID = MC.MILK_COLLECTOR_ID WHERE D.COLLECTING_DATE BETWEEN '{from}' AND '{to}'";

                DataSet dataSet = Data.GetData(query);

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                    // Custom column headers
                    string[] columnHeaders = { "සමිතියේ නම", "සාමාජිකයාගේ නම", "BTS", "TS", " සාම්පල් අංකය", " ලබා දුන් කිරි ප්රමාණය.", "ක්ෂෙත්‍ර ලැක්‍ට‍ො මීටර් පාඨාංකය", "මේදය (%)", "ලිටරයක වටිනාකම", "ගෙවන මුදල", "එකතුකරන්නාගේ නම", "දිනය" };

                    // Write custom column headers
                    for (int col = 0; col < columnHeaders.Length; col++)
                    {
                        worksheet.Cells[1, col + 1].Value = columnHeaders[col];
                    }

                    // Write data rows
                    for (int row = 0; row < dataSet.Tables[0].Rows.Count; row++)
                    {
                        for (int col = 0; col < dataSet.Tables[0].Columns.Count; col++)
                        {
                            if (dataSet.Tables[0].Columns[col].DataType == typeof(DateTime) && !dataSet.Tables[0].Rows[row].IsNull(col))
                            {
                                DateTime dateValue = (DateTime)dataSet.Tables[0].Rows[row][col];
                                string dateAsString = dateValue.ToShortDateString();
                                worksheet.Cells[row + 2, col + 1].Value = dateAsString;
                            }
                            else
                            {
                                worksheet.Cells[row + 2, col + 1].Value = dataSet.Tables[0].Rows[row][col];
                            }
                        }
                    }

                    string dateTimeNow = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    FileInfo excelFile = new FileInfo($"output-{dateTimeNow}.xlsx");

                    excelPackage.SaveAs(excelFile);
                    MessageBox.Show("Successfully saved");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
