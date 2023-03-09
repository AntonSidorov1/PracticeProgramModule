using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOO_Rythm
{
    public class Product : TableDataBaseRow
    {
        public Product()
        {
        }

        public Product(int capacity) : base(capacity)
        {
        }

        public Product(IEnumerable<TableDataBaseCell> collection) : base(collection)
        {
        }

        public Product(TableDataBaseRow row, bool add = false) : base(row, add)
        {
        }

        protected override void AddCellsForThisDatas()
        {
            base.AddCellsForThisDatas();
            Add("ProductID");
            Add("ProductArticle");
            Add("ProductName");
            Add("ProductDescription");
            Add("ProductCost");
            Add("ProductDiscount");
            Add("ProductManufactureID");
            Add("ProductCategoryID");
            Add("ProductSupplierID");
            Add("ProductPhoto");
            Add("ProductParameters");

            ID = 0;
            Articul = "";
            Name = "";
            Description = "";
            Cost = 0;
            Discount = 0;
        }

        public TableDataBaseRow GetRowWithoutID()
        {
            TableDataBaseRow row = new TableDataBaseRow(this, true);
            int index = row.FindIndex(p => p.Name == "ProductID");
            row.RemoveAt(index);

            try
            {
                if (Photo == null || Photo is null)
                {
                    throw new Exception();
                }
            }
            catch
            {
                index = row.FindIndex(p => p.Name == "ProductPhoto");
                row.RemoveAt(index);
            }

            return row;
        }

        public TableDataBaseRow GetRowWithoutIDAndArticul()
        {
            TableDataBaseRow row = GetRowWithoutID();
            int index = row.FindIndex(p => p.Name == "ProductArticle");
            row.RemoveAt(index);

            return row;
        }

        ProductsCollection products;
        public ProductsCollection Products
        {
            get => products;
            set => products = value;
        }

        public static Product Defualt = new Product();

        public string Name
        {
            get => GetCell("ProductName").TextValue;
            set => GetCell("ProductName").TextValue = value;
        }

        public string Articul
        {
            get => GetCell("ProductArticle").TextValue;
            set => GetCell("ProductArticle").TextValue = value;
        }

        public Bitmap Photo
        {
            get => GetCell("ProductPhoto").ImageValue;
            set => GetCell("ProductPhoto").ImageValue = value;
        }

        public string Description
        {
            get => GetCell("ProductDescription").TextValue;
            set => GetCell("ProductDescription").TextValue = value;
        }


        public int ID
        {
            get => GetCell("ProductID").Int32Value;
            set => GetCell("ProductID").Int32Value = value;
        }

        public byte Discount
        {
            get => GetCell("ProductDiscount").ByteValue;
            set => GetCell("ProductDiscount").ByteValue = value;
        }

        public double CostWithoutDiscount
        {
            get => Convert.ToDouble(Cost);
            set => Cost = Convert.ToDecimal(value);
        }

        public double DiscountPersent
        {
            get => Discount / 100.0;
            set => Discount = (byte)((int)(value * 100.0));
        }

        public double CostWithDiscount
        {
            get => CostWithoutDiscount - CostWithoutDiscount * DiscountPersent;
            set => CostWithoutDiscount = -value / (DiscountPersent - 1);
        }

        public decimal Cost
        {
            get => GetCell("ProductCost").DecimalValue;
            set => GetCell("ProductCost").DecimalValue = value;
        }

        public int ManufactureID
        {
            get => GetCell("ProductManufactureID").Int32Value;
            set => GetCell("ProductManufactureID").Int32Value = value;
        }

        public int CategoryID
        {
            get => GetCell("ProductCategoryID").Int32Value;
            set => GetCell("ProductCategoryID").Int32Value = value;
        }

        public int SupplierID
        {
            get => GetCell("ProductSupplierID").Int32Value;
            set => GetCell("ProductSupplierID").Int32Value = value;
        }

    }
}
