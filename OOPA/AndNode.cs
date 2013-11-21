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

        public override Object Clone()
        {
            return new AndNode();
        }
        public override String getKey()
        {
            return "AND";
        }
    }
}
