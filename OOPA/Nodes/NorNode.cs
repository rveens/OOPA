using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public class NorNode : LogicNode
    {
        public NorNode()
        {

        }

        protected override bool Calculate()
        {
            if (values.Count == 2)
            {
                value = !(values[0] | values[1]);
                return true;
            }
            return false;
        }

        public override Object Clone()
        {
            return new NorNode();
        }
        public override String getKey()
        {
            return "NOR";
        }
    }
}
