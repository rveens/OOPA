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

        public Circuit()
        {
            inputs = new List<Input>();
            probes = new List<Probe>();
        }

        public void Start()
        {
            foreach (Input i in inputs)
                i.DoAction(true);
        }

        public void PrintResults()
        {
            foreach (Probe p in probes)
            {
                Console.Out.WriteLine(p.GetValue());
            }
        }

        public void AddInput(Input ip)
        {
            inputs.Add(ip);
        }

        public void AddProbe(Probe pr)
        {
            probes.Add(pr);
        }
    }

}
