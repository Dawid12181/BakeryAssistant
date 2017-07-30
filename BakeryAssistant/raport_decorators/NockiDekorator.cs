using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant.raport_dekorators
{
    class NockiDekorator : WorkerDecorator
    {
        public NockiDekorator(Worker worker) : base(worker)
        {
        }
        public override int salary()
        {
            Extras add = Extras.nocki;
            return base.salary() + (int)add;
        }
        
    }
}
