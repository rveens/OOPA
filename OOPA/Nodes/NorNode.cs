using System;

namespace OOPA
{
    public class NorNode : LogicNode
    {
        public NorNode()
        {

        }

        protected override bool Calculate()
        {
            if (inputValues.Count == 2)
            {
                value = !(inputValues[0] | inputValues[1]);
                return true;
            }
            return false;
        }

        public override Object Clone()
        {
            return new NorNode();
        }
        public override String getKey()
        {
            return "NOR";
        }
    }
}
