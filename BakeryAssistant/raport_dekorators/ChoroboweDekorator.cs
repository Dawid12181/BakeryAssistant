using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant.raport_dekorators
{
    class ChoroboweDekorator : WorkerDecorator
    {
        public ChoroboweDekorator(Worker worker) : base(worker)
        {
        }
        public override int salary()
        {
            Extras add = Extras.chorobowe;
            return base.salary() + (int)add;
        }
    }
}
