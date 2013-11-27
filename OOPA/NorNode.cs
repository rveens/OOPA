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

        protected override bool? Calculate(bool? value1, bool? value2)
        {
            return !(value1 | value2);
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
