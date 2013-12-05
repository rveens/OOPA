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

        public override void DoAction(bool? newValue)
        {
            throw new NotImplementedException();
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
