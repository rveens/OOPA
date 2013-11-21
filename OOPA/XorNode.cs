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

        public Node Clone()
        {
            return new XorNode();
        }
        public String getKey()
        {
            return "XOR";
        }
    }
}
