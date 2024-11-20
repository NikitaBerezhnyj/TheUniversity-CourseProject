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

namespace TheUniversity.Forms.Action.Lesson
{
    public partial class ManageLessonForm : Form
    {
        private SqlConnection connection;
        private LessonServices lessonServices;

        private bool isEditMode = false;

        private int lessonId;
        private string lessonRoom;
        private DateTime lessonDate;
        private TimeSpan lessonTime;
        private string lessonType;
        private string lessonGroup;
        private int lessonTeacherId;
        private int lessonSubjectId;


        Dictionary<int, string> teachersDictionary;
        Dictionary<int, string> subjectssDictionary;

        public ManageLessonForm()
        {
            InitializeComponent();

            isEditMode = false;

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            lessonServices = new LessonServices(connection);

            label8.Text = "Додати пари";
            button1.Text = "Додати";

            teachersDictionary = lessonServices.GetTeacherDictionary();
            subjectssDictionary = lessonServices.GetSubjectDictionary();

            comboBox1.DataSource = new BindingSource(teachersDictionary, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            comboBox2.DataSource = new BindingSource(subjectssDictionary, null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";
        }

        public ManageLessonForm(int id, string room, DateTime date, TimeSpan time, string lesson_type, string group, int teacher_id, int subject_id)
        {
            InitializeComponent();

            isEditMode = true;

            lessonId = id;
            lessonRoom = room;
            lessonDate = date;
            lessonTime = time;
            lessonType = lesson_type;
            lessonGroup = group;
            lessonTeacherId = teacher_id;
            lessonSubjectId = subject_id;

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            lessonServices = new LessonServices(connection);

            label8.Text = "Редагувати пари";
            textBox1.Text = room;
            dateTimePicker1.Value = date;
            dateTimePicker2.Value = DateTime.Today.Add(time);
            comboBox3.Text = lesson_type;
            textBox2.Text = group;
            button1.Text = "Редагувати";

            teachersDictionary = lessonServices.GetTeacherDictionary();
            subjectssDictionary = lessonServices.GetSubjectDictionary();

            comboBox1.DataSource = new BindingSource(teachersDictionary, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            if (teachersDictionary.ContainsKey(teacher_id))
            {
                comboBox1.SelectedValue = teacher_id;
            }

            comboBox2.DataSource = new BindingSource(subjectssDictionary, null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";
            if (subjectssDictionary.ContainsKey(subject_id))
            {
                comboBox2.SelectedValue = subject_id;
            }
        }

        private bool ValidateManageLessonForm()
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

            if (textBox1.Text == lessonRoom &&
                comboBox3.Text == lessonType &&
                textBox2.Text == lessonGroup &&
                dateTimePicker1.Value == lessonDate &&
                dateTimePicker2.Value.TimeOfDay.Hours == lessonTime.Hours &&
                dateTimePicker2.Value.TimeOfDay.Minutes == lessonTime.Minutes &&
                (int)((KeyValuePair<int, string>)comboBox1.SelectedItem).Key == lessonTeacherId &&
                (int)((KeyValuePair<int, string>)comboBox2.SelectedItem).Key == lessonSubjectId)
            {
                MessageBox.Show("Ви не змінили жодного з полів. Зміни не потрібні.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ValidateManageLessonForm())
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
                    if (isEditMode == true)
                    {
                        lessonServices.EditLesson(lessonId, room, date, time, lesson_type, group, teacher_id, subject_id);
                    }
                    else
                    {
                        lessonServices.AddLesson(room, date, time, lesson_type, group, teacher_id, subject_id);
                    }
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при редагуванні пари: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
