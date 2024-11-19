using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace TheUniversity.Forms.Action.Lesson
{
    public partial class AddLessonForm : Form
    {
        private SqlConnection connection;
        private LessonServices lessonServices;

        Dictionary<int, string> teachersDictionary;
        Dictionary<int, string> subjectssDictionary;

        public AddLessonForm()
        {
            InitializeComponent();

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            lessonServices = new LessonServices(connection);

            teachersDictionary = lessonServices.GetTeacherDictionary();
            subjectssDictionary = lessonServices.GetSubjectDictionary();

            comboBox1.DataSource = new BindingSource(teachersDictionary, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            comboBox2.DataSource = new BindingSource(subjectssDictionary, null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";
        }

        private bool ValidateAddLessonForm()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Будь ласка, введіть номер аудиторії.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, оберіть викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, оберіть предмет.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox3.Text) || !new List<string> { "Лекція", "Практика", "Лабораторна робота", "Семінар", "Консультації", "Індивідуальне заняття" }.Contains(comboBox3.Text))
            {
                MessageBox.Show("Будь ласка, виберіть коректний тип заняття.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Будь ласка, введіть групу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("Дата заняття не може бути в минулому.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dateTimePicker2.Value.TimeOfDay == TimeSpan.Zero)
            {
                MessageBox.Show("Будь ласка, виберіть час заняття.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateAddLessonForm())
            {
                string room = textBox1.Text;
                DateTime date = dateTimePicker1.Value;
                TimeSpan time = dateTimePicker2.Value.TimeOfDay;
                string lesson_type = comboBox3.Text;
                string group = textBox2.Text;
                int teacher_id = (int)((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;
                int subject_id = (int)((KeyValuePair<int, string>)comboBox2.SelectedItem).Key;

                try
                {
                    lessonServices.AddLesson(room, date, time, lesson_type, group, teacher_id, subject_id);
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при редагуванні пари: " + ex.Message, "Помилка");
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
