﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OOPA.Factory;

namespace OOPA
{
    public abstract class Node : ICloneable, Factory.IGetKey<String>
    {
        private bool? value;

        public Node()
        {

        }

        public abstract Node Clone();
        public abstract String getKey();
    }
}
