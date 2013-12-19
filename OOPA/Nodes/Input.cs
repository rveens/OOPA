using System;
using System.Threading;
using System.Collections.Generic;

namespace OOPA
{
    /// <summary>
    /// A node that resembles an input node.
    /// This class is abstract and children of it represent a low or a high input.
    /// </summary>
    public abstract class Input : Node
    {
        /// <summary>
        /// A list of outputs.
        /// </summary>
        List<Node> outputs;

        /// <summary>
        /// Protected constructor that initialized member variables.
        /// </summary>
        protected Input()
        {
            outputs = new List<Node>();
        }

        /// <summary>
        /// DoAction function that is overridden.
        /// An input node does no calculation and starts threads for his outputs.
        /// </summary>
        /// <param name="newValue">The input value of the input.</param>
        public override void DoAction(bool? newValue)
        {
            value = newValue;
            outputs.ForEach(startThread);
        }

        /// <summary>
        /// Accept function that accepts a NodeVisitor.
        /// </summary>
        /// <param name="visitor">A NodeVisitor object.</param>
        public override void accept(NodeVisitor visitor)
        {
            visitor.visit(this);
        }

        /// <summary>
        /// AddOutput function that accepts a node.
        /// This is used to add a node to the input nodes output list.
        /// </summary>
        /// <param name="n">The node that has to be added as output.</param>
        public override void AddOutput(Node n)
        {
            if (n != null)
                this.outputs.Add(n);
        }

        /// <summary>
        /// This method is called to start a new thread.
        /// </summary>
        /// <param name="node">A node that is needed to provide context and work to the thread.</param>
        private void startThread(Node node)
        {
            ThreadManager.StartThread(() => node.DoAction(value));
        }
    }
}
