using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public abstract class LogicNode : Node
    {
        List<Node> outputs;

        int propegationDelay;
    }
}
