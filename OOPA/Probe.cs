﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public class Probe : Node
    {
        public Probe()
        {

        }

        public override void AddOutput(Node n)
        {
            // niets
        }

        public override Object Clone()
        {
            return new Probe();
        }
        public override string getKey()
        {
            return "PROBE";
        }
    }
}
