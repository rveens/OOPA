using System;
using System.Collections.Generic;
using System.Threading;

namespace OOPA
{
    public abstract class ThreadManager
    {
        public static event IsThreadsDoneHandler IsThreadsDone;
        
        private readonly static List<ManualResetEvent> resetEvents = new List<ManualResetEvent>();

        public static void StartThread(Action method)
        {
            var resetEvent = new ManualResetEvent(false);

            ThreadPool.QueueUserWorkItem(
            x =>
            {
                method();
                resetEvent.Set();
            });

            resetEvents.Add(resetEvent);
        }

        public static void StartWait()
        {
            //TODO: Fix NotSupportedException below (!)

            try
            {
                WaitHandle[] events = resetEvents.ToArray();
                WaitHandle.WaitAll(events);

                if (IsThreadsDone != null)
                    IsThreadsDone();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }

    public delegate void IsThreadsDoneHandler();
}
