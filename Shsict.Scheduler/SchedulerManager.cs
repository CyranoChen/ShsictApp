using System;
using System.Collections.Generic;
using System.Threading;

namespace Shsict.Scheduler
{
    public static class SchedulerManager
    {
        public static void Start()
        {
            try
            {
                Job j1 = new SampleJob();
                Job j2 = new SampleJob2();

                CurrentJobsList.Add(j1.ScheduleType, j1.Execute());
                CurrentJobsList.Add(j2.ScheduleType, j2.Execute());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Stop()
        {
            try
            {
                if (CurrentJobsList != null && CurrentJobsList.Count > 0)
                {
                    foreach (var item in CurrentJobsList)
                    {
                        item.Value.Dispose();
                    }

                    CurrentJobsList.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Dictionary<string, Timer> CurrentJobsList = new Dictionary<string, Timer>();
    }
}
