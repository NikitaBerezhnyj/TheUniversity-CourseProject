using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TheUniversity.Services
{
    internal class TeacherServices
    {
        private SqlConnection connection;

        public TeacherServices(SqlConnection connection)
        {
            this.connection = connection;
        }

        public DataTable GetTeachers()
        {
            string query = "SELECT * FROM Teacher";
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }

                var columnMapping = new Dictionary<string, string>
                {
                    { "full_name", "ПІП" },
                    { "department", "Кафедра" },
                    { "position", "Посада" },
                    { "academic_degree", "Вчений ступінь" }
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

        public DataTable SearchTeachers(string searchColumn, string searchValue)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            string query = $"SELECT * FROM Teacher WHERE {searchColumn} LIKE @searchValue";

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
                    { "full_name", "ПІП" },
                    { "department", "Кафедра" },
                    { "position", "Посада" },
                    { "academic_degree", "Вчений ступінь" }
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

        public void AddTeacher(string full_name, string position, string department, string academic_degree)
        {
            string query = "INSERT INTO Teacher (full_name, position, department, academic_degree) VALUES (@full_name, @position, @department, @academic_degree)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@full_name", full_name);
                command.Parameters.AddWithValue("@position", position);
                command.Parameters.AddWithValue("@department", department);
                command.Parameters.AddWithValue("@academic_degree", academic_degree);

                command.ExecuteNonQuery();
            }
        }

        public void EditTeacher(int id, string full_name, string position, string department, string academic_degree)
        {
            string query = "UPDATE Teacher SET full_name = @full_name, position = @position, department = @department, academic_degree = @academic_degree WHERE id = @id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@full_name", full_name);
                command.Parameters.AddWithValue("@position", position);
                command.Parameters.AddWithValue("@department", department);
                command.Parameters.AddWithValue("@academic_degree", academic_degree);

                command.ExecuteNonQuery();
            }
        }

        public void RemoveTeacher(int id)
        {
            string checkQuery = "SELECT COUNT(*) FROM Lesson WHERE teacher_id = @id";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@id", id);

                int lessonCount = (int)checkCommand.ExecuteScalar();

                if (lessonCount > 0)
                {
                    MessageBox.Show("Викладача не можна видалити, оскільки на нього ще записана пара.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string deleteQuery = "DELETE FROM Teacher WHERE id = @id";
            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
            {
                deleteCommand.Parameters.AddWithValue("@id", id);
                deleteCommand.ExecuteNonQuery();
            }
        }
    }
}
