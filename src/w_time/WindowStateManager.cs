using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using w_time.data;

namespace w_time
{
    class WindowStateManager
    {
        private static EventInfo currentState;
        private static EventInfo previousState;
        private static DateTime eventStartTime;
        private static DateTime eventEndTime;
        
        public static void setState(EventInfo evt)
        {
            if (currentState == null)
            {
                currentState = evt;
                eventStartTime = DateTime.Now;
                return;
            }

            if (!evt.Equals(currentState))
            {
                eventEndTime = DateTime.Now;
                previousState = currentState;
                currentState = evt;
                
                CreateEvent(previousState, eventStartTime, eventEndTime);
                
            }
        }

        public static void CreateEvent(EventInfo evt, DateTime start, DateTime end)
        {
            TimeSpan duration = end-start;
            DAL dal = new DAL();
            dal.ExecuteRawQuery("INSERT INTO [Event] (Time, Duration, EventType_FK)"
        }
    }
}
