using System;
using System.Collections.Generic;
using System.Threading;

namespace Shsict.Scheduler
{
    public class SchedulerManager
    {
        public SchedulerManager(List<Job> list)
        {
            jobsList = list;
        }

        public void Start()
        {
            while (true)
            {
                //执行每一个任务 
                foreach (Job job in jobsList)
                {
                    ThreadStart myThreadDelegate = new ThreadStart(job.Execute);
                    Thread myThread = new Thread(myThreadDelegate);

                    myThread.Start();

                    Thread.Sleep(job.SleepInterval);
                }
            }
        }

        private List<Job> jobsList;
        public List<Job> JobsList
        {
            set { jobsList = value; }
            get { return jobsList; }
        }
    }
}
