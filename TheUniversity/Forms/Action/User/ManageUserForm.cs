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
    public partial class ManageUserForm : Form
    {
        private SqlConnection connection;
        private UserServices userServices;

        private bool isEditMode = false;

        private int userId;
        private string userName;
        private string userPassword;
        private string userRole;

        private Dictionary<string, string> roleColumnMapping = new Dictionary<string, string>
        {
            { "Студент", "student" },
            { "Викладач", "teacher" },
            { "Адміністратор", "admin" }
        };

        public ManageUserForm()
        {
            InitializeComponent();

            isEditMode = false;

            label4.Text = "Додавання користувача";
            button1.Text = "Додати";

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            userServices = new UserServices(connection);

            MessageBox.Show(Convert.ToString(connection.State), "Connection state: ");
        }

        public ManageUserForm(int id, string username, string password, string role)
        {
            InitializeComponent();

            isEditMode = true;

            userId = id;
            userName = username;
            userPassword = password;
            userRole = role;

            label4.Text = "Редагування користувача";
            textBox1.Text = username;
            textBox2.Text = password;
            comboBox1.Text = roleColumnMapping.FirstOrDefault(x => x.Value == role).Key;
            button1.Text = "Редагувати";

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            userServices = new UserServices(connection);
        }

        private bool ValidateManageUserForm()
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

            string passwordPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$&*^%_+\-=]).{8,}$";
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

            if (isEditMode)
            {
                if (textBox1.Text == userName && textBox2.Text == userPassword && roleColumnMapping[comboBox1.Text] == userRole)
                {
                    MessageBox.Show("Ви не змінили жодного з полів. Зміни не потрібні.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateManageUserForm())
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                string role = roleColumnMapping[comboBox1.Text];

                try
                {
                    if (isEditMode == true)
                    {
                        userServices.EditUser(userId, username, password, role);
                    }
                    else
                    {
                        userServices.AddUser(username, password, role);
                    }

                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    if (isEditMode)
                    {
                        MessageBox.Show("Помилка при редагуванні користувача: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Помилка при додаванні користувача: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
