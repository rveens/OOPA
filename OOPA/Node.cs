using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OOPA.Factory;

namespace OOPA
{
    public abstract class Node : ICloneable, IGetKey<String>
    {
        protected bool? value;

        public Node()
        {

        }

        public abstract Object Clone();
        public abstract String getKey();
        
        /* FIXME: methode synchronized maken */
        public virtual void DoAction(bool? newValue)
        {
            this.value = newValue;
            // TODO nieuwe setvalue aanroepen?
        }

        public abstract void AddOutput(Node n);
    }
}
