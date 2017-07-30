using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant.raport_dekorators
{
    public abstract class Worker
    {
        public abstract int salary();
        public abstract string GetName();
        public enum Extras
        {
            nocki = 200,
            nadgodziny = 150,
            weekendy = 150,
            chorobowe = -100,
        }
    }
}
