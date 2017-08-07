using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant
{
    public class Order
    {
        public string ID { get; set; }
        public string Receiver { get; set; }
        public string Address { get; set; }
        public string Date { get; set; }
        public string Order_text { get; set; }
        public Order()
        {

        }
         public Order(string sID, string sReceiver, string sAddress, string sDate, string sOrder_text)
        {
            ID = sID;
            Receiver = sReceiver;
            Address = sAddress;
            Date = sDate;
            Order_text = sOrder_text;
        }
    }
}