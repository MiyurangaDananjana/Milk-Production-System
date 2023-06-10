
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Milk_Production.DAL
{
    public class dailyMilkCollection
    {
        public static int ID { get; set; }
        public int MemberID { get; set; }
        public decimal BTS { get; set; }
        public decimal TS { get; set; }
        public int SampleNo { get; set; }
        public decimal GivenMilk { get; set; }
        public int LactometerReadingNumber { get; set; }
        public int MilkFat { get; set; }
        public decimal ValuePerLiter { get; set; }
        public decimal AmountPaid { get; set; }
        public int collectorId { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime CollectionTime { get; set; }

        public string CreateInsertQuery(dailyMilkCollection milkCollection)
        {
            string message = string.Empty;
            string query = $"INSERT INTO DAILY_MILK_COLLECTION (MEMBER_ID, BTS, TS, SAMPLE_NO, GIVEN_MILK, LACATOR_METER_REDING_NUMBER, MILK_FAT, VALUE_PER_L, AMOUNT_PAID, COLLECTOR_ID, COLLECTING_DATE, COLLECTING_TIME) VALUES " +
                $"({milkCollection.MemberID}, {milkCollection.BTS}, {milkCollection.TS}, {milkCollection.SampleNo}, {milkCollection.GivenMilk}, " +
                $"{milkCollection.LactometerReadingNumber}, {milkCollection.MilkFat}, {milkCollection.ValuePerLiter}, {milkCollection.AmountPaid}, {milkCollection.collectorId}, " +
                $"'{milkCollection.CollectionDate.ToString("yyyy-MM-dd")}', '{milkCollection.CollectionTime.ToString("HH:mm:ss")}')";
            bool check = Data.ExecuteQuery(query);
            if (check)
            {
                message = "දත්ත අතුලත් කිරීම සාර්තකයි";
                return message;
            }
            else
            {
                message = "දත්ත අතුලත් කිරීම අසාර්තකයයි";
                return message;
            }
        }

        public string CreateUpdateQuery(dailyMilkCollection milkCollection)
        {
            string message = string.Empty;

            if (ID == 0)
            {
                message = "ID is empty. Cannot delete.";
                return message;
            }


            string query = $"UPDATE DAILY_MILK_COLLECTION SET MEMBER_ID = {milkCollection.MemberID}, " +
                $"BTS = {milkCollection.BTS}, TS = {milkCollection.TS}, SAMPLE_NO = {milkCollection.SampleNo}, " +
                $"GIVEN_MILK = {milkCollection.GivenMilk}, LACATOR_METER_REDING_NUMBER = {milkCollection.LactometerReadingNumber}, " +
                $"MILK_FAT = {milkCollection.MilkFat}, VALUE_PER_L = {milkCollection.ValuePerLiter}, " +
                $"AMOUNT_PAID = {milkCollection.AmountPaid}, COLLECTOR_ID = {milkCollection.collectorId}, " +
                $"COLLECTING_DATE = '{milkCollection.CollectionDate.ToString("yyyy-MM-dd")}', " +
                $"COLLECTING_TIME = '{milkCollection.CollectionTime.ToString("HH:mm:ss")}' " +
                $"WHERE ID = {ID}";

            bool check = Data.ExecuteQuery(query);
            if (check)
            {
                message = "දත්ත යාවත්කාලීන කිරීම සාර්තකයි";
                return message;
            }
            else
            {
                message = "දත්ත යාවත්කාලීන කිරීම අසාර්තකයයි";
                return message;
            }
        }
        public string deletedailyMilkCollection()
        {

            string message = string.Empty;
            if (ID == 0)
            {
                message ="ID is empty. Cannot delete.";
                return message ;
            }


            string query = $"DELETE FROM DAILY_MILK_COLLECTION WHERE ID = {ID}";

            // Execute the delete query
            bool check = Data.ExecuteQuery(query);
            if (check)
            {
                message = "දත්ත ඉවත් කිරීම සාර්තකයි";
                return message;
            }
            else
            {
                message = "දත්ත ඉවත් කිරීම අසාර්තකයයි";
                return message;
            }
        }


    }
}
