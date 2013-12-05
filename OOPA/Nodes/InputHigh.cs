using System;

namespace OOPA
{
    class InputHigh : Input
    {
        public override Object Clone()
        {
            return new InputHigh();
        }

        public override string getKey()
        {
            return "INPUT_HIGH";
        }
    }
}
