using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant.raport_dekorators
{
    class WorkerDecorator : Worker
    {
        protected Worker _worker;
        public WorkerDecorator(Worker worker)
        {
            _worker = worker;   
        }
        public override int salary()
        {
            return _worker.salary();
        }
        public override string GetName()
        {
            return _worker.GetName();
        }
    }
}
