using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace Milk_Production.DAL
{
    public class Society_DAL
    {
        public static string SocietyId { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }


        public string SaveSociety()
        {
            string message = string.Empty;

            string sqlQuery = $"INSERT INTO SOCIETY (NAME,ADDRESS_LINE_1,ADDRESS_LINE_2) VALUES (N'{Name}',N'{AddressLine1}',N'{AddressLine2}') ";
            bool check = Data.ExecuteQuery(sqlQuery);
            if (check)
            {
                message = "සමිතියක් ඉවත් කිරීම සාර්තකයි";
                return message;
            }
            else
            {
                message = "සමිතියක් ඉවත් කිරීම අසාර්තකයි";
                return message;
            }

        }

        public string deleteSociety()
        {
            string sqlQurey = $"DELETE FROM SOCIETY WHERE SOCIETY_ID = '{SocietyId}';";

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
            string sqlQurey = $"UPDATE SOCIETY SET NAME = N'{Name}' ,ADDRESS_LINE_1=N'{AddressLine1}',ADDRESS_LINE_2=N'{AddressLine2}'  WHERE SOCIETY_ID ='{SocietyId}';";
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
