using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant
{
    class ProduktyMagazyn: Produkty

    {
        public int ilosc_na_hurtowni { get; set; }
        public double cena_zakupu { get; set; }
        public int wymagana_minimalna_ilosc { get; set; }
        public ProduktyMagazyn()
        {

        }
        public ProduktyMagazyn(Produkty skladnik, int ilosc, int wymagana_ilosc, double cena_zakupu)
        {
            ID = skladnik.ID;
            komponent = skladnik.komponent;
            ilosc_na_hurtowni = ilosc;
            jednostka = skladnik.jednostka;
            wymagana_minimalna_ilosc = wymagana_ilosc;
            this.cena_zakupu = cena_zakupu;
        }
        int KomponentyNaStanie(Produkty produkt)
        {
            return ilosc_na_hurtowni - produkt.ilosc;
        }
    }
}
