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

        private bool ValidateAddUserForm()
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Ім'я користувача не може бути порожнім.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Пароль не може бути порожнім.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBox2.Text.Length < 8)
            {
                MessageBox.Show("Пароль повинен бути довший за 8 символів.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string passwordPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$&*_-]).{8,}$";
            if (!new System.Text.RegularExpressions.Regex(passwordPattern).IsMatch(textBox2.Text))
            {
                MessageBox.Show("Пароль повинен містити великі і маленькі літери, цифри та спеціальні символи.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Будь ласка, оберіть роль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!roleColumnMapping.ContainsKey(comboBox1.Text))
            {
                MessageBox.Show("Обрана роль є недійсною.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateAddUserForm())
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                string role = roleColumnMapping[comboBox1.Text];
                try
                {
                    userServices.AddUser(username, password, role);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при додаванні користувача: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
