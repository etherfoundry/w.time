using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using w_time.data.schema;

namespace w_time.data.migrations
{
    class _1_BaseSchema : BaseMigration
    {
        public override bool up()
        {
            Table EventTable = new Table("Event");

            EventTable.Columns.Add(new BigIntColumn() {
                    Name = "ID",
                    IsPrimaryKey = true,
                    IsIdentity = true,
                    IdentityIncrement = 1,
                    IdentitySeed = 1,
                });

            EventTable.Columns.Add(new DateTimeColumn() { Name = "Time" });
            EventTable.Columns.Add(new NumericColumn(10,3) { Name = "Duration" });
            EventTable.Columns.Add(new IntegerColumn() { Name = "EventType_FK" });
            EventTable.Columns.Add(new IntegerColumn() { Name = "Process_FK", IsNullable = true });
            EventTable.Columns.Add(new IntegerColumn() { Name = "Category_FK", IsNullable = true });
            EventTable.Columns.Add(new NVarCharColumn(300) { Name = "WindowTitle", IsNullable = true });
            EventTable.Columns.Add(new NVarCharColumn(200) { Name = "Notes", IsNullable = true });
            this.CreateTable(EventTable);


            return false;
        }

        public override bool down()
        {
            return false;
        }
    }
}
