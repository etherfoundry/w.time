using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace w_time
{
    /// <summary>
    /// Represents an error that occurs when creating the database
    /// </summary>
    class DatabaseExistsException : Exception
    {
        public override string Message
        {
            get
            {
                return "The database already exists and could not be created. (This should not happen)";
            }
        }

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
