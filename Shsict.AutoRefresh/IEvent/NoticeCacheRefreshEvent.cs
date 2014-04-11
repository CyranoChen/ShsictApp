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
                Console.WriteLine("Notice Refresh Cache Success");
            }
            else
            {
                Console.WriteLine("Notice Refresh  Cache  Get Time Error");
                //  AOCLog.logErro("WorkCallCenterDAY getTimeError");
            }
        }
    }
}
