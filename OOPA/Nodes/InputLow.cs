﻿using System;

namespace OOPA
{
    class InputLow : Input
    {
        public override Object Clone()
        {
            return new InputLow();
        }

        public override string getKey()
        {
            return "INPUT_LOW";
        }

        public override void DoAction(bool? newValue)
        {
            base.DoAction(false);
        }
    }
}
