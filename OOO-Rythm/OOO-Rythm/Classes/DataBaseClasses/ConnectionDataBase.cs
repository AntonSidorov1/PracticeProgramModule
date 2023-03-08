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
    public class ConnectionDataBase
    {
        public ConnectionDataBase(string DataSource, string InitialCatalog, bool IntegratedSecurity, bool PersistSecurityInfo, string UserID, string Password, bool LocalServer = true) : this()
        {
            Server = DataSource;
            DataBase = InitialCatalog;
            this.IntegratedSecurity = IntegratedSecurity;
            this.PersistSecurityInfo = PersistSecurityInfo;
            this.LocalServer = LocalServer;
            this.UserID = UserID;
            this.Password = Password;
        }

        public ConnectionDataBase()
        {

        }

        public ConnectionDataBase(SqlConnectionStringBuilder builder)
        {
            Builder = builder;
        }

        public SqlConnectionStringBuilder Builder { get => new SqlConnectionStringBuilder(ConnectionString); set => ConnectionString = value.ConnectionString; }

        public ConnectionDataBase(string connectionString) : this()
        {
            ConnectionString = connectionString;
        }

        public ConnectionDataBase(ConnectionDataBase bulder) : this(bulder.ConnectionString)
        {

        }

        /// <summary>
        /// Возвращает стркоу подключения к базе данных
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Connection;

        public SqlConnection SqlConnection
        {
            get => new SqlConnection(ConnectionString);
            set => ConnectionString = value.ConnectionString;
        }


        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        public string Connsection
        {
            get
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = DataSource;
                builder.InitialCatalog = InitialCatalog;
                builder.IntegratedSecurity = IntegratedSecurity;
                builder.PersistSecurityInfo = PersistSecurityInfo;
                builder.UserID = UserID;
                builder.Password = Password;

                return builder.ConnectionString;
            }
            set
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(value);
                DataSource = builder.DataSource;
                InitialCatalog = builder.InitialCatalog;
                IntegratedSecurity = builder.IntegratedSecurity;
                PersistSecurityInfo = builder.PersistSecurityInfo;
                UserID = builder.UserID;
                Password = builder.Password;
            }
        }

        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        public string Connection { get => Connsection; set => Connsection = value; }

        // <summary>
        /// Строка подключения к базе данных
        /// </summary>
        public string ConnectionString
        {
            get => Connection;
            set => Connection = value;
        }

        /// <summary>
        /// Сервер и база данных
        /// </summary>
        public string ServerDB => DataSource + "\\" + InitialCatalog;

        string server = "", dataBase = "", userID = "", password = "";
        bool integratedSecurity = true, persistSecurityInfo = false, localServer = true;

        [DataMember]
        public string UserID
        {
            get => userID;
            set => userID = value;
        }

        [DataMember]
        public string Password
        {
            get => password;
            set => password = value;
        }

        [DataMember]
        public bool LocalServer
        {
            get => localServer;
            set => localServer = value;
        }

        [DataMember]
        public bool IntegratedSecurity
        {
            get => integratedSecurity;
            set => integratedSecurity = value;
        }

        [DataMember]
        public bool PersistSecurityInfo
        {
            get => persistSecurityInfo;
            set => persistSecurityInfo = value;
        }

        [DataMember]
        public string DataSource
        {
            get => server;
            set => server = value;
        }

        [DataMember]
        public string Server
        {
            get => DataSource;
            set => DataSource = value;
        }

        [DataMember]
        public string InitialCatalog
        {
            get => dataBase;
            set => dataBase = value;
        }

        [DataMember]
        public string DataBase
        {
            get => InitialCatalog;
            set => InitialCatalog = value;
        }



        public void SaveJson(string fileName)
        {
            fileName = fileName.Replace('/', '\\');
            string[] points = fileName.Split('.');
            int last = points.Length - 1;
            points[last] = points[last].Trim().ToLower();
            fileName = string.Join(".", points);
            JsonWrite(this, this.GetType(), fileName);
        }



        /// <summary>
        /// Сохраняет объект obj с типом type в Json-файл namefile
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="namefile"></param>
        private static void JsonWrite(object obj, Type type, string namefile)
        {
            namefile = namefile.Replace('/', '\\');
            DataContractJsonSerializer json = new DataContractJsonSerializer(type);
            FileStream fileStream = new FileStream(namefile, FileMode.Create);
            json.WriteObject(fileStream, obj);
        }


        /// <summary>
        /// Чтение из Json-файла
        /// </summary>
        /// <param name="namefile"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object JsonRead(string namefile, Type type)
        {

            namefile = namefile.Replace('/', '\\');
            DataContractJsonSerializer json = new DataContractJsonSerializer(type);
            FileStream fileStream = new FileStream(namefile, FileMode.Open);
            try
            {
                object obj = json.ReadObject(fileStream);
                fileStream.Close();
                return obj;
            }
            catch
            {
                fileStream.Close();
                object obj = json.ReadObject(fileStream);
                return obj;
            }


        }

        public static ConnectionDataBase Load(string fileName)
        {


            return (ConnectionDataBase)JsonRead(fileName, typeof(ConnectionDataBase));
        }

        public void Loadjson(string fileName)
        {
            ConnectionDataBase dataBase = Load(fileName);
            ConnectionString = dataBase.ConnectionString;
            LocalServer = dataBase.LocalServer;
        }

    }
}

