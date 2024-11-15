using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TheUniversity.Services
{
    internal class SubjectServices
    {
        private SqlConnection connection;

        public SubjectServices(SqlConnection connection)
        {
            this.connection = connection;
        }

        public DataTable GetSubjects()
        {
            string query = "SELECT * FROM Subject";
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }

                var columnMapping = new Dictionary<string, string>
                {
                    { "control_type", "Тип контролю" },
                    { "mandatory", "Обов'язковість" },
                    { "name", "Назва" },
                    { "hours", "Кількість годин" }
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

        public DataTable SearchSubjects(string searchColumn, string searchValue)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            string query = $"SELECT * FROM Subject WHERE {searchColumn} LIKE @searchValue";

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
                    { "control_type", "Тип контролю" },
                    { "mandatory", "Обов'язковість" },
                    { "name", "Назва" },
                    { "hours", "Кількість годин" }
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

        public void AddSubject(string name, string control_type, bool mandatory, int hours)
        {
            string query = "INSERT INTO Subject (name, control_type, mandatory, hours) VALUES (@name, @control_type, @mandatory, @hours)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@control_type", control_type);
                command.Parameters.AddWithValue("@mandatory", mandatory);
                command.Parameters.AddWithValue("@hours", hours);

                command.ExecuteNonQuery();
            }
        }

        public void EditSubject(int id, string name, string control_type, bool mandatory, int hours)
        {
            string query = "UPDATE Subject SET name = @name, control_type = @control_type, mandatory = @mandatory, hours = @hours WHERE id = @id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@control_type", control_type);
                command.Parameters.AddWithValue("@mandatory", mandatory);
                command.Parameters.AddWithValue("@hours", hours);

                command.ExecuteNonQuery();
            }
        }

        public void RemoveSubject(int id)
        {
            string checkQuery = "SELECT COUNT(*) FROM Lesson WHERE subject_id = @id";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@id", id);

                int lessonCount = (int)checkCommand.ExecuteScalar();

                if (lessonCount > 0)
                {
                    MessageBox.Show("Предмет не можна видалити, оскільки на нього ще записана пара.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string deleteQuery = "DELETE FROM Subject WHERE id = @id";
            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
            {
                deleteCommand.Parameters.AddWithValue("@id", id);
                deleteCommand.ExecuteNonQuery();
            }
        }
    }
}
