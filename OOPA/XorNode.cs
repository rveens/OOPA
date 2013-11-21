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
