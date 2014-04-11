using System;
using System.Configuration;

namespace Shsict.AutoRefresh
{
    class EventNoticeRefresh : Event
    {
        public EventNoticeRefresh()
        {
            ScheduleType = "Shsict.AutoRefresh.NoticeCacheRefreshEvent";
            string NoticeRefreshRateStr = ConfigurationManager.AppSettings.GetValues("NoticeRefreshRate")[0].ToString();
            Minutes = Int32.Parse(NoticeRefreshRateStr);
            UpdateTime();
        }
    }
}
