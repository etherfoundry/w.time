using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace w_time
{
    class MainContext : ApplicationContext
    {
        public MainContext()
        {
            WindowTimer timer = new WindowTimer();
            timer.start();

        }
    }
}
