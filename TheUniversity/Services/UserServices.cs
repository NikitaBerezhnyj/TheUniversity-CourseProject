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

                var columnMapping = new Dictionary<string, string>
                {
                    { "username", "Ім'я" },
                    { "password", "Пароль" },
                    { "role", "Роль в системі" },
                    { "id", "ID" }
                };

                foreach (var map in columnMapping)
                {
                    if (dataTable.Columns.Contains(map.Key))
                    {
                        dataTable.Columns[map.Key].ColumnName = map.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Something went wrong");
            }

            return dataTable;
        }

        public DataTable SearchUsers(string searchColumn, string searchValue)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            // Використовуємо оператор LIKE для часткового збігу
            string query = $"SELECT * FROM Users WHERE {searchColumn} LIKE @searchValue";

            DataTable dataTable = new DataTable();

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@searchValue", $"%{searchValue}%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }

                var columnMapping = new Dictionary<string, string>
                {
                    { "username", "Ім'я" },
                    { "password", "Пароль" },
                    { "role", "Роль в системі" },
                    { "id", "ID" }
                };

                foreach (var map in columnMapping)
                {
                    if (dataTable.Columns.Contains(map.Key))
                    {
                        dataTable.Columns[map.Key].ColumnName = map.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Щось пішло не так");
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
