using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    public class UserTelephone : TableDataBaseRow
    {
        public UserTelephone()
        {
            AddCells();
        }

        public UserTelephone(int capacity) : base(capacity)
        {
            AddCells();
        }

        public UserTelephone(IEnumerable<TableDataBaseCell> collection) : base(collection)
        {
            AddCells();
        }

        public UserTelephone(TableDataBaseRow row) : this()
        {
            this.Row = row;
        }


        void AddCells()
        {
            Add("TelefonID");
            Add("UserID");
            Add("Telefon");
        }


        public int ID
        {
            get => this.GetCell("TelefonID").Int32Value;
            set => this.GetCell("TelefonID").Int32Value = value;
        }


        public int UserID
        {
            get => this.GetCell("UserID").Int32Value;
            set => this.GetCell("UserID").Int32Value = value;
        }

        public string Telephone
        {
            get => this.GetCell("Telefon").TextValue;
            set => this.GetCell("Telefon").TextValue = value;
        }

    }
}
