using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rythm
{
    /// <summary>
    /// Роль пользователя в системе
    /// </summary>
    public class Role : TableDataBaseRow
    {
        string name = "";

        public string Name
        {
            get => (string)this["RoleName"];
            set => this["RoleName"] = value;
        }

        public int ID
        {
            get => (int)this["RoleID"];
            set => this["RoleID"] = value;
        }

        public Role()
        {
            Add("RoleID");
            Add("RoleName");
        }

        public Role(TableDataBaseRow row) : this()
        {
            Row = row;
        }

        public Role(string name = "") : this()
        {
            Name = name;
        }

        public Role(int id, string name = "") : this(name)
        {
            ID = id;
        }

        public static bool operator ==(Role role1, Role role2)
        {
            return role1.Name == role2.Name;
        }

        public static bool operator !=(Role role1, Role role2)
        {
            return role1.Name != role2.Name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Role role &&
                   name == role.name &&
                   Name == role.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = 629881564;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        public override TableDataBaseRow Row
        { 
            get => base.Row;
            set
            {
                TableDataBaseRow row = value;
                ID = (int)row["RoleID"];
                Name = (string)row["RoleName"];
            }
        }
    }
}
