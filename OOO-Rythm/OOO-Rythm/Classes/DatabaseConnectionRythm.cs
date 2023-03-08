using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Data.SqlClient;

namespace OOO_Rythm
{
    [DataContract]
    public class DatabaseConnectionRythm : ConnectionDataBase
    {
        public DatabaseConnectionRythm(SqlConnectionStringBuilder builder) : base(builder)
        {
        }

        public DatabaseConnectionRythm(string connectionString) : base(connectionString)
        {
        }

        public DatabaseConnectionRythm(ConnectionDataBase bulder) : base(bulder)
        {
        }

        public DatabaseConnectionRythm(string DataSource, string InitialCatalog, bool IntegratedSecurity, bool PersistSecurityInfo, string UserID, string Password, bool LocalServer = true) : base(DataSource, InitialCatalog, IntegratedSecurity, PersistSecurityInfo, UserID, Password, LocalServer)
        {
        }


        public DatabaseConnectionRythm() : base()
        {

        }

        public void LoadSettings()
        {
            ConnectionString = Properties.Settings.Default.ConnectionString;
            LocalServer = Properties.Settings.Default.LocalServer;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.ConnectionString = ConnectionString;
            Properties.Settings.Default.LocalServer = LocalServer;
            Properties.Settings.Default.Save();
        }

        public static void SaveSettings(string connectionString, bool localServer = true)
        {
            DatabaseConnectionRythm result = new DatabaseConnectionRythm(connectionString);
            result.LocalServer = localServer;
            result.SaveSettings();
        }

        public static DatabaseConnectionRythm SettingsConnection()
        {
            DatabaseConnectionRythm connection = new DatabaseConnectionRythm();
            connection.LoadSettings();
            return connection;
        }

    }
}
