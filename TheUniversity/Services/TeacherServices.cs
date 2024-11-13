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

                dataTable.Columns.Remove("id");
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

            string query = $"SELECT * FROM Teacher WHERE {searchColumn} = @searchValue";

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

                dataTable.Columns.Remove("id");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Something went wrong");
            }

            return dataTable;
        }
    }
}
