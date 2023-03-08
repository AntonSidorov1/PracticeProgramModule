using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    public class TableDataBaseRowsCollection : List<TableDataBaseRow>
    {
        public TableDataBaseRowsCollection()
        {
        }

        public TableDataBaseRowsCollection(int capacity) : base(capacity)
        {
        }

        public TableDataBaseRowsCollection(IEnumerable<TableDataBaseRow> collection) : base(collection)
        {
        }

        public virtual bool Contains(string cellName, bool name1 = false)
        {
            
            for(int i = 0; i < Count; i++)
            {
                if (Contains(cellName, name1))
                    return true;
            }
            return false;
        }
    }
}
