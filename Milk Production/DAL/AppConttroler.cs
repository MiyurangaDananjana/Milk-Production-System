﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milk_Production
{
    class AppConttroler
    {
        public int Id { get; set; }
        public string MemeberName { get; set; }
        public decimal BTS { get; set; }
        public decimal TS { get; set; }
        public decimal LactoMeterReading { get; set; }
        public decimal SampleNumber { get; set; }
        public decimal AmountOfMilkGiven { get; set; }
        public decimal Fats { get; set; }
        public decimal ValuesOfLiter { get; set; }
        public decimal MoneyGiven { get; set; }
        public string SocityName { get; set; }
        public string dateEnterName { get; set; }
        public string Date { get; set; }
        public string LoryGivenName { get; set; }

        public bool systemLogin(string userName, string password)
        {
            string sqlQurey = $"SELECT * FROM Admin_Login WHERE admin_name = '{userName}' AND password='{password}'";

            DataSet data = Data.GetData(sqlQurey);
            if (data.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int login(string userName, string password)
        {
            string sqlQurey = $"SELECT * FROM LOGIN WHERE USER_NAME = '{userName}' AND PASSWORD ='{password}'";

            DataSet data = Data.GetData(sqlQurey);
            if (data.Tables[0].Rows.Count > 0)
            {
                DataRow row = data.Tables[0].Rows[0];
                // Get the value from the "Roll" column of the first row
                int rollValue = Convert.ToInt32(row["USER_ROLE"]);
                return rollValue;
            }
            // Return a default value or handle the case when no rows are found
            return -1;

        }
    }
}
