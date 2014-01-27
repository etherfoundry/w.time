using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace w_time.data.dto
{
    class EventTypeData : dto
    {
        public int ID;
        public string name;

        public void Insert()
        {
            DAL dal = new DAL();
            dal.
        }

        protected override string _tableName()
        {
            return "EventType"
        }
    }
}
