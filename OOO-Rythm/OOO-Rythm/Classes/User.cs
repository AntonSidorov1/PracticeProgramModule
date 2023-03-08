using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    public class User : TableDataBaseRow
    {
        public User()
        {
            createUser();
        }

        public User(int capacity) : base(capacity)
        {
            createUser();
        }

        public User(IEnumerable<TableDataBaseCell> collection) : base(collection)
        {
            createUser();
        }

        public User(TableDataBaseRow row) : this()
        {
            Row = row;
        }

        void createUser()
        {
            Add("UserID");
            Add("UserLogin");
            Add("UserPassword");
            Add("ChatUser");
            Add("UserBlocked");
            Add("Encription_Algorithm");
        }

        public int ID
        {
            get => this.GetCell("UserID").Int32Value;
            set => this.GetCell("UserID").Int32Value = value;
        }

        public string Login
        {
            get => this.GetCell("UserLogin").TextValue;
            set => this.GetCell("UserLogin").TextValue = value;
        }

        public string Password
        {
            get => this.GetCell("UserPassword").TextValue;
            set => this.GetCell("UserPassword").TextValue = value;
        }

        public string Encription_Algorithm
        {
            get => this.GetCell("Encription_Algorithm").TextValue;
            set => this.GetCell("Encription_Algorithm").TextValue = value;
        }

        public bool Chat
        {
            get => this.GetCell("ChatUser").BooleanValue;
            set => this.GetCell("ChatUser").BooleanValue = value;
        }

        public bool Blocked
        {
            get => this.GetCell("UserBlocked").BooleanValue;
            set => this.GetCell("UserBlocked").BooleanValue = value;
        }

    }
}
