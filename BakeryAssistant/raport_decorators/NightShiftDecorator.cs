using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant.raport_dekorators
{
    class NightShiftDecorator : WorkerDecorator
    {
        public NightShiftDecorator(Worker worker) : base(worker)
        {
        }
        public override int salary()
        {
            Extras add = Extras.nights;
            return base.salary() + (int)add;
        }
        
    }
}
