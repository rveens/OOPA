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

        private void startThread(Node node)
        {
            /* Thread thread = new Thread(() => node.DoAction(true));
            thread.Start(); */

            ThreadPool.QueueUserWorkItem(new WaitCallback(x => node.DoAction(true)));
        }
    }

}
