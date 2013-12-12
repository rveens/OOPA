using System;
using System.Threading;
using System.Collections.Generic;

namespace OOPA
{
    public abstract class Input : Node
    {
        List<Node> outputs;

        protected Input()
        {
            outputs = new List<Node>();
        }

        public override void DoAction(bool? newValue)
        {
            value = newValue;
            outputs.ForEach(startThread);
        }

        public override void accept(NodeVisitor visitor)
        {
            visitor.visit(this);
        }

        public override void AddOutput(Node n)
        {
            if (n != null)
                this.outputs.Add(n);
        }

        private void startThread(Node node)
        {
            Thread thread = new Thread(() => node.DoAction(value));
            thread.Start();
        }
    }
}
