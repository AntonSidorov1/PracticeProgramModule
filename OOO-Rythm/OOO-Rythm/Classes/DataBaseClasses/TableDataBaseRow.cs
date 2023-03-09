using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    /// <summary>
    /// Строка таблицы
    /// </summary>
    public class TableDataBaseRow : List<TableDataBaseCell>
    {
        public TableDataBaseRow()
        {
            AddCellsForThisDatas();

        }

        protected virtual void AddCellsForThisDatas()
        {

        }

        public TableDataBaseRow(int capacity) : base(capacity)
        {
            AddCellsForThisDatas();
        }

        public TableDataBaseRow(IEnumerable<TableDataBaseCell> collection) : base(collection)
        {
            AddCellsForThisDatas();
        }

        public TableDataBaseRow (TableDataBaseRow row, bool add = false): this()
        {
            if(add)
            for(int i = 0; i < row.Count; i++)
            {
                Add(row[i]);
            }
            Row = row;
        }

        public TableDataBaseCell Add(string name)
        {
            Add(new TableDataBaseCell(name));
            return this[Count - 1];
        }

        public TableDataBaseCell Add()
        {
            TableDataBaseCell cell = new TableDataBaseCell();
            cell.Name = "";
            cell.Value = "";
            Add(cell);
            return cell;
        }

        public TableDataBaseCell Add(string name, object valueCell)
        {
            Add(new TableDataBaseCell(name, valueCell));
            return this[Count - 1];
        }

        public TableDataBaseCell Insert(int index, string name)
        {
            Insert(index, new TableDataBaseCell(name));
            return this[index];
        }


        public TableDataBaseCell Insert(int index, string name, object valueCell)
        {
            Insert(index, new TableDataBaseCell(name, valueCell));
            return this[index];
        }

        public TableDataBaseCell GetCell(string name)
        {
            return Find(p => p.Name == name);
        }

        public object this[string name]
        {
            get => GetCell(name).Value;
            set => GetCell(name).Value = value;
        }

        public virtual TableDataBaseRow Row
        {
            get
            {
                TableDataBaseRow row = new TableDataBaseRow();
                for(int i = 0; i < Count; i++)
                {
                    row.Add(row[i].Name, row[i].Value);
                }
                return row;
            }
            set
            {
                TableDataBaseRow row = value;
                for (int i = 0; i < Count; i++)
                {
                    string name = this[i].Name;
                    this[i].Value = row[name];
                }
            }
        }

        public List<TableDataBaseCell> Cells => this;

        public TableDataBaseCell Add(TableDataBaseColumn column)
        {
            return Add(column.Name);
        }


        public int IndexOf(string cellName, bool name1 = false) => !name1? FindIndex(p => p.Name == cellName) : FindIndex(p => p.Name1 == cellName);

        public bool Contains(string cellName, bool name1 = false) => IndexOf(cellName, name1) >= 0;

    }
}
