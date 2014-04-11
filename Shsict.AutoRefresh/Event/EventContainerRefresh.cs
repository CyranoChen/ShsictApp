using System;
using System.Configuration;

namespace Shsict.AutoRefresh
{
    class EventContainerRefresh : Event
    {
        public EventContainerRefresh()
        {
            ScheduleType = "Shsict.AutoRefresh.ContainerCacheRefreshEvent";
            string ContainerRefreshRateStr = ConfigurationManager.AppSettings.GetValues("ContainerRefreshRate")[0].ToString();
            Minutes = Int32.Parse(ContainerRefreshRateStr);
            UpdateTime();
        }
    }
}
