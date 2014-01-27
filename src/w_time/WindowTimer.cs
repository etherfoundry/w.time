using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace w_time
{
    class WindowTimer
    {
        protected static Timer timer;
        public static int timerInterval = 100;
        public void start()
        {
            timer = new System.Timers.Timer(timerInterval);
            timer.Elapsed += new ElapsedEventHandler(onElapsed);
            timer.Enabled = true;
        }

        private void onElapsed(object source, ElapsedEventArgs e)
        {
            EventInfo ev = Win32API.GetActiveInfo();

            Console.WriteLine("The Elapsed event was raised at {0}. The active window is {1} ({2})", e.SignalTime, ev.WindowTitle, ev.WindowProcess);
        }
    }
}
