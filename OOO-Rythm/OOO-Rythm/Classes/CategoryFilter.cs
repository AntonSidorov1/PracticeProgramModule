using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    public class CategoryFilter : TableDataBaseRow
    {
        public CategoryFilter()
        {
            AddCells();
        }

        public CategoryFilter(int id, string name):this()
        {
            ID = id;
            Name = name;
        }

        public CategoryFilter(int capacity) : base(capacity)
        {
            AddCells();
        }

        public CategoryFilter(IEnumerable<TableDataBaseCell> collection) : base(collection)
        {
            AddCells();
        }

        public CategoryFilter(TableDataBaseRow row) : this()
        {
            Row = row;
        }


        void AddCells()
        {
            Add("CategoryFilterID");
            Add("categoryFilterName");
        }


        public int ID
        {
            get => GetCell("CategoryFilterID").Int32Value;
            set => GetCell("CategoryFilterID").Int32Value = value;
        }

        public string Name
        {
            get => GetCell("categoryFilterName").TextValue;
            set => GetCell("categoryFilterName").TextValue = value;
        }

    }
}
