using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public class XorNode : LogicNode
    {
        public XorNode()
        {

        }

        protected override bool Calculate()
        {
            if (values.Count == 2)
            {
                if (values[0].Value && values[1].Value)
                {
                    value = true;
                    return true;
                }
                value = values[0] | values[1];
                return true;
            }
            return false;
            // if (value1.Value && value2.Value)
            //return false;

            //return value1 | value2;
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
