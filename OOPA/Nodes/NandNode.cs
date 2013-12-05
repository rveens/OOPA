using System;

namespace OOPA
{
    public class NandNode : LogicNode
    {
        public NandNode()
        {

        }

        protected override bool Calculate()
        {
            if (inputValues.Count == 2)
            {
                value = !(inputValues[0] & inputValues[1]);
                return true;
            }
            return false;
        }

        public override Object Clone()
        {
            return new NandNode();
        }
        public override String getKey()
        {
            return "NAND";
        }
    }
}
