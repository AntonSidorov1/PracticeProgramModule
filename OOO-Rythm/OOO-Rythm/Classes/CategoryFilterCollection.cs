using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    public class CategoryFilterCollection : List<CategoryFilter>
    {
        public CategoryFilterCollection()
        {
        }

        public CategoryFilterCollection(int capacity) : base(capacity)
        {
        }

        public CategoryFilterCollection(IEnumerable<CategoryFilter> collection) : base(collection)
        {
        }

        static CategoryFilterCollection defaultFilters = new CategoryFilterCollection();

        public static CategoryFilterCollection Default
        {
            get
            {
                defaultFilters.FromDB();
                return defaultFilters;
            }
        }


        public void FromDB()
        {
            Clear();

            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = "CategoryFilter";
            TableDataBaseGrid table = query.GetCells();
            Add(new CategoryFilter(0, "Без фильтра"));
            for (int i = 0; i < table.Count; i++)
            {
                Add(new CategoryFilter(table[i]));
            }
        }

        

        public int IndexOf(string filter) => FindIndex(p => p.Name.ToLower() == filter.ToLower());
        public bool Contains(string filter) => IndexOf(filter) >= 0;

        public CategoryFilter GetFilter(string filter) => this[IndexOf(filter)];

        public int IndexOf(int idFilter) => FindIndex(p => p.ID == idFilter);
        public bool Contains(int idFilter) => IndexOf(idFilter) >= 0;

        public CategoryFilter GetFilter(int idFilter) => this[IndexOf(idFilter)];


    }
}
