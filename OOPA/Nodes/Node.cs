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

        public void accept(NodeVisitor visitor)
        {
            visitor.visit(this);
        }

        public abstract Object Clone();
        public abstract String getKey();
        
        /* FIXME: methode synchronized maken */
        public abstract void DoAction(bool? newValue);

        public abstract void AddOutput(Node n);
    }
}
