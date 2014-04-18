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
                LogEvent.logSuccess("VesselPlan Refresh Cache Success");
                
                PortOfCall.Cache.RefreshCache();
                LogEvent.logSuccess("PortOfCall Refresh Cache Success");
              
            }
            else
            {
                LogEvent.logErroMsg("VesselPlan&PortOfCall Refresh Refresh  Cache  Get Time Error");
  
            }
        }
    }
}
