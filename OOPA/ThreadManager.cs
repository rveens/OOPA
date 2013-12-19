using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OOPA
{
    public abstract class ThreadManager
    {
        public static event IsThreadsDoneHandler IsThreadsDone;

        private readonly static List<Task> tasks = new List<Task>();

        public static void StartThread(Action method)
        {
            var task = Task.Factory.StartNew(method);
            tasks.Add(task);
        }

        //public static void StartWait()
        //{
        //    var tempTaskArray = tasks.ToArray();
        //    Task.WaitAll(tempTaskArray);

        //    if (IsThreadsDone != null)
        //        IsThreadsDone();
        //}
    }

    public delegate void IsThreadsDoneHandler();
}
