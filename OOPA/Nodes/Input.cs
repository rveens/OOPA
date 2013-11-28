using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public class Input : Node
    {
        List<Node> outputs;

        public Input()
        {
            outputs = new List<Node>();
        }

        public override Object Clone()
        {
            return new Input();
        }

        public override string getKey()
        {
            return "INPUT";
        }

        public override void AddOutput(Node n)
        {
            if (n != null)
                this.outputs.Add(n);
        }
    }
}
