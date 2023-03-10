using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    public class RowWithNoteLinkCollection : List<RowWithNoteLink>
    {
        public RowWithNoteLinkCollection()
        {
        }

        public RowWithNoteLinkCollection(int capacity) : base(capacity)
        {
        }

        public RowWithNoteLinkCollection(IEnumerable<RowWithNoteLink> collection) : base(collection)
        {
        }

        public RowWithNoteLinkCollection(string table, string idColumn, string nameColumn, string linkColumn, bool importDB = false)
        {
            Table = table;
            IDColumn = idColumn;
            NameColumn = nameColumn;
            LinkColumn = linkColumn;
            if (importDB)
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

        string linkColumn = "";
        public string LinkColumn
        {
            get => linkColumn;
            set => linkColumn = value;
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

        public RowWithNoteLinkCollection GetRowsFromLink(int linkID)
        {
            return new RowWithNoteLinkCollection(FindAll(p => p.LinkColumnValue == linkID));
        }

        public RowWithNoteLinkCollection GetRowsFromID(int id)
        {
            return new RowWithNoteLinkCollection(FindAll(p => p.ID == id));
        }

        public RowWithNoteLinkCollection GetRowsFromIdAndLink(int id, int link)
        {
            return GetRowsFromID(id).GetRowsFromLink(link);
        }

        public bool Contains(int id, int link)
        {
            return GetRowsFromIdAndLink(id, link).Count > 0;
        }

        public int IndexOf(int id)
        {
            return FindIndex(p => p.ID == id);
        }

        public RowWithNoteLink GetRowFromID(int id)
        {
            return this[GetIndexFromID(id)];
        }

        public string GetNameFromID(int id)
        {
            return GetRowFromID(id).Name;
        }

        public bool Contains(int id)
        {
            return IndexOf(id) >= 0;
        }


        public void Delete(int id, int link)
        {
            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = Table;

            query.Conditions.Add(new TableDataBaseRow());

            query.Conditions[0].Add(new TableDataBaseCell(IDColumn, id));
            query.Conditions[0].Add(new TableDataBaseCell(LinkColumn, link));
            query.Delete();
        }

        public void Insert(int id, int link, object name)
        {
            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = Table;

            query.InputValues.Add(new TableDataBaseCell(IDColumn, id));
            query.InputValues.Add(new TableDataBaseCell(NameColumn, name));
            query.InputValues.Add(new TableDataBaseCell(LinkColumn, link));
            query.Insert();

            
        }

        public void Update(int id, int link, object name)
        {
            try
            {
                Delete(id, link);
            }
            catch(Exception ex)
            {

            }

            Insert(id, link, name);

            FromDB();
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
                query.Columns.Add(new TableDataBaseCell(LinkColumn));
                TableDataBaseGrid table = query.GetCells();
                for (int i = 0; i < table.Count; i++)
                {
                    TableDataBaseRow row1 = table[i];
                    RowWithNoteLink row = new RowWithNoteLink(row1[0].Name, row1[1].Name, row1[2].Name);
                    row.ID = row1[0].Int32Value;
                    row.LinkColumnValue = row1[2].Int32Value;
                    try
                    {
                        row.Name = row1[1].TextValue;
                    }
                    catch
                    {
                        row.Value = row1[1].Int32Value;
                    }
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
