using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace w_time.data
{
    abstract class BaseMigration
    {
        public abstract bool up();
        public abstract bool down();
    }
}
