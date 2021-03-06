﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using System.Net;

namespace ConsoleApplication2
{
    // yahoo finance API endof day data
    public class YahooEOD
    {
        // constructor
        public YahooEOD()
        {
            int x = 1;
        }

        //method fetch
        public YahooEODData fetchHP(string id, DateTime StartDate, DateTime EndDate)
        {

            string DataString;
            DataString = "http://ichart.finance.yahoo.com/table.csv?s=" + id +
                         "&d=" + (StartDate.Month - 1) + "&e=" + StartDate.Day + "&f=" + StartDate.Year +
                         "&g=d&a=" + (EndDate.Month-1) + "&b=" + EndDate.Day  + "&c=" + EndDate.Year +  "&ignore=.csv";
            
            
            WebClient web = new WebClient();
            YahooEODData EODData = new YahooEODData();
            try
            {
                string csvData = web.DownloadString(DataString);
                EODData = Parse(csvData);
                Console.WriteLine(id + " is downloaded successfully from yahoo finance");
            }
            catch
            {
                Console.WriteLine(id + " can not be found in yahoo finance");
            }


            decimal y = 0;
            return EODData;
        }

        //method
        private static YahooEODData Parse(string csvData)
        {
            YahooEODData EODData = new YahooEODData();

            string[] rows = csvData.Replace("\r", "").Split('\n');

            int i = 1;
            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row)) continue;
                string[] cols = row.Split(',');

                if (i != 1)
                {
                    EODData.Date  = Convert.ToDateTime(cols[0]);
                    EODData.OpenPrice = Convert.ToDecimal(cols[1]);
                    EODData.HighPrice = Convert.ToDecimal(cols[2]);
                    EODData.LowhPrice = Convert.ToDecimal(cols[3]);
                    EODData.ClosePrice = Convert.ToDecimal(cols[4]);
                    EODData.Volume = Convert.ToDecimal(cols[5]);
                    EODData.AdjPrice = Convert.ToDecimal(cols[6]);
                }
                i = ++i;
            }

            return EODData;
        }

    }


    // Yahoo YQL 
    public class YahooYQL
    {


        public YahooYQL()
        {
            string BASE_URL = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20(%22GLD%22)&env=store://datatables.org/alltableswithkeys";
        }
        
        // fetch                           
        public decimal fetch(string BASE_URL)
        {
            //string ticker = "GLD";
            XDocument doc = XDocument.Load(BASE_URL);
            decimal x = Parse(doc);
            return x;
        }

        //private parse function
        private static decimal Parse(XDocument doc)
        {
            XElement results = doc.Root.Element("results");

            XElement q = results.Elements("quote").First(w => w.Attribute("symbol").Value == "GLD");

            decimal[,] y = new decimal[2, 2];

            y[1, 1] = GetDecimal(q.Element("Ask").Value);


            return y[1, 1];
        }

        //private function convert string to decimal 
        private static decimal GetDecimal(string input)
        {
            

            input = input.Replace("%", "");

            decimal value;

            Decimal.TryParse(input, out value);
            return value;
            
        }


    }

}
