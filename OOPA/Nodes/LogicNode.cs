using System;
using System.Threading;
using System.Collections.Generic;

namespace OOPA
{
    public abstract class LogicNode : Node
    {
        /// <summary>
        /// The stores outputs for this node
        /// </summary>
        protected List<Node> outputs = new List<Node>();
        /// <summary>
        /// The input values already recieved
        /// </summary>
        protected List<bool?> inputValues;
        //protected int propegationDelay;

        /// <summary>
        /// LockObject to lock the DoAction method
        /// </summary>
        private readonly object lockObject = new object();

        /// <summary>
        /// Protected constructor for the factory
        /// </summary>
        protected LogicNode()
        {
            inputValues = new List<bool?>();
        }

        /// <summary>
        /// The DoAction method to do his action
        /// </summary>
        /// <param name="newValue">The value to be used by this action</param>
        public override void DoAction(bool? newValue)
        {
            lock (lockObject)
            {
                inputValues.Add(newValue);
                if (Calculate())
                    outputs.ForEach(startThread);
            }
        }

        /// <summary>
        /// The implementation for the accept method
        /// </summary>
        /// <param name="visitor">The visitor to visit.</param>
        public override void accept(NodeVisitor visitor)
        {
            visitor.visit(this);
        }

        /// <summary>
        /// Implementatiion for AddOutput method, adds the output to the array
        /// </summary>
        /// <param name="n">The output</param>
        public override void AddOutput(Node n)
        {
            if (n != null)
                this.outputs.Add(n);
        }

        /// <summary>
        /// The abstract calculate method to be overridden in the node implementations
        /// </summary>
        /// <returns>If this node has been calculated</returns>
        protected abstract bool Calculate();

        /// <summary>
        /// Starts the new thread
        /// </summary>
        /// <param name="node">The node to call the new thread on</param>
        private void startThread(Node node)
        {
            ThreadManager.StartThread(() => node.DoAction(value));
        }
    }
}
