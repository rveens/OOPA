using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public abstract class LogicNode : Node
    {
        protected List<Node> outputs;
        protected List<bool?> values;
        protected int propegationDelay;

        public override void DoAction(bool? newValue)
        {
            values.Add(newValue);
            if (Calculate())
                ;
            //TODO:Roep outputs aan
        }

        public void AddOutput(Node n)
        {
            if (n != null)
                this.outputs.Add(n);
        }

        protected abstract bool Calculate();
    }
}
