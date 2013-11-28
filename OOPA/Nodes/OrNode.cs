using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public class OrNode : LogicNode
    {
        public OrNode()
        {

        }

        protected override bool Calculate()
        {
            if (values.Count == 2)
            {
                value = values[0] | values[1];
                return true;
            }
            return false;
        }

        public override Object Clone()
        {
            return new OrNode();
        }

        public override String getKey()
        {
            return "OR";
        }
    }
}
