using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main()
        {

            // testing code ****************************************
            //YahooYQL x = new YahooYQL();
            string BASE_URL = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20(%22GLD%22)&env=store://datatables.org/alltableswithkeys";
            //decimal z = x.fetch(BASE_URL);

            //YahooYQLData p = new YahooYQLData();
            //p.AskPrice = z;

            //decimal y = p.AskPrice;

            // test code
            //DateTime dt1 = new DateTime();
            //dt1 = DateTime.Now;

            //string strdate = dt1.Year + "/" + dt1.Month + "/" + dt1.Day;




            // Production Code Start From this line
            //-----------------------------------------------------------------------------------

            //sql connection: fetch all yahoo ticker
            SqlConnection dbconnection1 = new SqlConnection("Data Source=HAO-PC\\SQLEXPRESS;Initial Catalog=Live;Integrated Security=True");
            dbconnection1.Open();

            //download ticker from database
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM YahooTicker";
            cmd.Connection = dbconnection1;


            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            
            //Get number of rows
            //int rowCount = rowCount = dataTable.Rows.Count;
            //string[] IDArr = new string[rowCount];

            YahooEOD YahooConnection = new YahooEOD();
            YahooEODData YahooData = new YahooEODData();
            string myid;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                myid = dataTable.Rows[i][0].ToString();
                //YahooData = YahooConnection.fetch(myid);
                 
             

            }
           


           
  


            dbconnection1.Close();


            // upload data ///////////////////////////////////

            DateTime dt = new DateTime();
            dt = DateTime.Now;
            decimal newprice = 101;

            string ConnectionString = "Data Source=HAO-PC\\SQLEXPRESS;Initial Catalog=Live;Integrated Security=True";

            SqlConnection dbconnection2 = new SqlConnection(ConnectionString);
            dbconnection2.Open();

            SqlCommand cmd2 = new SqlCommand("INSERT INTO YahooEODPrice (Date, Ticker, Name,OpenPrice,HighPrice, LowPrice, ClosePrice, Volume, AdjPrice)" +
                                              "VALUES (@Date, @Ticker, @Name,@OpenPrice,@HighPrice, @LowPrice, @ClosePrice, @Volume, @AdjPrice)");
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = dbconnection2;
            cmd2.Parameters.AddWithValue("@Date", dt);
            cmd2.Parameters.AddWithValue("@Ticker", "GLD");
            cmd2.Parameters.AddWithValue("@Name", "Gold trust");
            cmd2.Parameters.AddWithValue("@OpenPrice", newprice);
            cmd2.Parameters.AddWithValue("@HighPrice", newprice);
            cmd2.Parameters.AddWithValue("@LowPrice", newprice);
            cmd2.Parameters.AddWithValue("@ClosePrice", newprice);
            cmd2.Parameters.AddWithValue("@Volume", newprice);
            cmd2.Parameters.AddWithValue("@AdjPrice", newprice);

            cmd2.ExecuteNonQuery();

            dbconnection2.Close(); 


           








  
        }




    }
}
