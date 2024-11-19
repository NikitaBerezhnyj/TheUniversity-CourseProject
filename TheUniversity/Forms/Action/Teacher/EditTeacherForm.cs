using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TheUniversity.Services;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using TheUniversity.Configs;

namespace TheUniversity.Forms.Action.Teacher
{
    public partial class EditTeacherForm : Form
    {
        private SqlConnection connection;
        private TeacherServices teacherServices;

        private int teacherId;
        private string teacherFullName;
        private string teacherPosition;
        private string teacherDepartment;
        private string teacherAcdemicDegree;


        public EditTeacherForm(int id, string full_name, string position, string department, string academic_degree)
        {
            InitializeComponent();

            teacherId = id;
            teacherFullName = full_name;
            teacherPosition = position;
            teacherDepartment = department;
            teacherAcdemicDegree = academic_degree;

            textBox1.Text = full_name;
            comboBox1.Text = position;
            comboBox2.Text = department;
            comboBox3.Text = academic_degree;

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            teacherServices = new TeacherServices(connection);
        }

        private bool ValidateEditTeacherForm()
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

            if (textBox1.Text == teacherFullName && comboBox1.Text == teacherPosition && comboBox2.Text == teacherDepartment && comboBox3.Text == teacherAcdemicDegree)
            {
                MessageBox.Show("Ви не змінили жодного з полів. Зміни не потрібні.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateEditTeacherForm())
            {
                string full_name = textBox1.Text;
                string position = comboBox1.Text;
                string department = comboBox2.Text;
                string academic_degree = comboBox3.Text;

                try
                {
                    teacherServices.EditTeacher(teacherId, full_name, position, department, academic_degree);
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при редагуванні викладача: " + ex.Message, "Помилка");
                }
                finally
                {
                    this.Close();
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
