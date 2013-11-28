using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPA
{
    public class Circuit
    {
        private List<Input> inputs;
        private List<Probe> probes;

        public void Start()
        {
            foreach (Input i in inputs)
                i.DoAction(true);
        }

        public void PrintResults()
        {
            foreach (Probe p in probes)
            {
            }
        }
    }


}
