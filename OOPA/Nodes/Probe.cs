using System;

namespace OOPA
{
    /// <summary>
    /// This class is an output Node.
    /// </summary>
    public class Probe : Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Probe"/> class.
        /// </summary>
        public Probe()
        {

        }

        /// <summary>
        /// Adds a new output to this node.
        /// </summary>
        /// <remarks>
        /// This method is empty. The override is only for the Visitor pattern.
        /// </remarks>
        /// <param name="n">The node to add as output.</param>
        public override void AddOutput(Node n)
        {
            //TODO: Create visitor for AddOutput
        }

        /// <summary>
        /// Accepts this node to the visitor.
        /// </summary>
        /// <param name="visitor">The visitor to accept this node to.</param>
        public override void accept(NodeVisitor visitor)
        {
            visitor.visit(this);
        }

        /// <summary>
        /// Writes the result of the circuit to the console.
        /// </summary>
        /// <param name="newValue"></param>
        public override void DoAction(bool? newValue)
        {
            value = newValue;
            Console.WriteLine(this.GetType() + " " + this.value);
        }

        /// <summary>
        /// Clones this object.
        /// </summary>
        /// <returns>A cloned instance of <see cref="Probe"/>.</returns>
        public override Object Clone()
        {
            return new Probe();
        }

        /// <summary>
        /// Gets the key of this probe.
        /// </summary>
        /// <returns>The key of this probe.</returns>
        public override string getKey()
        {
            return "PROBE";
        }
    }
}
