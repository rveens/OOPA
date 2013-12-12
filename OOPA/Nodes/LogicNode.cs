using System;
using System.Threading;
using System.Collections.Generic;

namespace OOPA
{
    public abstract class LogicNode : Node
    {
        protected List<Node> outputs = new List<Node>();
        protected List<bool?> inputValues;
        protected int propegationDelay;

        protected LogicNode()
        {

        }

        public override void DoAction(bool? newValue)
        {
            inputValues.Add(newValue);
            if (Calculate())
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

        protected abstract bool Calculate();

        private void startThread(Node node)
        {
            Thread thread = new Thread(() => node.DoAction(value));
            thread.Start();
        }
    }
}
