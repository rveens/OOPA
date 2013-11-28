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
            value = !this.values[0];
            return true;
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
