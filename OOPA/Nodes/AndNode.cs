using System;

namespace OOPA
{
    public class AndNode : LogicNode
    {
        public AndNode()
        {
                
        }

        protected override bool Calculate()
        {
            if (inputValues.Count == 2)
            {
                value = inputValues[0] & inputValues[1];
                return true;
            }
            return false;
        }

        public override Object Clone()
        {
            return new AndNode();
        }
        public override String getKey()
        {
            return "AND";
        }
    }
}
