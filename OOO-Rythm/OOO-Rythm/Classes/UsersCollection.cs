using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    public class UsersCollection : List<User>
    {
        public UsersCollection()
        {
        }

        public UsersCollection(int capacity) : base(capacity)
        {
        }

        public UsersCollection(IEnumerable<User> collection) : base(collection)
        {
        }

        public List<string> UsersLoginLower
        {
            get
            {
                List<string> result = new List<string>();

                for (int i = 0; i < Count; i++)
                {
                    result.Add(this[i].Login.ToLower());
                }

                return result;
            }
        }

        public int IndexOf(string login) => FindIndex(p => p.Login.ToLower() == login.ToLower());
        public bool Contains(string login) => IndexOf(login) >= 0;

        public User GetUser(string login) => this[IndexOf(login)];
    }
}
