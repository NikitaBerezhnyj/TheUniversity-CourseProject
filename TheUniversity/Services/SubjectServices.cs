using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                dataTable.Columns.Remove("id");
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

            string query = $"SELECT * FROM Subject WHERE {searchColumn} = @searchValue";

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
