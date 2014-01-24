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
            Table EventTypeTable = new Table("EventType");
            EventTypeTable.Columns.Add(new PrimaryKeyIntColumn());
            EventTypeTable.Columns.Add(new NVarCharColumn(45) { Name = "Name" });

            Table ProcessTable = new Table("Process");
            ProcessTable.Columns.Add(new PrimaryKeyIntColumn());
            ProcessTable.Columns.Add(new NVarCharColumn(255) { Name = "Name" });

            Table CategoryTable = new Table("Category");
            CategoryTable.Columns.Add(new PrimaryKeyIntColumn());
            CategoryTable.Columns.Add(new IntegerColumn() { Name = "ParentCategory_FK",
                ReferencesColumn = "ID", ReferencesTable = "Category"});
            CategoryTable.Columns.Add(new NVarCharColumn(100) { Name = "Name" });

            Table EventTable = new Table("Event");
            EventTable.Columns.Add(new PrimaryKeyIntColumn(Column.DataType.bigint));

            EventTable.Columns.Add(new DateTimeColumn() { Name = "Time" });
            EventTable.Columns.Add(new NumericColumn(10, 3) { Name = "Duration" });
            EventTable.Columns.Add(new IntegerColumn()
            {
                Name = "EventType_FK",
                ReferencesTable = "EventType",
                ReferencesColumn = "ID",
            });

            EventTable.Columns.Add(new IntegerColumn()
            {
                Name = "Process_FK",
                IsNullable = true,
                ReferencesTable = "Process",
                ReferencesColumn = "ID",
            });

            EventTable.Columns.Add(new IntegerColumn()
            {
                Name = "Category_FK",
                IsNullable = true,
                ReferencesTable = "Category",
                ReferencesColumn = "ID",
            });

            EventTable.Columns.Add(new NVarCharColumn(300) { Name = "WindowTitle", IsNullable = true });
            EventTable.Columns.Add(new NVarCharColumn(200) { Name = "Notes", IsNullable = true });

            this.CreateTable(EventTypeTable);
            this.CreateTable(ProcessTable);
            this.CreateTable(CategoryTable);

            // References Process and Category
            this.CreateTable(EventTable);
            return false;
        }

        public override bool down()
        {
            return false;
        }
    }
}
