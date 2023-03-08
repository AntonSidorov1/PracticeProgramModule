using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    public class CategoryCollection : List<ProductCategory>
    {
        public CategoryCollection()
        {
        }

        public CategoryCollection(int capacity) : base(capacity)
        {
        }

        public CategoryCollection(IEnumerable<ProductCategory> collection) : base(collection)
        {
        }



        public int IndexOf(string category) => FindIndex(p => p.Name.ToLower() == category.ToLower());
        public bool Contains(string category) => IndexOf(category) >= 0;

        public ProductCategory GetCategory(string category) => this[IndexOf(category)];

        public int IndexOf(int idCategory) => FindIndex(p => p.ID == idCategory);
        public bool Contains(int idCategory) => IndexOf(idCategory) >= 0;

        public ProductCategory GetCategory(int idCategory) => this[IndexOf(idCategory)];


        static CategoryCollection defaultFilters = new CategoryCollection();

        public static CategoryCollection Default
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
            Add(new ProductCategory(0, "Все категории"));
            for (int i = 0; i < table.Count; i++)
            {
                Add(new ProductCategory(table[i]));
            }
        }

        public List<ProductCategory> FindForRoot(int rootID)
        {
            List<ProductCategory> result = FindAll(p => p.ID == rootID);
            result.Insert(0, new ProductCategory(0, "Все категории"));
            result.Insert(1, new ProductCategory(-1, "Категория уровня выше"));
            return result;
        }

        public List<ProductCategory> RootCategories()
        {
            return FindAll(p => p.SubCategory || p.RootCategoryID == 0);
        }

    }
}
