using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethereum
{
    class Response
    {
        public DateTime datetime { get; set; }
        public string midnight_price { get; set; }
        public string current_price { get; set; }
        public string raw_price { get; set; }
        public string percent_change { get; set; }
        public string absolute_change { get; set; }
        public string today_high { get; set; }
        public string today_low { get; set; }
        public string market_cap { get; set; }



        public void SaveToDatabase()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Dusan\\AppData\\Local\\Microsoft\\Microsoft SQL Server Local DB\\Instances\\MSSQLLocalDB\\Ethereum.mdf\"; Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;           
                    command.CommandType = CommandType.Text;
                    //command.CommandText = "INSERT into response (datetime,midnight_price,current_price,raw_price,percent_change,absolute_change,"+
                    //                    "today_high,today_low,market_cap) VALUES (@datetime,@midnight_price,@current_price,@raw_price,@percent_change,@absolute_change," +
                    //                    "@today_high,@today_low,@market_cap)";
                    command.CommandText = "INSERT into response (datetime,current_price) VALUES (@datetime,@current_price)";
                    command.Parameters.AddWithValue("@datetime", datetime);
                    //command.Parameters.AddWithValue("@midnight_price", midnight_price);
                    command.Parameters.AddWithValue("@current_price", current_price);
                    //command.Parameters.AddWithValue("@raw_price", raw_price);
                    //command.Parameters.AddWithValue("@percent_change", percent_change);
                    //command.Parameters.AddWithValue("@absolute_change", absolute_change);
                    //command.Parameters.AddWithValue("@today_high", today_high);
                    //command.Parameters.AddWithValue("@today_low", today_low);
                    //command.Parameters.AddWithValue("@market_cap", market_cap);

                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
