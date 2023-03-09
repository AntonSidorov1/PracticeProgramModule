using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    public class IndexNameRowsCollection : List<IndexNameRow>
    {
        public IndexNameRowsCollection()
        {
        }

        public IndexNameRowsCollection(int capacity) : base(capacity)
        {
        }

        public IndexNameRowsCollection(IEnumerable<IndexNameRow> collection) : base(collection)
        {
        }

        public IndexNameRowsCollection(string table, string idColumn, string nameColumn, bool importDB = false)
        {
            Table = table;
            IDColumn = idColumn;
            NameColumn = nameColumn;
            if(importDB)
            {
                FromDB();
            }
        }

        string idColumn = "";
        public string IDColumn
        {
            get => idColumn;
            set => idColumn = value;
        }

        string nameColumn = "";
        public string NameColumn
        {
            get => nameColumn;
            set => nameColumn = value;
        }

        string table = "";
        public string Table
        {
            get => table;
            set => table = value;
        }

        public void FromDB()
        {
            Clear();
            try
            {
                DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
                query.Table = Table;

                query.Columns.Add(new TableDataBaseCell(IDColumn));
                query.Columns.Add(new TableDataBaseCell(NameColumn));
                TableDataBaseGrid table = query.GetCells();
                for (int i = 0; i < table.Count; i++)
                {
                    TableDataBaseRow row1 = table[i];
                    IndexNameRow row = new IndexNameRow(row1[0].Name, row1[1].Name);
                    row.ID = row1[0].Int32Value;
                    row.Name = row1[1].TextValue;
                    Add(row);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public int GetIndexFromID(int idRow) => FindIndex(p => p.ID == idRow);
    }
}
