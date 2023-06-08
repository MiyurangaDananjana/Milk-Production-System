using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Milk_Production.DAL
{
    public class Society_DAL
    {
        public static string SocietyId { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public static string cs = ConfigurationManager.ConnectionStrings["dbcon"].ToString();

        public string SaveSociety()
        {
            string message = string.Empty;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("SOCIETY_TB_PROC", connection))
                {
                    try
                    {
                        // Set command type as stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the command
                        command.Parameters.Add("@SOCIETY_ID", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                        command.Parameters.Add("@NAME", SqlDbType.NVarChar, 100).Value = Name;
                        command.Parameters.Add("@ADDRESS_LINE_1", SqlDbType.NVarChar, 100).Value = AddressLine1;
                        command.Parameters.Add("@ADDRESS_LINE_2", SqlDbType.NVarChar, 100).Value = AddressLine2;

                        // Open the connection
                        connection.Open();

                        // Execute the stored procedure
                        command.ExecuteNonQuery();

                        // Retrieve the output value of @SOCIETY_ID parameter
                        SocietyId = command.Parameters["@SOCIETY_ID"].Value.ToString();

                        message = "නව සමිතියක් ඇතුලත් කිරීම සාර්තකයි";
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                        // Handle the exception as needed
                    }
                }
            }
            return message;
        }

        public string deleteSociety()
        {
            string sqlQurey = $"DELETE FROM SOCIETY_TB WHERE SOCIETY_ID = '{SocietyId}';";

            string Message = string.Empty;

            bool check = Data.ExecuteQuery(sqlQurey);
            if (check)
            {
                Message = "සමිතියක් ඉවත් කිරීම සාර්තකයි";
                return Message;
            }
            else
            {
                Message = "සමිතියක් ඉවත් කිරීම අසාර්තකයි";
                return Message;
            }
        }

        public string updateSociety()
        {
            string sqlQurey = $"UPDATE SOCIETY_TB SET NAME = N'{Name}' ,ADDRESS_LINE_1=N'{AddressLine1}',ADDRESS_LINE_2=N'{AddressLine2}'  WHERE SOCIETY_ID ='{SocietyId}';";
            string Message = string.Empty;
            bool check = Data.ExecuteQuery(sqlQurey);
            if (check)
            {
                Message = "සමිතියක් යාවත්කාලින කිරීම සාර්තකයි";
                SocietyId = string.Empty;
                return Message;
            }
            else
            {
                Message = "සමිතියක් යාවත්කාලින කිරීම අසාර්තකයි";
                return Message;
            }
        }
    }

}
