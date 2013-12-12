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

        public override void visit(Node node) { }

        public override void visit(LogicNode node) { }

        public override void visit(Input node)
        {
            circuit.AddInput(node);
        }

        public override void visit(Probe node)
        {
            circuit.AddProbe(node);
        }
    }
}
