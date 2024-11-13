using System.Data;
using System.Data.SqlClient;

namespace TheUniversity.Services
{

    internal class UserServices
    {
        private SqlConnection connection;

        public UserServices(SqlConnection connection)
        {
            this.connection = connection;
        }

        public DataTable GetUsers()
        {
            string query = "SELECT * FROM Users";
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Something went wrong");
            }

            return dataTable;
        }


        public void AddUser(string username, string password, string role) {
            string query = "INSERT INTO Users (username, password, role) VALUES (@username, @password, @role)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@role", role);

                command.ExecuteNonQuery();
            }
        }

        public void EditUser(int id, string username, string password, string role) {
            string query = "UPDATE Users SET username = @username, password = @password, role = @role WHERE id = @id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@role", role);

                command.ExecuteNonQuery();
            }
        }

        public void RemoveUser(int id) {
            string query = "DELETE FROM Users WHERE id = @id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
