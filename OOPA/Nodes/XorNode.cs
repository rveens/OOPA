using System;

namespace OOPA
{
    public class XorNode : LogicNode
    {
        public XorNode()
        {

        }

        protected override bool Calculate()
        {
            if (inputValues.Count == 2)
            {
                if (inputValues[0].Value && inputValues[1].Value)
                {
                    value = true;
                    return true;
                }
                value = inputValues[0] | inputValues[1];
                return true;
            }
            return false;
        }

        public override Object Clone()
        {
            return new XorNode();
        }
        public override String getKey()
        {
            return "XOR";
        }
    }
}
