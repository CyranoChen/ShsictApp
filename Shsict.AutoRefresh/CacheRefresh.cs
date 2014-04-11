using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shsict.AutoRefresh
{
    public class CacheRefresh
    {
        static EventManager emRefreshCach = new EventManager();

        private static ThreadStart thdStartRefreshCach;
        public static Thread thdRefreshCach;

        public bool Start()
        {
            List<Event> elRefreshCach = new List<Event>();

            Event eventContainer = new EventContainerRefresh();
            Event eventVessel = new EventVesselRefresh();
            Event eventTruck = new EventTruckRefresh();
            Event eventNotice = new EventNoticeRefresh();

            elRefreshCach.Add(eventContainer);
            elRefreshCach.Add(eventVessel);
            elRefreshCach.Add(eventTruck);
            elRefreshCach.Add(eventNotice);
            emRefreshCach.EventsList = elRefreshCach;
            thdStartRefreshCach = new ThreadStart(StartRefreshCach);
            thdRefreshCach = new Thread(thdStartRefreshCach);

            if (!CacheRefresh.thdRefreshCach.IsAlive)
            {
                thdRefreshCach.Start();

                return true;
            }
            else
            {
                return false;
            
            }
        }
        public bool End()
        {
            if (CacheRefresh.thdRefreshCach.IsAlive)
            {
                thdRefreshCach.Abort();

                return true;
            }
            else
            {
                return false;

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
