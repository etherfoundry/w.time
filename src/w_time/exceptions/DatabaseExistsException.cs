using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace w_time
{
    class DatabaseExistsException : Exception
    {
        public DatabaseExistsException()
        {
        }

        public DatabaseExistsException(string message)
            : base(message)
        {
        }

        public DatabaseExistsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
