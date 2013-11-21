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

        public Node Clone()
        {
            return new NorNode();
        }
        public String getKey()
        {
            return "NOR";
        }
    }
}
