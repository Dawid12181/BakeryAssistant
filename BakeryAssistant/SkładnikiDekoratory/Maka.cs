using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant.SkładnikiDekoratory
{
    public class MakaDekorator : Dekorator.SkladnikDekorator
    {
        public MakaDekorator(Składnik.Produkt produkt) : base(produkt)
        {

        }
        public override double CalculateCost()
        {
            return _produkt.CalculateCost() + 2.15;
        }
        public override string GetName()
        {
            return _produkt.GetName() + "costam"; ;
        }
    }
}
