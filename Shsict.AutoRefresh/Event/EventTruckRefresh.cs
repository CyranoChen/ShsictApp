using System;
using System.Configuration;

namespace Shsict.AutoRefresh
{
    class EventTruckRefresh : Event
    {
        public EventTruckRefresh()
        {
            ScheduleType = "Shsict.AutoRefresh.TruckCacheRefreshEvent";
            string TruckRefreshRateStr = ConfigurationManager.AppSettings.GetValues("TruckRefreshRate")[0].ToString();
            Minutes = Int32.Parse(TruckRefreshRateStr);

            UpdateTime();
        }
    }
}
