﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryAssistant.raport_dekorators
{
    class Salesman:Worker
    {
        public override int salary()
        {
            return 1200;
        }
        public override string GetName()
        {
            return "Ekspedientka";
        }
    }
}
