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
