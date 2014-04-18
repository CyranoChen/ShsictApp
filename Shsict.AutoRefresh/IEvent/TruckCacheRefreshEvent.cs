using Shsict.Entity;
using System;

namespace Shsict.AutoRefresh
{
    class TruckCacheRefreshEvent : IEvent
    {
        public void Execute(object state)
        {
            DateTime dateTime;

            if (state is DateTime)
            {
                dateTime = (DateTime)state;

                Console.WriteLine("Begin Refresh Truck, Please Wait...");

                OTruck.Cache.RefreshCache();
                LogEvent.logSuccess("Truck Refresh Cache Success");
            }
            else
            {
                LogEvent.logErroMsg("Truck Refresh  Cache  Get Time Error");
            }
        }
    }
}
