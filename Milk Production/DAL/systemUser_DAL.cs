using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milk_Production.DAL
{
    public class systemUser_DAL
    {
        public int userId { get; set; }
        public string name { get; set; }
        public int password { get; set; }
        public int userRole { get; set; }
        public int createBy { get; set; }
        public DateTime createDate { get; set; }


        public string SaveNewUser()
        {
            string message = string.Empty;
            string sqlQuery = $"INSERT INTO LOGIN (USER_NAME,PASSWORD,USER_ROLE,CREATE_DATE) VALUES (N'{name}','{password}','{userRole}','{createDate}');";
            bool check = Data.ExecuteQuery(sqlQuery);
            if (check)
            {
                message = "Success";
                return message;
            }
            else
            {
                message = "Faile";
                return message;
            }
        } 
    }
}
