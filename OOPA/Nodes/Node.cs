using System;
using OOPA.Factory;

namespace OOPA
{
    public abstract class Node : ICloneable, IGetKey<String>
    {
        protected bool? value;

        /// <summary>
        /// Protected constructor for factory
        /// </summary>
        protected Node()
        {
        }

        /// <summary>
        /// Accept method to call the visitor
        /// </summary>
        /// <param name="visitor">The visitor to be called</param>
        public abstract void accept(NodeVisitor visitor);

        /// <summary>
        /// Gets the current value for the node
        /// </summary>
        /// <returns>The value</returns>
        public bool? GetValue()
        {
            return value;
        }

        /// <summary>
        /// Create a new object of this objects type
        /// </summary>
        /// <returns>The new object</returns>
        public abstract Object Clone();

        /// <summary>
        /// Returns the key for this object
        /// </summary>
        /// <returns>The key</returns>
        public abstract String getKey();
        
        /// <summary>
        /// Does the action for the current node
        /// </summary>
        /// <param name="inputValue">The value to be used by the node</param>
        public abstract void DoAction(bool? inputValue);

        /// <summary>
        /// Adds outputs to be added to this node
        /// </summary>
        /// <param name="n">The node</param>
        public abstract void AddOutput(Node n);
    }
}
