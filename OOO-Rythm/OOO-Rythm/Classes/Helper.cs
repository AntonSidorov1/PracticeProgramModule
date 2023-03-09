using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace OOO_Rythm
{
    public static class Helper
    {
        static Roles roles = new Roles();
        static public Roles Roles => roles;

        static SqlConnection connection;

        static public SqlConnection Connection
        {
            get => connection;
            set => connection = value;
        }

        public static void GetRoles()
        {
           
            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = "Role";
            query.Columns.Add(new TableDataBaseCell("RoleID"));
            query.Columns.Add(new TableDataBaseCell("RoleName"));

            TableDataBaseGrid table = query.GetCells();
            Roles.Table = table;
        }

        public static int UserID
        {
            get => UserDatas.GetCell("UserID").Int32Value;
            set
            {
                try
                {
                    if (value == 0)
                        throw new Exception();
                    UserDatas.GetCell("UserID").Int32Value = value;
                }
                catch
                {
                    UserDatas = new TableDataBaseRow(new TableDataBaseCell[] { new TableDataBaseCell("UserID", value) });
                }
            }
        }

        public static string UserPassword
        {
            get => UserDatas.GetCell("UserPassword").TextValue;
            set => UserDatas.GetCell("UserPassword").TextValue = value;
        }


        public static TableDataBaseRow UserDatas
        {
            get => userDatas;
            set => userDatas = value;
        }

        static TableDataBaseRow userDatas;

        public static void UserInput(string login, string password, bool systemConnection = true)
        {
            DataBaseQuery query = systemConnection? new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection()) : new DataBaseQuery(new DatabaseConnectionRythm(Connection.ConnectionString));
            query.Table = "User";
            query.Conditions.Add(
                new TableDataBaseRow(
                    new TableDataBaseCell[]
                    {
                        new TableDataBaseCell("UserLogin", login),
                    new TableDataBaseCell("UserPassword", password),
                    new TableDataBaseCell("UserBlocked", false)
                    }
                    )
                ) ;
            TableDataBaseGrid table = query.GetCells();
            UserDatas = table[0];
        }

        static UsersCollection users = new UsersCollection();
        public static UsersCollection Users => users;

        public static void GetAllUsers()
        {
            Users.Clear();
            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = "User";
            TableDataBaseGrid table = query.GetCells();
            for(int i = 0; i < table.Count; i++)
            {
                Users.Add(new User(table[i]));
            }
        }

        public static bool UserPresent(string login)
        {
            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = "User";
            query.Conditions.Add(
                new TableDataBaseRow(
                    new TableDataBaseCell[]
                    {
                        new TableDataBaseCell("UserLogin", login)
                    }
                    )
                );
            TableDataBaseGrid table = query.GetCells();
            return table.Count > 0;
        }

        public static bool NullText(string text)
        {
            return text == "" || text.Equals("") || text is null || text == null;
        }

        public static void AddUser(string login, string password = "")
        {
            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = "User";
            query.InputValues.AddRange(new TableDataBaseCell[] {
                new TableDataBaseCell("UserLogin", login),
                new TableDataBaseCell("UserPassword", password)
            });
            query.Insert();
        }

        public static void SetUserBlocked(int id, bool blocked = false)
        {
            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = "User";
            query.InputValues.AddRange(new TableDataBaseCell[] {
                new TableDataBaseCell("UserBlocked", blocked)
            });
            query.Conditions.Add(new TableDataBaseRow(new TableDataBaseCell[] { new TableDataBaseCell("UserID", id) }));
            query.Update();
        }

        public static void AddUserRole(string login, int roleID = 1)
        {
            AddUserRole(Users.GetUser(login).ID, roleID);
        }

        public static void DeleteUserRole(string login, int roleID = 1)
        {
            DeleteUserRole(Users.GetUser(login).ID, roleID);
        }

        public static void DeleteUserRole(int userID, int roleID)
        {
            int UserID = userID;

            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = "UserRole";
            query.Conditions.Add(new TableDataBaseRow(new TableDataBaseCell[] {
                new TableDataBaseCell("UserID", UserID),
                new TableDataBaseCell("RoleID", roleID)

            })
                );
            query.Delete();
        }

        public static void AddUserRole(int userID, int roleID = 1)
        {
            int UserID = userID;

            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = "UserRole";
            query.InputValues.AddRange(new TableDataBaseCell[] {
                new TableDataBaseCell("UserID", UserID),
                new TableDataBaseCell("RoleID", roleID)
            });
            query.Insert();
        }

        public static void Registration(string login, string password)
        {
            AddUser(login, password);

            UserInput(login, password);

            AddUserRole(UserID);
        }

        public static void DeleteAccount()
        {
            DeleteAccount(UserID);
        }

        public static void DeleteAccount(string login)
        {
            DeleteAccount(Users.GetUser(login).ID);
        }

        public static void DeleteAccount(int userID)
        {
            int UserID = userID;
            DataBaseQuery query = new DataBaseQuery(GetConnection());
            query.Table = "User";
            query.Conditions.Add(
                new TableDataBaseRow(
                    new TableDataBaseCell[] { new TableDataBaseCell("UserID", UserID) }
                    )
                );
            query.Delete();
        }

        public static string UserFamily
        {
            get
            {
                try
                {
                    return UserFIO.Split(' ')[0];
                }
                catch
                {
                    return "";
                }
            }
        }


        public static string UserName
        {
            get
            {
                try
                {
                    return UserFIO.Split(' ')[1];
                }
                catch
                {
                    return "";
                }
            }
        }

        public static string UserLastName
        {
            get
            {
                try
                {
                    return UserFIO.Split(' ')[2];
                }
                catch
                {
                    return "";
                }
            }
        }

        public static bool UpdateFIO(string family, string name, string lastName)
        {
            
            DataBaseQuery query = new DataBaseQuery(GetConnection());
            if (NullText(family) || NullText(name))
            {
                try
                {

                    query.Table = "UserInitials";
                    query.Conditions.Add(
                        new TableDataBaseRow(
                            new TableDataBaseCell[] { new TableDataBaseCell("UserID", UserID) }
                            )
                        );
                    query.Delete();
                }
                catch
                {

                }
            }
            else
            {
                if (!HaveUserFIO())
                {

                    query.Table = "UserInitials";
                    query.InputValues.AddRange(
                        
                            new TableDataBaseCell[] { new TableDataBaseCell("UserID", UserID),
                            new TableDataBaseCell("UserFamily", family),
                            new TableDataBaseCell("UserName", name),
                            new TableDataBaseCell("UserSurName", lastName)
                            }
                            
                        );
                    query.Insert();
                }
                else
                {

                    query.Table = "UserInitials";
                    query.Conditions.Add(new TableDataBaseRow(
                            new TableDataBaseCell[] { new TableDataBaseCell("UserID", UserID) })
                            
                        ); ;
                    query.InputValues.AddRange(
                        new TableDataBaseRow(
                            new TableDataBaseCell[] {
                            new TableDataBaseCell("UserFamily", family),
                            new TableDataBaseCell("UserName", name),
                            new TableDataBaseCell("UserSurName", lastName)
                            }
                            )
                        );
                    query.Update();
                }

            }

            return HaveUserFIO();
        }

        public static void ChangePassword(string password)
        {
            DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
            query.Table = "User";
            query.InputValues.AddRange(new TableDataBaseCell[] {
                new TableDataBaseCell("UserPassword", password)
            });
            query.Conditions.Add(
                new TableDataBaseRow(
                    new TableDataBaseCell[] { new TableDataBaseCell("UserID", UserID) }
                    )
                );
            query.Update();
            UserPassword = password;
        }

        public static ConnectionDataBase GetConnection() => DatabaseConnectionRythm.SettingsConnection();

        public static bool HaveUserFIO()
        {
            UserFIO = "";
            try
            {
                DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
                query.Table = "UserHanding";
                query.Conditions.Add(
                    new TableDataBaseRow(
                        new TableDataBaseCell[]
                        {
                        new TableDataBaseCell("UserID", UserID)
                        }
                        )
                    );
                TableDataBaseGrid table = query.GetCells();
                UserFIO = table[0].GetCell("UserFIO").TextValue;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        static string userFIO = "";

        public static string UserFIO
        {
            get => userFIO;
            set => userFIO = value;
        }

        static List<int> rolesIDs = new List<int>();
        public static List<int> RolesIDs => rolesIDs;

        public static bool HaveUserRole(int userID, List<int> rolesIDs)
        {
            //rolesIDs = new List<int>();
            List<int> RolesIDs = rolesIDs;
            RolesIDs.Clear();
            int UserID = userID;
            
            try
            {
                DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
                query.Table = "UserRole";
                query.Conditions.Add(
                    new TableDataBaseRow(
                        new TableDataBaseCell[]
                        {
                        new TableDataBaseCell("UserID", UserID)
                        }
                        )
                    );

                query.Sort.Add(new SortParameter("RoleID", Sort.asc));
                TableDataBaseGrid table = query.GetCells();

                if (table.Count <= 0)
                {
                    return false;
                }

                for (int i = 0; i < table.Count; i++)
                {
                    RolesIDs.Add(table[i].GetCell("RoleID").Int32Value);
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool HaveUserRole()
        {

            return HaveUserRole(UserID, RolesIDs);
        }

        public static bool HaveUserRole(string login, List<int> rolesIDs)
        {
            return HaveUserRole(Users.GetUser(login).ID, rolesIDs);
        }

        static Bitmap logotip;
        public static Bitmap Logotip
        {
            get => logotip;
            set => logotip = value;
        }


        private static string userEmail = "";

        public static string UserEmail
        {
            get => userEmail;
            set => userEmail = value;
        }

        private static string userTelephone = "";

        public static string UserTelephone
        {
            get => userTelephone;
            set => userTelephone = value;
        }


        public static bool HaveUserEmail()
        {
            UserEmail = "";
            try
            {
                DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
                query.Table = "UserEmail";
                query.Conditions.Add(
                    new TableDataBaseRow(
                        new TableDataBaseCell[]
                        {
                        new TableDataBaseCell("UserID", UserID)
                        }
                        )
                    );
                TableDataBaseGrid table = query.GetCells();
                UserEmail = table[0].GetCell("Email").TextValue;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool HaveUserTelephone()
        {
            UserEmail = "";
            try
            {
                DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
                query.Table = "UserTelefon";
                query.Conditions.Add(
                    new TableDataBaseRow(
                        new TableDataBaseCell[]
                        {
                        new TableDataBaseCell("UserID", UserID)
                        }
                        )
                    );
                TableDataBaseGrid table = query.GetCells();
                UserTelephone = table[0].GetCell("Telefon").TextValue;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        static List<UserEmail> userEmails = new List<UserEmail>();

        public static List<UserEmail> UserEmails => userEmails;

        static List<UserTelephone> userTelephones = new List<UserTelephone>();

        public static List<UserTelephone> UserTelephones => userTelephones;

        public static void GetUserEmails()
        {
            UserEmails.Clear();
            if(HaveUserEmail())
            {
                DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
                query.Table = "UserEmail";
                query.Conditions.Add(
                    new TableDataBaseRow(
                        new TableDataBaseCell[]
                        {
                        new TableDataBaseCell("UserID", UserID)
                        }
                        )
                    );
                TableDataBaseGrid table = query.GetCells();
                for(int i = 0; i < table.Count; i++)
                {
                    UserEmails.Add(new UserEmail(table[i]));
                }
            }
        }

        public static void GetUserTelephones()
        {
            UserTelephones.Clear();
            if (HaveUserTelephone())
            {
                DataBaseQuery query = new DataBaseQuery(DatabaseConnectionRythm.SettingsConnection());
                query.Table = "UserTelefon";
                query.Conditions.Add(
                    new TableDataBaseRow(
                        new TableDataBaseCell[]
                        {
                        new TableDataBaseCell("UserID", UserID)
                        }
                        )
                    );
                TableDataBaseGrid table = query.GetCells();
                for (int i = 0; i < table.Count; i++)
                {
                    UserTelephones.Add(new UserTelephone(table[i]));
                }
            }
        }


        public static void AddEmail(string email)
        {
            DataBaseQuery query = new DataBaseQuery(GetConnection());
            query.Table = "UserEmail";
            query.InputValues.AddRange(

                    new TableDataBaseCell[] { new TableDataBaseCell("UserID", UserID),
                            new TableDataBaseCell("Email", email)
                    }

                );
            query.Insert();

        }

        public static void DeleteEmail(int email)
        {
            DataBaseQuery query = new DataBaseQuery(GetConnection());
            query.Table = "UserEmail";
            query.Conditions.Add(
                        new TableDataBaseRow(
                            new TableDataBaseCell[] { new TableDataBaseCell("EmailID", email) }
                            )
                        );
            query.Delete();

        }

        public static void AddTelephone(string telephone)
        {
            DataBaseQuery query = new DataBaseQuery(GetConnection());
            query.Table = "UserTelefon";
            query.InputValues.AddRange(

                    new TableDataBaseCell[] { new TableDataBaseCell("UserID", UserID),
                            new TableDataBaseCell("Telefon", telephone)
                    }

                );
            query.Insert();

        }

        public static void DeleteTelephone(int telephone)
        {
            DataBaseQuery query = new DataBaseQuery(GetConnection());
            query.Table = "UserTelefon";
            query.Conditions.Add(
                        new TableDataBaseRow(
                            new TableDataBaseCell[] { new TableDataBaseCell("TelefonID", telephone) }
                            )
                        );
            query.Delete();

        }

        public static bool UpdateEmail(string email)
        {

            DataBaseQuery query = new DataBaseQuery(GetConnection());
            if (NullText(email))
            {
                try
                {

                    query.Table = "UserEmail";
                    query.Conditions.Add(
                        new TableDataBaseRow(
                            new TableDataBaseCell[] { new TableDataBaseCell("UserID", UserID) }
                            )
                        );
                    query.Delete();
                }
                catch
                {

                }
            }
            else
            {
                if (!HaveUserFIO())
                {

                    query.Table = "UserEmail";
                    query.InputValues.AddRange(

                            new TableDataBaseCell[] { new TableDataBaseCell("UserID", UserID),
                            new TableDataBaseCell("Email", email)
                            }

                        );
                    query.Insert();
                }
                else
                {

                    query.Table = "UserInitials";
                    query.Conditions.Add(new TableDataBaseRow(
                            new TableDataBaseCell[] { new TableDataBaseCell("UserID", UserID) })

                        ); ;
                    query.InputValues.AddRange(
                        new TableDataBaseRow(
                            new TableDataBaseCell[] {

                            new TableDataBaseCell("Email", email)
                            }
                            )
                        ) ;
                    query.Update();
                }

            }

            return HaveUserFIO();
        }


    }
}
