using Shsict.Entity;
using System;

namespace Shsict.AutoRefresh
{
    class NoticeCacheRefreshEvent : IEvent
    {
        public void Execute(object state)
        {
            DateTime dateTime;

            if (state is DateTime)
            {
                dateTime = (DateTime)state;

                Console.WriteLine("Begin Refresh Notice, Please Wait...");

                Notice.Cache.RefreshCache();
                LogEvent.logSuccess("Notice Refresh Cache Success");
            }
            else
            {
                LogEvent.logErroMsg("Notice Refresh  Cache  Get Time Error");

            }
        }
    }
}
