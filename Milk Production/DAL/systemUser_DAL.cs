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
        public static int userId { get; set; }
        public string name { get; set; }
        public int password { get; set; }
        public int userRole { get; set; }
        public int createBy { get; set; }
        public DateTime createDate { get; set; }
        public string message = string.Empty;


        public string SaveNewUser()
        {
  
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

        public string UpdateUserData()
        {
    
            if (userId == 0)
            {
                message = "පරිශීලක තෝරන්න";
            }
   
            string sqlQuery = $"UPDATE LOGIN SET USER_NAME='N{name}', PASSWORD='{password}' WHERE USER_ID = '{userId}' ";
            bool check = Data.ExecuteQuery(sqlQuery);
            if (check)
            {
                message = "පරිශීලක යවත්කාලීන කිරීම සාර්තකයි";
                return message;
            }
            else
            {
                message = "Faile";
                return message;
            }
        }

        public string DeleteUser()
        {
            if (userId == 0)
            {
                message = "පරිශීලක තෝරන්න";
            }

            string sqlQuery = $"DELETE FROM LOGIN WHERE USER_ID='{userId}'";
            bool check = Data.ExecuteQuery(sqlQuery);
            if (check)
            {
                message = "SUCCESS";
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
