using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public abstract class Node
    {
        protected bool? value;
        protected bool? lastValue;

        /* FIXME: methode synchronized maken */
        public virtual void SetValue(bool? newValue)
        {
            this.value = newValue;
            // TODO nieuwe setvalue aanroepen?
        }
    }
}
