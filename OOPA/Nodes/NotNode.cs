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

        protected override bool Calculate()
        {
            return false;
            // return !value1;
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
