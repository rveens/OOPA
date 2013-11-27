using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public abstract class LogicNode : Node
    {
        protected List<Node> outputs;
        protected int propegationDelay;

        public override void DoAction(bool? newValue)
        {
            if (lastValue == null)
                this.lastValue = newValue;
            else {
                this.value = newValue;
                // TODO nieuwe setvalue aanroepen?
            }
        }
    }
}
