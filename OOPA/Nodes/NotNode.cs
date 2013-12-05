using System;

namespace OOPA
{
    public class NotNode : LogicNode
    {
        public NotNode()
        {

        }

        protected override bool Calculate()
        {
            value = !this.inputValues[0];
            return true;
        }

        public override Object Clone()
        {
            return new NotNode();
        }
        public override String getKey()
        {
            return "NOT";
        }
    }
}
