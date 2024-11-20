using System.Data.SqlClient;
using System.Text;

namespace TheUniversity.Services
{
    public class AuthServices
    {
        private SqlConnection connection;

        public AuthServices(SqlConnection connection)
        {
            this.connection = connection;
        }

        public bool AuthenticateUser(string username, string password, out string role)
        {
            role = string.Empty;

            if (connection.State != System.Data.ConnectionState.Open)
            {
                return false;
            }

            string query = "SELECT password, role FROM Users WHERE username = @username";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", username);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    string storedPassword = reader.GetString(0);
                    role = reader.GetString(1);

                    if (password == storedPassword)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
