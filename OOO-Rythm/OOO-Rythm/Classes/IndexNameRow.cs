using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    public class IndexNameRow : TableDataBaseRow
    {
        public IndexNameRow()
        {
        }

        public IndexNameRow(int capacity) : base(capacity)
        {
        }

        public IndexNameRow(IEnumerable<TableDataBaseCell> collection) : base(collection)
        {
        }

        public IndexNameRow(TableDataBaseRow row, bool add = false) : base(row, add)
        {
        }

        public IndexNameRow(string idColumn, string nameColumn) : this()
        {
            IDColumnName = idColumn;
            NameColumnName = nameColumn;
        }

        protected override void AddCellsForThisDatas()
        {
            base.AddCellsForThisDatas();
            Add();
            Add();
            ID = 0;
            Name = "";
        }

        public string IDColumnName
        {
            get => IDColumn.Name;
            set => IDColumn.Name = value;
        }

        public TableDataBaseCell IDColumn
        {
            get => this[0];
            set => this[0] = value;
        }

        public TableDataBaseCell NameColumn
        {
            get => this[1];
            set => this[1] = value;
        }


        public string NameColumnName
        {
            get => NameColumn.Name;
            set => NameColumn.Name = value;
        }

        public int ID
        {
            get => IDColumn.Int32Value;
            set => IDColumn.Int32Value = value;
        }

        public string Name
        {
            get => NameColumn.TextValue;
            set => NameColumn.TextValue = value;
        }

        public int Value
        {
            get => NameColumn.Int32Value;
            set => NameColumn.Int32Value = value;
        }



    }
}
