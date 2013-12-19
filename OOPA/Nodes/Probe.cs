using System;

namespace OOPA
{
    public class Probe : Node
    {
        public Probe()
        {

        }

        public override void AddOutput(Node n)
        {
            //TODO: Create visitor for AddOutput
        }

        public override void accept(NodeVisitor visitor)
        {
            visitor.visit(this);
        }

        public override void DoAction(bool? newValue)
        {
            value = newValue;
            Console.WriteLine(this.GetType() + " " + this.value);
        }

        public override Object Clone()
        {
            return new Probe();
        }
        public override string getKey()
        {
            return "PROBE";
        }
    }
}
