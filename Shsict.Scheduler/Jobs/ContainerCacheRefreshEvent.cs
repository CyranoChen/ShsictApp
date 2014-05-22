using System;
using System.IO;
using System.Threading;
using Shsict.Entity;
using System.Configuration;

namespace Shsict.Scheduler
{
    public class ContainerCacheRefreshEvent : Job
    {
        public ContainerCacheRefreshEvent()
        {
            ScheduleType = "Shsict.Scheduler.IContainerCacheRefreshEvent";
            DueTimeInterval = 60 * 1000 * 2;

            string ContainerRefreshRateStr = ConfigurationManager.AppSettings.GetValues("ContainerRefreshRate")[0].ToString();
            PeriodInterval = 60 * 1000 * Int32.Parse(ContainerRefreshRateStr);

        }
    }

    public class IContainerCacheRefreshEvent : IJob
    {
        private int _IsRunning;
        public void Execute(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {
                    ContainerEload.Cache.RefreshCache();
                    LogEvent.logSuccess("ContainerEload Refresh Cache Success");

                    ContainerMain.Cache.RefreshCache();
                    LogEvent.logSuccess("ContainerMain Refresh Cache Success");

                    ContainerPlan.Cache.RefreshCache();
                    LogEvent.logSuccess("ContainerPlan Refresh Cache Success");

                    ContainerDetail.Cache.RefreshCache();
                    LogEvent.logSuccess("ContainerDetail Refresh Cache Success");

                }
                catch (Exception ex)
                {

                    LogEvent.logErroMsg("Container Refresh  Cache  Get Time Error EX:" + ex.Message);
                }
                finally
                {
                    Interlocked.Exchange(ref _IsRunning, 0);
                }
            }
        }
    }
}
