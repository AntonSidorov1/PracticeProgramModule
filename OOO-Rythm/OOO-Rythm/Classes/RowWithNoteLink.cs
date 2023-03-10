using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    public class RowWithNoteLink : IndexNameRow
    {
        public RowWithNoteLink()
        {
        }

        public RowWithNoteLink(int capacity) : base(capacity)
        {
        }

        public RowWithNoteLink(IEnumerable<TableDataBaseCell> collection) : base(collection)
        {
        }

        public RowWithNoteLink(TableDataBaseRow row, bool add = false) : base(row, add)
        {
        }

        public RowWithNoteLink(string idColumn, string nameColumn, string linkColumn) : base(idColumn, nameColumn)
        {
            LinkColumnName = linkColumn;
        }

        public string LinkColumnName
        {
            get => LinkColumn.Name;
            set => LinkColumn.Name = value;
        }

        public int LinkColumnValue
        {
            get => LinkColumn.Int32Value;
            set => LinkColumn.Int32Value = value;
        }

        public TableDataBaseCell LinkColumn
        {
            get => this[2];
            set => this[2] = value;
        }

        protected override void AddCellsForThisDatas()
        {
            base.AddCellsForThisDatas();
            Add();
        }
    }
}
