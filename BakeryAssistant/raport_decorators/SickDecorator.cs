using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant.raport_dekorators
{
    class SickDecorator : WorkerDecorator
    {
        public SickDecorator(Worker worker) : base(worker)
        {
        }
        public override int salary()
        {
            Extras add = Extras.sick;
            return base.salary() + (int)add;
        }
    }
}