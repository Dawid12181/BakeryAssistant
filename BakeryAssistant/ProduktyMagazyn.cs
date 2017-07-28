using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant
{
    public class ProduktyMagazyn

    {
        public int ID { get; set; }
        public string nazwa { get; set; }
        public string jednostka { get; set; }
        public int ilosc { get; set; }
        public int wymagana_ilosc { get; set; }
        public double cena_zakupu { get; set; }
        public double cena { get; set; }
        public ProduktyMagazyn()
        {

        }
        public ProduktyMagazyn(int sID, string snazwa, string sjednostka,  int silosc, int swymagana_ilosc, double scena_zakupu, double scena)
        {
            ID = sID;
            nazwa = snazwa;
            wymagana_ilosc = swymagana_ilosc;
            jednostka = sjednostka;
            ilosc = silosc;
            cena_zakupu = scena_zakupu;
            cena = scena;
        }
        int KomponentyNaStanie(ProduktyMagazyn skladnik)
        {
            return skladnik.wymagana_ilosc - skladnik.ilosc;
        }
    }
}
