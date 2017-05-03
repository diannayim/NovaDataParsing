using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaChemicalsServer
{
    public class DatabaseConnection
    {
        private DatabaseConnection() { }

        private string databaseName = "novachemicals";
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DatabaseConnection _instance = null;
        public static DatabaseConnection Instance()
        {
            if (_instance == null)
                _instance = new DatabaseConnection();

            return _instance;
        }

        public bool IsConnect()
        {
            bool result = true;

            if (Connection == null)
            {
                string connString = "Server=199.116.235.43; database=novachemicals; UID=root; password=3beaseuofc!";
                connection = new MySqlConnection(connString);
                connection.Open();
                result = true;
            }

            return result;
        }

        public MySqlCommand CreateSQLCommand()
        {
            return connection.CreateCommand();
        }
    }
}
