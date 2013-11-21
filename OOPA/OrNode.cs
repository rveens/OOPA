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
