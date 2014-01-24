using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace w_time.data
{
    class ErrorLogger
    {
        public static void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
