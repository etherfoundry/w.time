using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace w_time.data.dto
{
    class dto
    {
        protected abstract string _tableName();

        public string TableName
        {
            get
            {
                return this._tableName();
            }
        }
    }
}
