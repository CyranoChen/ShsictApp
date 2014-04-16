using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Shsict.AutoRefresh
{
    class EventTVDangerPlanRefresh: Event
    {
        public EventTVDangerPlanRefresh()
        {
            ScheduleType = "Shsict.AutoRefresh.TVDangerPlanRefreshEvent";
            string TVDangerPlanRefreshRateStr = ConfigurationManager.AppSettings.GetValues("TVDangerPlanRefreshRate")[0].ToString();
            Minutes = Int32.Parse(TVDangerPlanRefreshRateStr);
            Minutes = 1;
            UpdateTime();
        }
    }
}
