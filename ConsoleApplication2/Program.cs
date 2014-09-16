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
            // testing code ****************************************


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
            
            // load sql data to datatable 
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            
            //Get number of rows
            //int rowCount = rowCount = dataTable.Rows.Count;
            //string[] IDArr = new string[rowCount];

            // set up datetime obj
            DateTime startdate = new DateTime();
            DateTime enddate = new DateTime();
            // set it to t -1 date
            startdate = DateTime.Now.AddDays(-1);
            enddate = DateTime.Now.AddDays(-1);

            // set up yahoo connection obj 
            YahooEOD YahooConnection = new YahooEOD();
            YahooEODData YahooData = new YahooEODData();
            string myid;


            // SQL Connection 
            YahooEODSQLUploader Uploader = new YahooEODSQLUploader();


            // main loop 
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                // get id from sql server
                myid = dataTable.Rows[i][0].ToString();
                // download price from yahoo finance 
                YahooData = YahooConnection.fetchHP (myid, startdate, enddate);
                YahooData.ID = myid;
                if (YahooData.OpenPrice != 0)
                {
                    Uploader.Upload(YahooData);
                }
            }

           
        }




    }
}
