using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public class Node : ICloneable
    {
        Values value = Values.NONE;

        public Node()
        {

        }

        public Node Clone()
        {
            return new Node();
        }
    }
}
