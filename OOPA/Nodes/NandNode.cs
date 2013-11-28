using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public class NandNode : LogicNode
    {
        public NandNode()
        {

        }

        protected override bool Calculate()
        {
            if (values.Count == 2)
            {
                value = !(values[0] & values[1]);
                return true;
            }
            return false;
        }

        public override Object Clone()
        {
            return new NandNode();
        }
        public override String getKey()
        {
            return "NAND";
        }
    }
}
