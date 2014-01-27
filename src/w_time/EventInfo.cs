using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace w_time
{
    class EventInfo
    {
        public string WindowTitle;
        public string WindowProcess;

        public bool Equals(EventInfo evt)
        {
            return this.WindowTitle == evt.WindowTitle &&
                this.WindowProcess == evt.WindowProcess;
        }
    }
}
