using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant
{
    public class ComponentsInWarehouse

    {
        public int ID { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public int quantity { get; set; }
        public int required_quantity { get; set; }
        public double seller_price { get; set; }
        public ComponentsInWarehouse()
        {

        }
        public ComponentsInWarehouse(int sID, string sname, string sunit,  int squantity, int srequired_quantity, double sseller_price)
        {
            ID = sID;
            name = sname;
            required_quantity = srequired_quantity;
            unit = sunit;
            quantity = squantity;
            seller_price = sseller_price;
        }
    }
}
