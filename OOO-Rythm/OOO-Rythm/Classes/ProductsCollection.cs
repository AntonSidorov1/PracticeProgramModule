using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    class ProductsCollection : List<Product>
    {
        public ProductsCollection()
        {
        }

        public ProductsCollection(int capacity) : base(capacity)
        {
        }

        public ProductsCollection(IEnumerable<Product> collection) : base(collection)
        {
        }


        static ProductsCollection DefaultLocal = new ProductsCollection();

        public static ProductsCollection DefaultRemote
        {
            get
            {
                ProductsCollection products = new ProductsCollection();
                products.FromDB();
                return products;
            }
        }

        public static ProductsCollection DefaultFromDB() => DefaultFromDB(0);

        public static ProductsCollection DefaultFromDB(int categoryID, string partName = "")
        {
            ProductsCollection products = new ProductsCollection();
            products.FromDB(categoryID, partName);
            return products;
        }

        public static ProductsCollection DefaultFromDB(int categoryID, string partName, Sort sortName, Sort sortCost)
        {
            ProductsCollection products = new ProductsCollection();
            products.FromDB(categoryID, partName, sortName, sortCost);
            return products;
        }

        public void FromDB() => FromDB(0);

        public void FromDB(int categoryID, string partName = "")
        {
            FromDB(categoryID, partName, OOO_Rythm.Sort.no, OOO_Rythm.Sort.no);
        }



        public void FromDB(int categoryID, string partName, Sort sortName, Sort sortCost)
        {
            Clear();

            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = "Product";
            query.Columns.AddRange(Product.Defualt);

            query.Sort.Add(new SortParameter("ProductName", sortName));
            query.Sort.Add(new SortParameter("ProductCost", sortCost));

            if (!Helper.NullText(partName) || categoryID > 0)
                query.Conditions.Add(new TableDataBaseRow());

            if (categoryID > 0)
            {
                query.Conditions[0].Add(
                        new TableDataBaseCell("ProductCategoryID", categoryID));
            }
            if (!Helper.NullText(partName))
                query.Conditions[0].Add(new TableDataBaseCell("ProductName", partName, Comparison.Like));

            TableDataBaseGrid table = query.GetCells();
            ;
            for (int i = 0; i < table.Count; i++)
            {
                Product product = new Product(table[i]);
                Add(product);
            }
        }

        public int IndexOf(string articul) => FindIndex(p => p.Name.ToLower() == articul.ToLower());
        public bool Contains(string articul) => IndexOf(articul) >= 0;

        public Product GetProduct(string articul) => this[IndexOf(articul)];

        public int IndexOf(int idProduct) => FindIndex(p => p.ID == idProduct);
        public bool Contains(int idProduct) => IndexOf(idProduct) >= 0;

        public Product GetProduct(int idProduct) => this[IndexOf(idProduct)];

        public ProductsCollection GetProductsForDiscountDiapozon(int startDiscount, int endDiscount)
        {
            List<Product> products = FindAll(p => p.Discount >= startDiscount && p.Discount <= endDiscount);
            return new ProductsCollection(products);
        }

    }
}
