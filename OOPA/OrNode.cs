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

        protected override bool? Calculate(bool? value1, bool? value2)
        {
            return value1 | value2;
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
