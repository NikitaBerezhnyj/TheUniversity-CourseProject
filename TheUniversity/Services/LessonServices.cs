using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUniversity.Services
{
    internal class LessonServices
    {
        private SqlConnection connection;

        public LessonServices(SqlConnection connection)
        {
            this.connection = connection;
        }

        public DataTable GetLessons()
        {
            string query = "SELECT l.*, t.full_name AS teacher_name, s.name AS subject_name " +
                           "FROM Lesson l " +
                           "LEFT JOIN Teacher t ON l.teacher_id = t.id " +
                           "LEFT JOIN Subject s ON l.subject_id = s.id";
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }

                dataTable.Columns.Remove("id");
                dataTable.Columns.Remove("teacher_id");
                dataTable.Columns.Remove("subject_id");

                var columnMapping = new Dictionary<string, string>
                {
                    { "teacher_name", "Викладач" },
                    { "subject_name", "Предмет" },
                    { "lesson_type", "Тип заняття" },
                    { "room", "Аудиторія" },
                    { "group", "Група" },
                    { "date", "Дата" },
                    { "time", "Час" },
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

        public DataTable SearchLessons(string searchColumn, string searchValue)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            string query = $@"
            SELECT l.*, t.full_name AS teacher_name, s.name AS subject_name
            FROM Lesson l
            LEFT JOIN Teacher t ON l.teacher_id = t.id
            LEFT JOIN Subject s ON l.subject_id = s.id
            WHERE l.{searchColumn} = @searchValue";

            DataTable dataTable = new DataTable();

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@searchValue", searchValue);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }

                dataTable.Columns.Remove("id");
                dataTable.Columns.Remove("teacher_id");
                dataTable.Columns.Remove("subject_id");

                var columnMapping = new Dictionary<string, string>
                {
                    { "teacher_name", "Викладач" },
                    { "subject_name", "Предмет" },
                    { "lesson_type", "Тип заняття" },
                    { "room", "Аудиторія" },
                    { "group", "Група" },
                    { "date", "Дата" },
                    { "time", "Час" },
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

    }
}
