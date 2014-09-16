using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace ConsoleApplication2
{
    class YahooEODSQLUploader
    {
        //constructor
        public YahooEODSQLUploader()
        {
        
        }

        public void Upload(YahooEODData YahooData)
        {
            //connect to server
            string ConnectionString = "Data Source=HAO-PC\\SQLEXPRESS;Initial Catalog=Live;Integrated Security=True";
            SqlConnection dbconnection = new SqlConnection(ConnectionString);
            dbconnection.Open();
            // sql command
            SqlCommand cmd = new SqlCommand("INSERT INTO YahooEODPrice (Date, Ticker,OpenPrice,HighPrice, LowPrice, ClosePrice, Volume, AdjPrice)" +
                                              "VALUES (@Date, @Ticker,@OpenPrice,@HighPrice, @LowPrice, @ClosePrice, @Volume, @AdjPrice)");

            //upload data
            cmd.CommandType = CommandType.Text;
            cmd.Connection = dbconnection;
            cmd.Parameters.AddWithValue("@Date", YahooData.Date);
            cmd.Parameters.AddWithValue("@Ticker", YahooData.ID );
            cmd.Parameters.AddWithValue("@OpenPrice", YahooData.OpenPrice);
            cmd.Parameters.AddWithValue("@HighPrice", YahooData.HighPrice);
            cmd.Parameters.AddWithValue("@LowPrice", YahooData.LowhPrice);
            cmd.Parameters.AddWithValue("@ClosePrice", YahooData.ClosePrice);
            cmd.Parameters.AddWithValue("@Volume", YahooData.Volume);
            cmd.Parameters.AddWithValue("@AdjPrice", YahooData.AdjPrice);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dbconnection.Close(); 
        
        }




    }




}
