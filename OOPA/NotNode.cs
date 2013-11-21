using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public class NotNode : LogicNode
    {
        public NotNode()
        {

        }

        public override Object Clone()
        {
            return new NotNode();
        }
        public override String getKey()
        {
            return "NOT";
        }
    }
}
