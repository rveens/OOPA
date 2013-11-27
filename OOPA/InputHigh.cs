using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPA
{
    class InputHigh : Input
    {
        public override Object Clone()
        {
            return new InputLow();
        }

        public override string getKey()
        {
            return "INPUT_HIGH";
        }
    }
}
