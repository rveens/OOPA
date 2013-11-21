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

        public Node Clone()
        {
            return new NandNode();
        }
        public String getKey()
        {
            return "NAND";
        }
    }
}
