using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace w_time.data.schema
{
    class BigIntColumn : Column {
        public BigIntColumn() { this._Type = DataType.bigint; }
    }

    class IntegerColumn : Column
    {
        public IntegerColumn() { this._Type = DataType.integer; }
    }

    class SmallIntColumn : Column
    {
        public SmallIntColumn() { this._Type = DataType.smallint; }
    }

    class TinyIntColumn : Column
    {
        public TinyIntColumn() { this._Type = DataType.tinyint; }
    }

    class BitColumn : Column
    {
        public BitColumn() { this._Type = DataType.bit; }
    }

    class NumericColumn : Column
    {
        public int Precision;
        public int Scale;

        public NumericColumn(int Precision, int Scale)
        {
            this._Type = DataType.numeric;
            this.Precision = Precision;
            this.Scale = Scale;
        }

        protected override string GetColumnTypeSize()
        {
            return String.Format("({0}, {1})", this.Precision, this.Scale);
        }
    }

    class MoneyColumn : Column
    {
        public MoneyColumn() { this._Type = DataType.money; }
    }

    class FloatColumn : Column
    {
        public FloatColumn() { this._Type = DataType.@float; }
    }

    class RealColumn : Column
    {
        public RealColumn() { this._Type = DataType.real; }
    }

    class DateTimeColumn : Column
    {
        public DateTimeColumn() { this._Type = DataType.datetime; }
    }

    class NCharColumn : Column
    {
        public int Length;

        public NCharColumn(int Length)
        {
            this._Type = DataType.nchar;
            this.Length = Length;
        }

        protected override string GetColumnTypeSize()
        {
            return String.Format("({0})", this.Length);
        }
    }

    class NVarCharColumn : Column
    {
        public int MaxLength;

        public NVarCharColumn(int MaxLength)
        {
            this._Type = DataType.nvarchar;
            this.MaxLength = MaxLength;
        }

        protected override string GetColumnTypeSize()
        {
            return String.Format("({0})", this.MaxLength);
        }
    }

    class NTextColumn : Column
    {
        public NTextColumn() { this._Type = DataType.ntext; }
    }

    class BinaryColumn : Column
    {
        public int Length;

        public BinaryColumn(int Length)
        {
            this._Type = DataType.binary;
            this.Length = Length;
        }

        protected override string GetColumnTypeSize()
        {
            return String.Format("({0})", this.Length);
        }
    }

    class VarBinaryColumn : Column
    {
        public int MaxLength;
        public VarBinaryColumn(int MaxLength)
        {
            this._Type = DataType.varbinary;
            this.MaxLength = MaxLength;
        }

        protected override string GetColumnTypeSize()
        {
            return String.Format("({0})", this.MaxLength);
        }
    }

    class ImageColumn : Column
    {
        public ImageColumn() { this._Type = DataType.image; }
    }

    class UniqueIdentifierColumn : Column
    {
        public UniqueIdentifierColumn() { this._Type = DataType.uniqueidentifier; }
    }
}
