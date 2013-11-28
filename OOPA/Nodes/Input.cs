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

        }

        public override void DoAction(bool? newValue)
        {
            throw new NotImplementedException();
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
