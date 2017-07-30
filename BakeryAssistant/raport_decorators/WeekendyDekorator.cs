using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant.raport_dekorators
{
    class WeekendyDekorator : WorkerDecorator
    {
        public WeekendyDekorator(Worker worker) : base(worker)
        {
        }
        public override int salary()
        {
            Extras add = Extras.weekendy;
            return base.salary() + (int)add;
        }

    }
}
