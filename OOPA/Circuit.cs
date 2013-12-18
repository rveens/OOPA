using System;
using System.Threading;
using System.Collections.Generic;

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
            inputs.ForEach(startThread);
        }

        public void PrintResults()
        {
            foreach (Probe p in probes)
            {
                Console.Out.WriteLine("Node " + p.getKey() + " is " + p.GetValue());
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

        [STAThread]
        private void startThread(Node node)
        {
            ThreadManager.StartThread(() => node.DoAction(true));
        }
    }

}
