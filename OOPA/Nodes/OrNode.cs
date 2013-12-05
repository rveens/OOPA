using System;

namespace OOPA
{
    public class OrNode : LogicNode
    {
        public OrNode()
        {

        }

        protected override bool Calculate()
        {
            if (inputValues.Count == 2)
            {
                value = inputValues[0] | inputValues[1];
                return true;
            }
            return false;
        }

        public override Object Clone()
        {
            return new OrNode();
        }

        public override String getKey()
        {
            return "OR";
        }
    }
}
