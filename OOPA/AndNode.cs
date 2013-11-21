using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public class AndNode : LogicNode
    {
        public AndNode()
        {

        }

        public Node Clone()
        {
            return new AndNode();
        }
        public String getKey()
        {
            return "AND";
        }
    }
}
