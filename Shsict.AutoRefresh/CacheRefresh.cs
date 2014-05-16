using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shsict.AutoRefresh
{
    public static class CacheRefresh
    {
        static EventManager emRefreshCach = new EventManager();

        private static ThreadStart thdStartRefreshCach;
        public static Thread thdRefreshCach;

        public static ThreadState Start()
        {
            try
            {
                List<Event> elRefreshCach = new List<Event>();

                Event eventContainer = new EventContainerRefresh();
                Event eventVessel = new EventVesselRefresh();
                Event eventTruck = new EventTruckRefresh();
                Event eventNotice = new EventNoticeRefresh();
                Event eventTVDangerPlan = new EventTVDangerPlanRefresh();
                Event eventFavouriteRefresh = new EventFavouriteRefresh();


                elRefreshCach.Add(eventContainer);
                elRefreshCach.Add(eventVessel);
                elRefreshCach.Add(eventTruck);
                elRefreshCach.Add(eventNotice);
                elRefreshCach.Add(eventTVDangerPlan);
                elRefreshCach.Add(eventFavouriteRefresh);


                emRefreshCach.EventsList = elRefreshCach;
                thdStartRefreshCach = new ThreadStart(StartRefreshCach);
                thdRefreshCach = new Thread(thdStartRefreshCach);

                if (thdRefreshCach.ThreadState.Equals(ThreadState.Unstarted))
                {
                    thdRefreshCach.Start();
                }

                return thdRefreshCach.ThreadState;
            }
            catch
            {
                return thdRefreshCach.ThreadState;
            }
        }

        public static ThreadState Suspend()
        {
            try
            {
                if (!thdRefreshCach.ThreadState.Equals(ThreadState.Stopped))
                {
                    thdRefreshCach.Suspend();
                }

                return thdRefreshCach.ThreadState;
            }
            catch
            {
                return thdRefreshCach.ThreadState;
            }
        }

        public static ThreadState Resume()
        {
            try
            {
                if (thdRefreshCach.ThreadState.Equals(ThreadState.Suspended))
                {
                    thdRefreshCach.Resume();
                }

                return thdRefreshCach.ThreadState;
            }
            catch
            {
                return thdRefreshCach.ThreadState;
            }
        }

        private static void StartRefreshCach()
        {
            while (true)
            {
                emRefreshCach.Execute();
                Thread.Sleep(EventManager.TimerMinutesInterval * 10000); //每10秒钟执行一次
            }
        }

    }
}
