using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant
{
    class Produkty
    {
        public int ID { get; set; }
        public string komponent { get; set; }
        public int  ilosc { get; set; }
        public string jednostka { get; set; }
        public double cena { get; set; }
        public Produkty()
        {

        }
        public Produkty(int sID, string skomponent, int silosc, string sjednostka)
        {
            ID = sID;
            komponent = skomponent;
            ilosc = silosc;
            jednostka = sjednostka;
        }

    }
}
