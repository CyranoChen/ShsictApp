using Shsict.Entity;
using System;

namespace Shsict.AutoRefresh
{
    class ContainerCacheRefreshEvent : IEvent
    {
        public void Execute(object state)
        {
            DateTime dateTime;

            if (state is DateTime)
            {
                dateTime = (DateTime)state;

                Console.WriteLine("Begin Refresh Container, Please Wait...");

                ContainerEload.Cache.RefreshCache();
                LogEvent.logSuccess("ContainerEload Refresh Cache Success");

                ContainerMain.Cache.RefreshCache();
                LogEvent.logSuccess("ContainerMain Refresh Cache Success");

                ContainerPlan.Cache.RefreshCache();
                LogEvent.logSuccess("ContainerPlan Refresh Cache Success");

                ContainerDetail.Cache.RefreshCache();
                LogEvent.logSuccess("ContainerDetail Refresh Cache Success");
            }
            else
            {
                LogEvent.logErroMsg("Container Refresh  Cache  Get Time Error");
                //  AOCLog.logErro("WorkCallCenterDAY getTimeError");
            }
        }
    }
}
