using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Service.DataBaseManager
{
    public class BaseDatabaseManager
    {
        protected BaseDatabaseManager() { }

        public static MySqlConnection connection
        {
            get
            {
                MySqlConnection connection = new MySqlConnection();
                string connectionString = "SERVER=localhost;" + "DATABASE=wcfserver01;" + "UID=root;" + "PASSWORD=;" + "SSL MODE=none;";
                connection.ConnectionString = connectionString;
                return connection;
            }
        }
    }
}