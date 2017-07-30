using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant
{
    public class Skladnik
    {
        public List<int> ID;
        public List<int> ilosc;
        public int IDproduktu;
        public Skladnik()
        {

        }
        public Skladnik(List<int> sID, List<int> silosc, int sidproduktu)
        {
            IDproduktu = sidproduktu;
            ID = sID;
            ilosc = silosc;
        }
    }

}
