using Shsict.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shsict.AutoRefresh
{
    class FavouriteCacheRefreshEvent : IEvent
    {
        public void Execute(object state)
        {
            DateTime dateTime;

            if (state is DateTime)
            {
                dateTime = (DateTime)state;

                Console.WriteLine("Begin Refresh Favourite, Please Wait...");

                MyFavourite.ReloadAll("database");

                LogEvent.logSuccess("Favourite Refresh Cache Success");
            }
            else
            {
                LogEvent.logErroMsg("Favourite Refresh  Cache  Get Time Error");
              
            }
        }
    }
}
