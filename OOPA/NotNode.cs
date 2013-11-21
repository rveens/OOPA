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

        public Node Clone()
        {
            return new NotNode();
        }
        public String getKey()
        {
            return "NOT";
        }
    }
}
