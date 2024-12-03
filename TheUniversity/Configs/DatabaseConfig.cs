using System.Data.SqlClient;

namespace TheUniversity.Configs
{
    internal class DatabaseConfig
    {
        private Config config;
        private SqlConnection connection;

        public DatabaseConfig()
        {
            this.config = new Config();
        }

        public SqlConnection OpenConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(config.ConnectionString);
                connection.Open();
            }
            return connection;
        }

        public void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
