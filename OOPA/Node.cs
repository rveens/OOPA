using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OOPA.Factory;

namespace OOPA
{
    public abstract class Node : ICloneable, IGetKey<String>
    {
        private bool? value;

        public Node()
        {

        }

        public abstract Object Clone();
        public abstract String getKey();
    }
}
