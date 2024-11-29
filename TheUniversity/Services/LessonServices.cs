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
            WHERE l.{searchColumn} LIKE @searchValue";


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

        public Dictionary<int, string> GetTeacherDictionary()
        {
            Dictionary<int, string> teachersDictionary = new Dictionary<int, string>();
            string query = "SELECT id, full_name FROM Teacher";

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string fullName = reader.GetString(1);
                        teachersDictionary.Add(id, fullName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Something went wrong");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return teachersDictionary;
        }

        public Dictionary<int, string> GetSubjectDictionary()
        {
            Dictionary<int, string> subjectsDictionary = new Dictionary<int, string>();
            string query = "SELECT id, name FROM Subject";

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        subjectsDictionary.Add(id, name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Something went wrong");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return subjectsDictionary;
        }

        public bool IsLessonUnique(int teacher_id, DateTime date, TimeSpan time, int? id = null)
        {
            string query = "SELECT COUNT(*) FROM Lesson WHERE teacher_id = @teacher_id AND date = @date AND time = @time";

            if (id.HasValue)
            {
                query += " AND id != @id";
            }

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@teacher_id", teacher_id);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@time", time);

                if (id.HasValue)
                {
                    command.Parameters.AddWithValue("@id", id.Value);
                }

                int count = (int)command.ExecuteScalar();

                return count == 0;
            }
        }

        public void AddLesson(string room, DateTime date, TimeSpan time, string lesson_type, string group, int teacher_id, int subject_id)
        {
            if (!IsLessonUnique(teacher_id, date, time))
            {
                throw new Exception("Цей викладач вже має заняття на зазначену дату і час.");
            }

            string query = "INSERT INTO Lesson (room, date, time, lesson_type, [group], teacher_id, subject_id) " +
                           "VALUES (@room, @date, @time, @lesson_type, @group, @teacher_id, @subject_id)";
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@room", room);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@time", time);
                    command.Parameters.AddWithValue("@lesson_type", lesson_type);
                    command.Parameters.AddWithValue("@group", group);
                    command.Parameters.AddWithValue("@teacher_id", teacher_id);
                    command.Parameters.AddWithValue("@subject_id", subject_id);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні пари: {ex.Message}", "Щось пішло не так");
            }
        }

        public void EditLesson(int id, string room, DateTime date, TimeSpan time, string lesson_type, string group, int teacher_id, int subject_id)
        {
            if (!IsLessonUnique(teacher_id, date, time, id))
            {
                throw new Exception("Цей викладач вже має заняття на зазначену дату і час.");
            }

            string query = "UPDATE Lesson SET room = @room, date = @date, time = @time, lesson_type = @lesson_type, " +
                           "[group] = @group, teacher_id = @teacher_id, subject_id = @subject_id WHERE id = @id";
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@room", room);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@time", time);
                    command.Parameters.AddWithValue("@lesson_type", lesson_type);
                    command.Parameters.AddWithValue("@group", group);
                    command.Parameters.AddWithValue("@teacher_id", teacher_id);
                    command.Parameters.AddWithValue("@subject_id", subject_id);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while editing lesson: {ex.Message}", "Something went wrong");
            }
        }

        public void RemoveLesson(int id)
        {
            string query = "DELETE FROM Lesson WHERE id = @id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
