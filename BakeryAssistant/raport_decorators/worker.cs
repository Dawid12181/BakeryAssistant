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
            nights = 200,
            overtime = 150,
            weekendy = 150,
            sick = -100,
        }
    }
}
