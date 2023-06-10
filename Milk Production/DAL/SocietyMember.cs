using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milk_Production.DAL
{
    public class SocietyMember
    {
        public static int Id { get; set; }
        public string Name { get; set; }
        public int SocietyId { get; set; }



        public string newSocietyMemeber(SocietyMember society)
        {
          
            string sqlQuery = $"INSERT INTO MEMBER (MEMBER_NAME,SOCIETY_ID) VALUES (N'{society.Name}',N'{society.SocietyId}') ";
            bool check = Data.ExecuteQuery(sqlQuery);
            return check ? "නව සාමජිකයෙක් ඇතුලත් කිරිම සාර්තකයි" : "නව සාමජිකයෙක් ඇතුලත් කිරිම අසාර්තකයි";

        }

        public string updateSocietyMemeber(SocietyMember society)
        {

            // Check if the member ID is valid
            if (Id == 0)
            {
                return "Invalid Member ID. Please provide a valid value.";
            }

            string sqlQuery = $"UPDATE MEMBER SET MEMBER_NAME = N'{society.Name}', SOCIETY_ID = '{society.SocietyId}' WHERE MEMBER_ID = {Id}";
            bool check = Data.ExecuteQuery(sqlQuery);

            return check ? "නව සාමජිකයෙක් යාවත්කාලීන කිරිම සාර්තකයි" : "නව සාමජිකයෙක් යාවත්කාලීන කිරිම අසාර්තකයි";
        }

        public string deleteSocietyMemeber()
        {
            // Check if the member ID is valid
            if (Id == 0)
            {
                return "Invalid Member ID. Please provide a valid value.";
            }

            string sqlQuery = $"DELETE FROM MEMBER WHERE MEMBER_ID = {Id}";
            bool check = Data.ExecuteQuery(sqlQuery);

            return check ? "සාමජිකය ඉවත් කිරීම සාර්තකයි" : "සාමජිකය ඉවත් කිරීම අසාර්තකයි";
        }



        public string saveNewCollector(SocietyMember societyMember)
        {
            string sqlQuery = $"INSERT INTO MILK_COLLECTOR (COLLECTOR_NAME) VALUES (N'{societyMember.Name}') ";
            bool check = Data.ExecuteQuery(sqlQuery);
            string message = check ? "නව සාමජිකයෙක් ඇතුලත් කිරිම සාර්තකයි" : "නව සාමජිකයෙක් ඇතුලත් කිරිම අසාර්තකයි";
            return message;
        }

        public string updateCollector(SocietyMember societyMember)
        {

            if (Id == 0)
            {
                return "Id is empty. Please provide a value.";
            }

         
            string sqlQuery = $"UPDATE MILK_COLLECTOR SET COLLECTOR_NAME = N'{societyMember.Name}' WHERE MILK_COLLECTOR_ID = {Id}";
            bool check = Data.ExecuteQuery(sqlQuery);

            return check ? "නව සාමජිකයෙක් යාවත්කාලීන කිරිම සාර්තකයි" : "නව සාමජිකයෙක් යාවත්කාලීන කිරිම අසාර්තකයි";

        }

        public string deleteCollector(SocietyMember societyMember)
        {
      
            if (Id == 0)
            {
                return "Id is empty. Please provide a value.";
            }
            string sqlQuery = $"DELETE FROM MILK_COLLECTOR WHERE MILK_COLLECTOR_ID = {Id}";
            bool check = Data.ExecuteQuery(sqlQuery);

            return check ? "Delete success" : "Delete fail";
        }


    }
}
