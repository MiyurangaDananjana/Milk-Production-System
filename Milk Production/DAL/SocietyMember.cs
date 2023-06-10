using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Milk_Production.DAL
{
    public class SocietyMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SocietyId { get; set; }



        public string newSocietyMemeber(SocietyMember society)
        {
            string message = string.Empty;

            string sqlQuery = $"INSERT INTO MEMBER (MEMBER_NAME,SOCIETY_ID) VALUES (N'{society.Name}',N'{society.SocietyId}') ";
            bool check = Data.ExecuteQuery(sqlQuery);
            if (check)
            {
                message = "නව සාමජිකයෙක් ඇතුලත් කිරිම සාර්තකයි";
                return message;
            }
            else
            {
                message = "නව සාමජිකයෙක් ඇතුලත් කිරිම අසාර්තකයි";
                return message;
            }
        }

        public string saveNewCollector(SocietyMember societyMember)
        {
            string message = string.Empty;
            string sqlQuery = $"INSERT INTO MILK_COLLECTOR (COLLECTOR_NAME) VALUES (N'{societyMember.Name}') ";
            bool check = Data.ExecuteQuery(sqlQuery);
            if (check)
            {
                message = "නව සාමජිකයෙක් ඇතුලත් කිරිම සාර්තකයි";
                return message;
            }
            else
            {
                message = "නව සාමජිකයෙක් ඇතුලත් කිරිම අසාර්තකයි";
                return message;
            }
        }

    }
}
