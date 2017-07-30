using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant.raport_dekorators
{
    class NadgodzinyDekorator : WorkerDecorator
    {
        public NadgodzinyDekorator(Worker worker) : base(worker)
        {
        }
        public override int salary()
        {
            Extras add = Extras.nadgodziny;
            return base.salary() + (int)add;
        }

    }
    
}
