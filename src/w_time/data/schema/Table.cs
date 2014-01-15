using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace w_time.data.schema
{
    class Table
    {
        public string Name;
        public List<Column> Columns = new List<Column>();

        public Table(string Name)
        {
            this.Name = Name;
        }

        public string GetCreateTableSQL()
        {
            StringBuilder result = new StringBuilder("CREATE TABLE ");
            result.AppendFormat("[{0}] ({1})", this.Name, this.GetColumnDefinitionSQL());
            return result.ToString();
        }

        private string GetColumnDefinitionSQL()
        {
            StringBuilder result = new StringBuilder();
            bool first = true;

            foreach(Column col in this.Columns)
            {
                if (!first)
                {
                    result.Append(", ");
                }

                result.Append(col.toColumnDefinition());
                first = false;
            }

            return result.ToString();
        }
    }
}
