﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using w_time.data.schema;

namespace w_time.data
{
    abstract class BaseMigration
    {
        public abstract bool up();
        public abstract bool down();

        protected void CreateTable(Table table)
        {
            System.Diagnostics.Debug.WriteLine(table.GetCreateTableSQL());
            DAL dal = new DAL();
            dal.ExecuteRawQuery(table.GetCreateTableSQL());
        }
    }
}
