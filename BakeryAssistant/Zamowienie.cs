using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant
{
    public class Zamowienie
    {
        public string ID { get; set; }
        public string Odbiorca { get; set; }
        public string Adres { get; set; }
        public string Data { get; set; }
        public string Zamowienie_tekst { get; set; }
        public Zamowienie()
        {

        }
         public Zamowienie(string sID, string sOdbiorca, string sAdres, string sData, string sZamowienie_tekst)
        {
            ID = sID;
            Odbiorca = sOdbiorca;
            Adres = sAdres;
            Data = sData;
            Zamowienie_tekst = sZamowienie_tekst;
        }
    }
}