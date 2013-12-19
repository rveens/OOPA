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

        private readonly object lockObject = new object();

        protected LogicNode()
        {
            inputValues = new List<bool?>();
        }

        public override void DoAction(bool? newValue)
        {
            lock (lockObject)
            {
                inputValues.Add(newValue);
                if (Calculate())
                    outputs.ForEach(startThread);
            }
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
            ThreadManager.StartThread(() => node.DoAction(value));
        }
    }
}
