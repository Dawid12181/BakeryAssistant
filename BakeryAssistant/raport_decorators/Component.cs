using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant
{
    public class Component
    {
        public List<int> ID;
        public List<int> quantity;
        public int productID;
        public Component()
        {

        }
        public Component(List<int> sID, List<int> squantity, int sproductID)
        {
            productID = sproductID;
            ID = sID;
            quantity = squantity;
        }
    }

}
