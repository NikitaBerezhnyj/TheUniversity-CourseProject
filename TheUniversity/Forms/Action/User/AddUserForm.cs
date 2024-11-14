using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheUniversity.Configs;
using TheUniversity.Services;

namespace TheUniversity.Forms.Action.User
{
    public partial class AddUserForm : Form
    {
        private SqlConnection connection;
        private UserServices userServices;

        private Dictionary<string, string> roleColumnMapping = new Dictionary<string, string>
        {
            { "Студент", "student" },
            { "Викладач", "teacher" },
            { "Адміністратор", "admin" }
        };

        public AddUserForm()
        {
            InitializeComponent();

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            userServices = new UserServices(connection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string role = comboBox1.Text;

            if (roleColumnMapping.ContainsKey(role))
            {
                role = roleColumnMapping[role];
            }
            else
            {
                MessageBox.Show("Невідома роль.");
                return;
            }

            try
            {
                userServices.AddUser(username, password, role);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при додаванні користувача: " + ex.Message, "Помилка");
            }
            finally
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
