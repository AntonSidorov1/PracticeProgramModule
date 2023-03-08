using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    public class UserEmail : TableDataBaseRow
    {
        
        public int ID
        {
            get => this.GetCell("EmailID").Int32Value;
            set => this.GetCell("EmailID").Int32Value = value;
        }

        
        public int UserID
        {
            get => this.GetCell("UserID").Int32Value;
            set => this.GetCell("UserID").Int32Value = value;
        }

        

        void AddCells()
        {
            Add("EmailID");
            Add("UserID");
            Add("Email");
        }

        public UserEmail()
        {
            AddCells();
        }

        public UserEmail(int capacity) : base(capacity)
        {
            AddCells();
        }

        public UserEmail(IEnumerable<TableDataBaseCell> collection) : base(collection)
        {
            AddCells();
        }

        public UserEmail(TableDataBaseRow row) : this()
        {
            this.Row = row;
        }

        public string Email
        {
            get => this.GetCell("Email").TextValue;
            set => this.GetCell("Email").TextValue = value;
        }


    }
}
