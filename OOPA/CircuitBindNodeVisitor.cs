using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPA
{
    class CircuitBindNodeVisitor : NodeVisitor
    {
        Circuit circuit;

        public CircuitBindNodeVisitor(Circuit circ)
        {
            circuit = circ;
        }

        public virtual void visit(Node node) { }

        public virtual void visit(LogicNode node) { }

        public virtual void visit(Input node)
        {
            circuit.AddInput(node);
        }

        public virtual void visit(Probe node)
        {
            circuit.AddProbe(node);
        }
    }
}
