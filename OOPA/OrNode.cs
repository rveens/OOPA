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

        public Node Clone()
        {
            return new OrNode();
        }
        public String getKey()
        {
            return "OR";
        }
    }
}
