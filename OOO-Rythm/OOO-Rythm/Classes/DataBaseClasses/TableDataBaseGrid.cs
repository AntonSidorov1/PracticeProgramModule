using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    /// <summary>
    /// Таблица базы данных
    /// </summary>
    public class TableDataBaseGrid : TableDataBaseRowsCollection
    {

        public override bool Contains(string cellName, bool name1 = false)
        {
            if (name1)
                return base.Contains(cellName, name1);
            return base.Contains(cellName, name1) || Columns.FindIndex(p => p.Name == cellName) >= 0;
        }

        string name = "";
        public string Name { get => name; set => name = value; }

        public TableDataBaseGrid()
        {
            columns = new List<TableDataBaseColumn>(); 
        }

        public TableDataBaseGrid(string name) : this()
        {
            Name = name;
        }

        public List<TableDataBaseRow> Rows => this;

       List<TableDataBaseColumn> columns;

        public List<TableDataBaseColumn> Columns => columns;

        public TableDataBaseCell this[int column, int row]
        {
            get => Rows[row].Cells[column];
            set => Rows[row].Cells[column] = value;
        }

        public TableDataBaseColumn AddColumn(string name)
        {
            TableDataBaseColumn column = new TableDataBaseColumn(this, name);
            Columns.Add(column);
            for(int i = 0; i < Count; i++)
            {
                Rows[i].Add(Columns[i]);
            }
            return column;
        }

        public TableDataBaseColumn AddColumn(TableDataBaseColumn column)
        {
            return AddColumn(column.Name);
        }

        public TableDataBaseColumn AddColumn(TableDataBaseCell column)
        {
            return AddColumn(column.Name);
        }

        public TableDataBaseRow GetRow()
        {
            TableDataBaseRow row = new TableDataBaseRow();
            for(int i = 0; i < Columns.Count; i++)
            {
                row.Add(Columns[i].Name);
            }
            return row;
        }

        public TableDataBaseRow Add()
        {
            TableDataBaseRow row = GetRow();
            Add(row);
            return row;
        }

        public TableDataBaseRow Insert(int index)
        {
            Insert(index, GetRow());
            TableDataBaseRow row = GetRow();
            Insert(index, row);
            return row;
        }
    }
}
