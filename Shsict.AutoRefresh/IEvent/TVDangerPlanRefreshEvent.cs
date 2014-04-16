using Shsict.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shsict.AutoRefresh
{
    class TVDangerPlanRefreshEvent : IEvent
    {
        public void Execute(object state)
        {
            DateTime dateTime;

            if (state is DateTime)
            {
                dateTime = (DateTime)state;

                Console.WriteLine("Begin Refresh TVDangerPlan, Please Wait...");

                TVDangerPlan.Cache.RefreshCache();
                Console.WriteLine("TVDangerPlan Refresh Cache Success");

                TVDangerContainer.Cache.RefreshCache();
                Console.WriteLine("TVDangerContainer Refresh Cache Success");

            }
            else
            {
                Console.WriteLine("TVDangerPlan&TVDangerContainer Refresh  Cache  Get Time Error");
                //  AOCLog.logErro("WorkCallCenterDAY getTimeError");
            }
        }
    }
}