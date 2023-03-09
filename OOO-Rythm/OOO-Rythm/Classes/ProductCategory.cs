using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    public class ProductCategory : TableDataBaseRow
    {
        public ProductCategory()
        {
            AddCells();
        }

        public ProductCategory(int capacity) : base(capacity)
        {
            AddCells();
        }

        public ProductCategory(IEnumerable<TableDataBaseCell> collection) : base(collection)
        {
            AddCells();
        }

        public ProductCategory(TableDataBaseRow row) : this()
        {
            Row = row;
        }

        public ProductCategory(int id, string name, int categoryFilter = 1) : this()
        {
            ID = id;
            Name = name;
            RootCategoryID = 0;
            SubCategory = false;
            CategoryFilterID = categoryFilter;

        }


        void AddCells()
        {
            
            Add("CategoryID");
            Add("CategoryName");
            Add("Subcategorie");
            Add("RootCategoryID");
            Add("CategoryFilterID");
            Add("CategoryParametersName");
        }


        public int ID
        {
            get => GetCell("CategoryID").Int32Value;
            set => GetCell("CategoryID").Int32Value = value;
        }

        public string Name
        {
            get => GetCell("CategoryName").TextValue;
            set => GetCell("CategoryName").TextValue = value;
        }

        public bool SubCategory
        {
            get => GetCell("Subcategorie").BooleanValue;
            set => GetCell("Subcategorie").BooleanValue = value;
        }

        public int RootCategoryID
        {
            get => GetCell("RootCategoryID").Int32Value;
            set => GetCell("RootCategoryID").Int32Value = value;
        }

        public int CategoryFilterID
        {
            get => GetCell("CategoryFilterID").Int32Value;
            set => GetCell("CategoryFilterID").Int32Value = value;
        }

        CategoryFilterCollection filters;

        public CategoryFilterCollection Filters
        {
            get => filters;
            set => filters = value;
        }

        public CategoryFilter Filter
        {
            get => filters.GetFilter(CategoryFilterID);
            set
            {
                int index = filters.IndexOf(CategoryFilterID);
                filters[index] = value;
            }
        }

        CategoryCollection categories;

        public CategoryCollection Categories
        {
            get => categories;
            set => categories = value;
        }

        public List<ProductCategory> SubCategories
        {
            get => Categories.FindForRoot(ID);
        }

        public ProductCategory RootCategory
        {
            get
            {
                int root = RootCategoryID;
                return Categories.GetCategory(root);
            }
        }

        
    }
}
