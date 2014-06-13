using System;
using System.IO;
using System.Threading;

using System.Configuration;
using Shsict.Entity;
using Shsict.InternalWeb.Controllers;

namespace Shsict.InternalWeb.Scheduler
{
    public class OperationCacheRefreshEvent : Job
    {
        public OperationCacheRefreshEvent()
        {
            ScheduleType = "Shsict.InternalWeb.Scheduler.IOperationCacheRefreshEvent";
            DueTimeInterval = 60 * 1000 * 2;

            string ContainerRefreshRateStr = ConfigurationManager.AppSettings.GetValues("OperationRefreshRate")[0].ToString();
            PeriodInterval = 60 * 1000 * Int32.Parse(ContainerRefreshRateStr);

        }
    }

    public class IOperationCacheRefreshEvent : IJob
    {
        private int _IsRunning;
        public void Execute(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {
                    VesselAmountController.Cache.RefreshCache();
                    LogEvent.logSuccess("VesselAmount Refresh Cache Success");

                    TruckOperationCycleController.Cache.RefreshCache();
                    LogEvent.logSuccess("TruckOperation Refresh Cache Success");

                }
                catch (Exception ex)
                {

                    LogEvent.logErroMsg("Operation Refresh  Cache  Get Time Error EX:" + ex.Message);
                }
                finally
                {
                    Interlocked.Exchange(ref _IsRunning, 0);
                }
            }
        }
    }
}
