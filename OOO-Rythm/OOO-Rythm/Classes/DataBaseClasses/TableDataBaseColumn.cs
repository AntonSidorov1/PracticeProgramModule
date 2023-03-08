using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    /// <summary>
    /// Столбец таблицы
    /// </summary>
    public class TableDataBaseColumn
    {
        public TableDataBaseColumn()
        {
        }

        public TableDataBaseColumn(string name) : this()
        {
            Name = name;
        }

        public TableDataBaseColumn(TableDataBaseGrid table) : this()
        {
            Table = table;
        }

        public TableDataBaseColumn(TableDataBaseGrid table, string name) : this(table)
        {
            Name = name;
        }

        TableDataBaseGrid table;

        public TableDataBaseGrid Table
        {
            get => table;
            set => table = value;
        }

        string name = "";
        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Index => Table.Columns.IndexOf(this);

        public TableDataBaseCell GetCell(int row)
        {
            return Table[row][Index];
        }
    }
}
