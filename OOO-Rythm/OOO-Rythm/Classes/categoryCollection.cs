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

        public static CategoryCollection DefaultFromDB(int filterID = 0)
        {
            CategoryCollection categories = new CategoryCollection();
            categories.FromDB(filterID);
            return categories;
        }


        public void FromDB(int filterID = 0)
        {
            Clear();

            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = "ProductCategory";

            if(filterID > 0)
            {
                query.Conditions.Add(new TableDataBaseRow(
                    new TableDataBaseCell[]
                    {
                        new TableDataBaseCell("CategoryFilterID", filterID)
                    })) ;
            }

            TableDataBaseGrid table = query.GetCells();
            ProductCategory category = new ProductCategory(0, "Все категории");
            category.Categories = this;
            category.Filters = CategoryFilterCollection.Default;
            Add(category);
            for (int i = 0; i < table.Count; i++)
            {
                category = new ProductCategory(table[i]);
                category.Categories = this;
                category.Filters = CategoryFilterCollection.Default;
                Add(category);
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
