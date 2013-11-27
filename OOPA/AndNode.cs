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

        protected override bool Calculate()
        {
            if (values.Count == 2)
            {
                value = values[1] & values[2];
                return true;
            }
            return false;
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
