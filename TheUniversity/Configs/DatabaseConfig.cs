using System.Data.SqlClient;

namespace TheUniversity.Configs
{
    internal class DatabaseConfig
    {
        private SqlConnection connection;

        public SqlConnection OpenConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(@"Server=DESKTOP-TU55I9Q\SQLEXPRESS;Database=TheUniversity;Integrated Security=True;");
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
