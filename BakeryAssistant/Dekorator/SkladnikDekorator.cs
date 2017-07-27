using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant.Dekorator
{
    public class SkladnikDekorator : Składnik.Produkt
    {
        protected Składnik.Produkt _produkt;
        public SkladnikDekorator(Składnik.Produkt produkt)
        {
            _produkt = produkt;
        }
        public override double CalculateCost()
        {
            return _produkt.CalculateCost();
        }
        public override string GetName()
        {
            return _produkt.GetName();
        }
    }
}
