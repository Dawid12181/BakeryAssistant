using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant.raport_dekorators
{
    class OverTimeDecorator : WorkerDecorator
    {
        public OverTimeDecorator(Worker worker) : base(worker)
        {
        }
        public override int salary()
        {
            Extras add = Extras.overtime;
            return base.salary() + (int)add;
        }

    }
    
}
