using System;
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
        protected abstract int _version();
        protected abstract string _name();

        public int version
        {
            get { return this._version(); }
        }

        public string name
        {
            get { return this._name(); }
        }

        protected void CreateTable(Table table)
        {
            System.Diagnostics.Debug.WriteLine(table.GetCreateTableSQL());
            DAL dal = new DAL();
            dal.ExecuteRawQuery(table.GetCreateTableSQL());
        }

        protected void MarkComplete()
        {
            DAL dal = new DAL();
            dal.ExecuteRawQuery("");
        }
    }
}
