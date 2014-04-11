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
                Console.WriteLine("ContainerEload Refresh Cache Success");

                ContainerMain.Cache.RefreshCache();
                Console.WriteLine("ContainerMain Refresh Cache Success");

                ContainerPlan.Cache.RefreshCache();
                Console.WriteLine("ContainerPlan Refresh Cache Success");

                ContainerDetail.Cache.RefreshCache();
                Console.WriteLine("ContainerDetail Refresh Cache Success");
            }
            else
            {
                Console.WriteLine("Container Refresh  Cache  Get Time Error");
                //  AOCLog.logErro("WorkCallCenterDAY getTimeError");
            }
        }
    }
}
