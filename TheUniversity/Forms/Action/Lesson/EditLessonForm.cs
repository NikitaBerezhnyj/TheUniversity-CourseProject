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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TheUniversity.Forms.Action.Lesson
{
    public partial class EditLessonForm : Form
    {
        private SqlConnection connection;
        private LessonServices lessonServices;

        private int userId;
        Dictionary<int, string> teachersDictionary;
        Dictionary<int, string> subjectssDictionary;

        public EditLessonForm(int id, string room, DateTime date, TimeSpan time, string lesson_type, string group, int teacher_id, int subject_id)
        {
            InitializeComponent();

            userId = id;

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            lessonServices = new LessonServices(connection);

            textBox1.Text = room;
            dateTimePicker1.Value = date;
            dateTimePicker2.Value = DateTime.Today.Add(time);
            comboBox3.Text = lesson_type;
            textBox2.Text = group;

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

        private void button1_Click(object sender, EventArgs e)
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
                lessonServices.EditLesson(userId, room, date, time, lesson_type, group, teacher_id, subject_id);
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
