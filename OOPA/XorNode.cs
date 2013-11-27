using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public class XorNode : LogicNode
    {
        public XorNode()
        {

        }

        protected override bool? Calculate(bool? value1, bool? value2)
        {
            if (value1.Value && value2.Value)
                return false;

            return value1 | value2;
        }

        public override Object Clone()
        {
            return new XorNode();
        }
        public override String getKey()
        {
            return "XOR";
        }
    }
}
