using System;
using System.Collections.Generic;
using System.Threading;

namespace Shsict.AutoRefresh
{
    /// <summary>
    /// EventManager is called from the EventHttpModule (or another means of scheduling a Timer). Its sole purpose
    /// is to iterate over an array of Events and deterimine of the Event's IEvent should be processed. All events are
    /// added to the managed threadpool. 
    /// </summary>
    public class EventManager
    {
        private List<Event> eventsList;
        public List<Event> EventsList
        {
            set { eventsList = value; }
            get { return eventsList; }
        }

        public EventManager() { }

        public EventManager(List<Event> myEventsList)
        {
            EventsList = myEventsList;
        }

        public static readonly int TimerMinutesInterval = 1;

        public void Execute()
        {
            DateTime dateTime = DateTime.Now;
            foreach (Event myEvent in EventsList)
            {
                if (myEvent != null)
                {
                    if (myEvent.ShouldExecute)
                    {
                        myEvent.UpdateTime();
                        ThreadPool.QueueUserWorkItem(new WaitCallback(myEvent.Excute), (object)dateTime);
                    }
                }
            }
        }
    }
}

