using System.Data;
using System.Threading;
using System.Data.SqlClient;
using TheUniversity.Configs;
using TheUniversity.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TheUniversity.Forms
{
    public partial class StudentViewForm : Form
    {
        private LessonServices lessonServices;
        private SubjectServices subjectServices;
        private TeacherServices teacherServices;
        private SqlConnection connection;
        private Thread openFormThread;

        private Dictionary<string, string> lessonColumnMapping = new Dictionary<string, string>
        {
            { "групі", "[group]" },
            { "аудиторії", "room" },
            { "даті", "date" },
            { "часу", "time" },
            { "виду заняття", "lesson_type" }
        };

        private Dictionary<string, string> subjectColumnMapping = new Dictionary<string, string>
        {
            { "обов'язковості", "mandatory" },
            { "типу контролю", "control_type" },
            { "назві", "name" },
            { "кількості годин", "hours" }
        };

        private Dictionary<string, string> teacherColumnMapping = new Dictionary<string, string>
        {
            { "посаді", "position" },
            { "кафедрі", "department" },
            { "піп", "full_name" },
            { "вченому ступеню", "academic_degree" }
        };

        public StudentViewForm()
        {
            InitializeComponent();

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            lessonServices = new LessonServices(connection);
            subjectServices = new SubjectServices(connection);
            teacherServices = new TeacherServices(connection);

            dataGridView1.DataSource = lessonServices.GetLessons();
            dataGridView2.DataSource = subjectServices.GetSubjects();
            dataGridView3.DataSource = teacherServices.GetTeachers();
        }

        private void BackToLoginForm(object form)
        {
            Application.Run(new LoginForm());
        }

        // Вкладка перегляду пар
        private void button1_Click(object sender, EventArgs e)
        {
            string searchColumn = comboBox1.Text;
            if (lessonColumnMapping.ContainsKey(searchColumn))
            {
                searchColumn = lessonColumnMapping[searchColumn];
            }
            else
            {
                MessageBox.Show("Невідомий критерій пошуку.");
                return;
            }

            string searchValue = textBox1.Text;
            DataTable lessons = lessonServices.SearchLessons(searchColumn, searchValue);

            if (lessons != null)
            {
                dataGridView1.DataSource = lessons;
            }
            else
            {
                MessageBox.Show("Нічого не знайдено");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();

            DataTable lessons = lessonServices.GetLessons();
            if (lessons != null)
            {
                dataGridView1.DataSource = lessons;
            }
        }

        // Вкладка перегляду предметів
        private void button4_Click(object sender, EventArgs e)
        {
            string searchColumn = comboBox2.Text;
            if (subjectColumnMapping.ContainsKey(searchColumn))
            {
                searchColumn = subjectColumnMapping[searchColumn];
            }
            else
            {
                MessageBox.Show("Невідомий критерій пошуку.");
                return;
            }

            string searchValue = textBox2.Text;
            DataTable subjects = subjectServices.SearchSubjects(searchColumn, searchValue);

            if (subjects != null)
            {
                dataGridView2.DataSource = subjects;
            }
            else
            {
                MessageBox.Show("Нічого не знайдено");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = -1;
            textBox2.Clear();

            DataTable subjects = subjectServices.GetSubjects();
            if (subjects != null)
            {
                dataGridView2.DataSource = subjects;
            }
        }

        // Вкладка перегляду викладачів
        private void button6_Click(object sender, EventArgs e)
        {
            string searchColumn = comboBox3.Text;
            if (teacherColumnMapping.ContainsKey(searchColumn))
            {
                searchColumn = teacherColumnMapping[searchColumn];
            }
            else
            {
                MessageBox.Show("Невідомий критерій пошуку.");
                return;
            }

            string searchValue = textBox2.Text;
            DataTable teachers = teacherServices.SearchTeachers(searchColumn, searchValue);

            if (teachers != null)
            {
                dataGridView3.DataSource = teachers;
            }
            else
            {
                MessageBox.Show("Нічого не знайдено");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = -1;
            textBox3.Clear();

            DataTable teachers = teacherServices.GetTeachers();
            if (teachers != null)
            {
                dataGridView3.DataSource = teachers;
            }
        }

        // Верхня панель
        private void label1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();
            this.Close();
            openFormThread = new Thread(BackToLoginForm);
            openFormThread.SetApartmentState(ApartmentState.STA);
            openFormThread.Start();
        }
    }
}
