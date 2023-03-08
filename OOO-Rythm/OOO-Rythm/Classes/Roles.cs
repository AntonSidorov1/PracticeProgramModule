using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    /// <summary>
    /// Список ролей
    /// </summary>
    public class Roles : List<Role>
    {

        public TableDataBaseGrid Table
        {
            get
            {
                TableDataBaseGrid table = new TableDataBaseGrid("Role");
                table.AddColumn(Goest[0]);
                table.AddColumn(Goest[1]);
                for(int i = 0; i < Count; i++)
                {
                    table.Add(GetRole(i));
                }
                return table;

            }
            set
            {
                Clear();
                TableDataBaseGrid table = value;
                for(int i = 0; i < table.Count; i++)
                {
                    Add(new Role(table[i]));
                }
            }
        }

        Role goest => new Role("Гость");

        public Role Goest => goest;

        public int CountWithoutGoest => base.Count;

        public new int Count => CountWithoutGoest + 1;

        public bool IsReadOnly => Count < 2;

        public new Role this[int index] { get => GetRole(index); set => SetRole(index, value); }

        public Roles()
        {
        }

        public Roles(TableDataBaseGrid table) : this()
        {
            Table = table;
        }

        public Roles(int capacity) : base(capacity)
        {
        }

        public Roles(IEnumerable<Role> collection) : base(collection)
        {
        }

        public Role GetRole(int index)
        {
            if (index == 0)
                return Goest;
            return base[index - 1];
        }

        public void SetRole(int index, Role role)
        {
            if (index == 0)
                throw new ArgumentException($"Не возможно изменить роль {goest}");
            base[index - 1] = role;
        }

        public new int IndexOf(Role item)
        {
            if (item == Goest)
                return 0;
                int index = base.IndexOf(item);
            if (index >= 0)
                index++;
            return index;

        }

        public void Add(int index, Role item)
        {
            if (index == 0)
                throw new ArgumentException("Не возможно изменить роль {goest}");
            if (index == Count)
                Add(item);
            base.Insert(index - 1, item);
        }

        public new void Insert(int index, Role item)
        {
            Add(index, item);
        }

        public new void RemoveAt(int index)
        {
            if (index == 0)
                throw new ArgumentException("Не возможно удалить роль {goest}");
            base.RemoveAt(index - 1);
        }

        public new void Add(Role item)
        {
            base.Add(item);
        }

        public void Insert(Role item)
        {
            Add(item);
        }

        public void Add(IEnumerable<Role> items)
        {
            base.AddRange(items);
        }

        public void Insert(IEnumerable<Role> items)
        {
            Add(items);
        }

        public new void AddRange(IEnumerable<Role> items)
        {
            Add(items);
        }

        public void InsertRange(IEnumerable<Role> items)
        {
            Add(items);
        }

        public void Add(int index, IEnumerable<Role> items)
        {
            List<Role> roles = new List<Role>(items);
            for(int i = 0; i < roles.Count; i++)
            {
                Add(index + i, roles[i]);
            }
        }

        public void Insert(int index, IEnumerable<Role> items)
        {
            Add(index, items);
        }

        public void AddRange(int index, IEnumerable<Role> items)
        {
            Add(index, items);
        }

        public new void InsertRange(int index, IEnumerable<Role> items)
        {
            Add(index, items);
        }

        public new bool Contains(Role item)
        {
            if (item == Goest)
                return true;
            else
                return base.Contains(item);
        }

        public List<Role> ToListWithoutGoest()
        {
            List<Role> roles = new List<Role>(this);
            return roles;
        }

        public List<Role> ToList()
        {
            List<Role> roles = ToListWithoutGoest();
            roles.Insert(0, Goest);
            return roles;
        }

        public new Role[] ToArray()
        {
            return ToList().ToArray();
        }

        public Role[] ToArrayWithoutGoest()
        {
            return ToListWithoutGoest().ToArray();
        }

        public string[] GetRolesNames()
        {
            int count = Count;
            string[] result = new string[count];

            for(int i =0; i < count; i++)
            {
                result[i] = this[i].Name;
            }

            return result;
        }


        public int IndexOf(int roleID) => roleID == 0? 0: FindIndex(p => p.ID == roleID)>=0? FindIndex(p => p.ID == roleID) + 1 : FindIndex(p => p.ID == roleID);
        public int IndexOf(string name) => name.ToLower() == Goest.Name.ToLower()? 0 : FindIndex(p => p.Name.ToLower() == name.ToLower()) >=0 ? FindIndex(p => p.Name.ToLower() == name.ToLower()) + 1: FindIndex(p => p.Name.ToLower() == name.ToLower());

        public bool Contains(int roleID) => IndexOf(roleID) >= 0;
        public bool Contains(string name) => IndexOf(name) >= 0;

        public Role GetRoleFromID(int roleID) => this[IndexOf(roleID)];
        public Role GetRoleFromName(int name) => this[IndexOf(name)];


    }
}
