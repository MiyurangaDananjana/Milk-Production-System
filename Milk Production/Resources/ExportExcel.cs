using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milk_Production.Resources
{
    public class ExportExcel
    {
        public void ExportToExcel(DataGridView dataGridView)
        {
            // Create an Excel application object
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            // Create a new workbook
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add();

            // Create a new worksheet
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Sheets[1];

            try
            {
                int columnIndex = 1;
                int rowIndex = 1;

                // Export column headers
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    worksheet.Cells[rowIndex, columnIndex] = column.HeaderText;
                    columnIndex++;
                }

                rowIndex++;

                // Export data rows
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    columnIndex = 1;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        worksheet.Cells[rowIndex, columnIndex] = cell.Value;
                        columnIndex++;
                    }

                    rowIndex++;
                }

                string date = DateTime.Now.ToString("yyyy-MM-dd");
                string time = DateTime.Now.ToString("HH-mm-ss");
                // Save the workbook
                workbook.SaveAs($"YourFilePath_{date}_{time}.xlsx");
                MessageBox.Show("Export seccess check the Document file");
            }
            catch (Exception ex)
            {
           
                MessageBox.Show("Error exporting to Excel: " + ex.Message);
            }
            finally
            {
                // Clean up resources
                workbook.Close();
                excelApp.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                worksheet = null;
                workbook = null;
                excelApp = null;

                GC.Collect();
            }
        }
    }
}
