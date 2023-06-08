using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Milk_Production
{
    class Data
    {
        public static string cs = ConfigurationManager.ConnectionStrings["dbcon"].ToString();

        public static DataSet GetData(string sql)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static bool ExecuteQuery(string sql)
        {
            bool success = false;
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                int rowsAffected = cmd.ExecuteNonQuery();
                success = (rowsAffected > 0);
            }
            return success;
        }
    }
}
