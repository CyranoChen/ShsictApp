using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shsict.AutoRefresh
{
    class EventFavouriteRefresh : Event
    {
        public EventFavouriteRefresh()
        {
            ScheduleType = "Shsict.AutoRefresh.FavouriteCacheRefreshEvent";
            string FavouriteRefreshRateStr = ConfigurationManager.AppSettings.GetValues("FavouriteRefreshRate")[0].ToString();
            Minutes = Int32.Parse(FavouriteRefreshRateStr);

            UpdateTime();
        }
    }
}
