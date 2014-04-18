using System;
using System.Configuration;

namespace Shsict.AutoRefresh
{
    class EventVesselRefresh : Event
    {
        public EventVesselRefresh()
        {
            ScheduleType = "Shsict.AutoRefresh.VesselCacheRefreshEvent";
            string VesselRefreshRateStr = ConfigurationManager.AppSettings.GetValues("VesselRefreshRate")[0].ToString();
            Minutes = Int32.Parse(VesselRefreshRateStr);
            UpdateTime();
        }
    }
}
