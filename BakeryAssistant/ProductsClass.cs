using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant
{
    public class ProductsClass
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int  quantity { get; set; }
        public string unit { get; set; }
        public double price { get; set; }
        public string componentID { get; set; }
        public string quantityofproducts { get; set; }
        public ProductsClass()
        {

        }
        public ProductsClass(int sID, string sname, int squantity, string sunit, double sprice, string scomponentID, string squantityofproducts )
        {
            ID = sID;
            name = sname;
            quantity = squantity;
            unit = sunit;
            price = sprice;
            componentID = scomponentID;
            quantityofproducts = squantityofproducts;
        }

    }
}
