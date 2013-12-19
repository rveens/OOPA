using System;
using System.Threading;
using System.Collections.Generic;

namespace OOPA
{
    /// <summary>
    /// Circuit resembles the entry point of the model.
    /// Circuit also has a method  for starting the circuit.
    /// </summary>
    public class Circuit
    {
        /// <summary>
        /// A List with the circuit inputs.
        /// </summary>
        private List<Input> inputs;
        /// <summary>
        /// A list with cicuit probes, or outputs.
        /// </summary>
        private List<Probe> probes;

        /// <summary>
        /// Constructor of Circuit that initalizes the List members.
        /// </summary>
        public Circuit()
        {
            inputs = new List<Input>();
            probes = new List<Probe>();
        }

        /// <summary>
        /// Public method that should be called to run the Circuit.
        /// </summary>
        public void Start()
        {
            inputs.ForEach(startThread);
        }

        /// <summary>
        /// Print the results of all the probes.
        /// Note: probes also print their autput when probe.doAction is reached.
        /// </summary>
        public void PrintResults()
        {
            foreach (Probe p in probes)
            {
                Console.Out.WriteLine("Node " + p.getKey() + " is " + p.GetValue());
            }
        }

        /// <summary>
        /// Add an input to the inputs in the circuit.
        /// </summary>
        /// <param name="ip">The input that has to be added.</param>
        public void AddInput(Input ip)
        {
            inputs.Add(ip);
        }

        /// <summary>
        /// Add an probe or output to the probes of the circuit.
        /// </summary>
        /// <param name="pr"></param>
        public void AddProbe(Probe pr)
        {
            probes.Add(pr);
        }

        /// <summary>
        /// A method that is used to start a new thread.
        /// </summary>
        /// <param name="node">The node that provides work for the thread that is going to be started.</param>
        private static void startThread(Node node)
        {
            ThreadManager.StartThread(() => node.DoAction(true));
        }
    }

}
