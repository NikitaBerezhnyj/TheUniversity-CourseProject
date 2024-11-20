using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheUniversity.Configs;
using TheUniversity.Services;

namespace TheUniversity.Forms.Action.Teacher
{
    public partial class ManageTeacherForm : Form
    {
        private SqlConnection connection;
        private TeacherServices teacherServices;

        private bool isEditMode = false;

        private int teacherId;
        private string teacherFullName;
        private string teacherPosition;
        private string teacherDepartment;
        private string teacherAcdemicDegree;

        public ManageTeacherForm()
        {
            InitializeComponent();

            isEditMode = true;

            label5.Text = "Додати викладача";
            button1.Text = "Додати";

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            teacherServices = new TeacherServices(connection);
        }

        public ManageTeacherForm(int id, string full_name, string position, string department, string academic_degree)
        {
            InitializeComponent();

            isEditMode = true;

            teacherId = id;
            teacherFullName = full_name;
            teacherPosition = position;
            teacherDepartment = department;
            teacherAcdemicDegree = academic_degree;

            label5.Text = "Редагувати викладача";
            textBox1.Text = full_name;
            comboBox1.Text = position;
            comboBox2.Text = department;
            comboBox3.Text = academic_degree;
            button1.Text = "Редагувати";

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            teacherServices = new TeacherServices(connection);
        }

        private bool ValidateManageTeacherForm()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Будь ласка, введіть повне ім'я викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Будь ласка, оберіть посаду викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox1.Text) || !new List<string> { "Аспірант", "Асистент", "Доцент", "Старший викладач", "Професор", "Науковий співробітник", "Завідувач кафедри", "Декан факультету", "Проректор", "Ректор" }.Contains(comboBox1.Text))
            {
                MessageBox.Show("Будь ласка, оберіть коректну посаду викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Будь ласка, оберіть кафедру викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox2.Text) || !new List<string> { "Інформатики та програмування", "Математики", "Фізики", "Права", "Іноземних мов", "Історії", "Хімії", "Біології", "Менеджменту та маркетингу" }.Contains(comboBox2.Text))
            {
                MessageBox.Show("Будь ласка, оберіть коректну кафедру викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox3.Text))
            {
                MessageBox.Show("Будь ласка, оберіть академічний ступінь викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox3.Text) || !new List<string> { "Магістр", "Кандидат наук", "Доктор філософії", "Доктор наук", "Почесний доктор" }.Contains(comboBox3.Text))
            {
                MessageBox.Show("Будь ласка, оберіть коректний академічний ступінь викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (isEditMode == true)
            {
                if (textBox1.Text == teacherFullName && comboBox1.Text == teacherPosition && comboBox2.Text == teacherDepartment && comboBox3.Text == teacherAcdemicDegree)
                {
                    MessageBox.Show("Ви не змінили жодного з полів. Зміни не потрібні.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateManageTeacherForm())
            {
                string full_name = textBox1.Text;
                string position = comboBox1.Text;
                string department = comboBox2.Text;
                string academic_degree = comboBox2.Text;

                try
                {
                    if (isEditMode == true)
                    {
                        teacherServices.EditTeacher(teacherId, full_name, position, department, academic_degree);
                    }
                    else
                    {
                        teacherServices.AddTeacher(full_name, position, department, academic_degree);
                    }
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при додаванні викладача: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
