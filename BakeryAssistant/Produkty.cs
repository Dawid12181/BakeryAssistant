using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant
{
    public class Produkty
    {
        public int ID { get; set; }
        public string nazwa { get; set; }
        public int  ilosc { get; set; }
        public string jednostka { get; set; }
        public double cena { get; set; }
        public string idskladnika { get; set; }
        public string iloscproduktu { get; set; }
        public Produkty()
        {

        }
        public Produkty(int sID, string snazwa, int silosc, string sjednostka, double scena, string sidskladnika, string siloscproduktu )
        {
            ID = sID;
            nazwa = snazwa;
            ilosc = silosc;
            jednostka = sjednostka;
            cena = scena;
            idskladnika = sidskladnika;
            iloscproduktu = siloscproduktu;
        }

    }
}
