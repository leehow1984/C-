using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{    
    // YQL data structure (XML)
    public class YahooYQLData
    {
        private decimal MyAskPrice = 0;
        private decimal MyBidPrice = 0;
        
        // constructor
        public YahooYQLData()
        {
         
         }

        // ask price
        public decimal AskPrice
        {
            get { return MyAskPrice; }
            set { MyAskPrice = value;}
        }

        // bid price
        public decimal BidPrice
        {
            get { return MyBidPrice; }
            set { MyBidPrice = value; }
        }



    }


    // yahoo eod data structure (csv)
    public class YahooEODData
    {
        private decimal MyOpenPrice = 0;
        private decimal MyHighPrice = 0;
        private decimal MyLowPrice = 0;
        private decimal MyClosePrice = 0;
        private decimal MyVolume = 0;
        private decimal MyAdjPrice = 0;
        DateTime Mydt = new DateTime();
        private string MyID = "";
        //Constructor
        public YahooEODData()
        { 
        
        
        }
 
        // open price
        public decimal OpenPrice
        {
            get { return MyOpenPrice; }
            set { MyOpenPrice = value; }
        }
        // high price
        public decimal HighPrice
        {
            get { return MyHighPrice; }
            set { MyHighPrice = value; }
        }
        // low price
        public decimal LowhPrice
        {
            get { return MyLowPrice; }
            set { MyLowPrice = value; }
        }
        // volume
        public decimal Volume
        {
            get { return MyVolume; }
            set { MyVolume = value; }
        }
        // myadjprice
        public decimal AdjPrice
        {
            get { return MyAdjPrice; }
            set { MyAdjPrice = value; }
        }
        // close price
        public decimal ClosePrice
        {
            get { return MyClosePrice; }
            set { MyClosePrice = value; }
        }
        // date
        public DateTime Date
        {
            get { return Mydt; }
            set { Mydt = value; }
        }
        // id ticker
        public string ID
        {
            get { return MyID; }
            set { MyID = value; }        
        }


    }

}
