using Shsict.Entity;
using System;

namespace Shsict.AutoRefresh
{
    class VesselCacheRefreshEvent : IEvent
    {
        public void Execute(object state)
        {
            DateTime dateTime;

            if (state is DateTime)
            {
                dateTime = (DateTime)state;

                Console.WriteLine("Begin Refresh Vessel, Please Wait...");

                OVesselPlan.Cache.RefreshCache();
                Console.WriteLine("VesselPlan Refresh Cache Success");
                
                PortOfCall.Cache.RefreshCache();
                Console.WriteLine("PortOfCall Refresh Cache Success");
              
            }
            else
            {
                Console.WriteLine("VesselPlan&PortOfCall Refresh  Cache  Get Time Error");
                //  AOCLog.logErro("WorkCallCenterDAY getTimeError");
            }
        }
    }
}
