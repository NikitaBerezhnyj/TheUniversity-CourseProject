using System.Data;
using System.Threading;
using System.Data.SqlClient;
using TheUniversity.Configs;
using TheUniversity.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using TheUniversity.Forms.Action.User;
using System.Windows.Forms;

namespace TheUniversity.Forms
{
    public partial class AdminForm : Form
    {
        private LessonServices lessonServices;
        private SubjectServices subjectServices;
        private TeacherServices teacherServices;
        private UserServices userServices;
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

        private Dictionary<string, string> userColumnMapping = new Dictionary<string, string>
        {
            { "імені", "username" },
            { "паролю", "password" },
            { "ролі в системі", "role" }
        };

        public AdminForm()
        {
            InitializeComponent();

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            lessonServices = new LessonServices(connection);
            subjectServices = new SubjectServices(connection);
            teacherServices = new TeacherServices(connection);
            userServices = new UserServices(connection);

            LoadLessons();
            LoadSubject();
            LoadTeachers();
            LoadUsers();
        }

        private void LoadLessons()
        {
            DataTable lessons = lessonServices.GetLessons();
            if (lessons != null)
            {
                dataGridView1.DataSource = lessons;
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["teacher_id"].Visible = false;
                dataGridView1.Columns["subject_id"].Visible = false;
            }
        }

        private void LoadSubject()
        {
            DataTable subjects = subjectServices.GetSubjects();
            if (subjects != null)
            {
                dataGridView2.DataSource = subjects;
                dataGridView2.Columns["id"].Visible = false;
            }
        }

        private void LoadTeachers()
        {
            DataTable teachers = teacherServices.GetTeachers();
            if (teachers != null)
            {
                dataGridView3.DataSource = teachers;
                dataGridView3.Columns["id"].Visible = false;
            }
        }

        private void LoadUsers()
        {
            DataTable users = userServices.GetUsers();
            if (users != null)
            {
                dataGridView4.DataSource = users;
                dataGridView4.Columns["id"].Visible = false;
            }
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
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["teacher_id"].Visible = false;
                dataGridView1.Columns["subject_id"].Visible = false;
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
            LoadLessons();
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
                dataGridView2.Columns["id"].Visible = false;
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
            LoadSubject();
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

            string searchValue = textBox3.Text;
            DataTable teachers = teacherServices.SearchTeachers(searchColumn, searchValue);

            if (teachers != null)
            {
                dataGridView3.DataSource = teachers;
                dataGridView3.Columns["id"].Visible = false;
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
            LoadTeachers();
        }

        // Вкладка перегляду користувачів
        private void button8_Click(object sender, EventArgs e)
        {
            string searchColumn = comboBox4.Text;
            if (userColumnMapping.ContainsKey(searchColumn))
            {
                searchColumn = userColumnMapping[searchColumn];
            }
            else
            {
                MessageBox.Show("Невідомий критерій пошуку.");
                return;
            }

            string searchValue = textBox4.Text;
            DataTable users = userServices.SearchUsers(searchColumn, searchValue);

            if (users != null)
            {
                dataGridView4.DataSource = users;
                dataGridView4.Columns["id"].Visible = false;
            }
            else
            {
                MessageBox.Show("Нічого не знайдено");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox4.SelectedIndex = -1;
            textBox4.Clear();
            LoadUsers();
        }

        // Верхня панель
        // Взаємодія з користувачами
        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            if (addUserForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                if (int.TryParse(dataGridView4.SelectedRows[0].Cells["id"].Value.ToString(), out int selectedUserId))
                {
                    string selectedUsername = Convert.ToString(dataGridView4.SelectedRows[0].Cells["Ім'я"].Value);
                    string selectedUserPassword = Convert.ToString(dataGridView4.SelectedRows[0].Cells["Пароль"].Value);
                    string selectedUserRole = Convert.ToString(dataGridView4.SelectedRows[0].Cells["Роль в системі"].Value);

                    EditUserForm editUserForm = new EditUserForm(selectedUserId, selectedUsername, selectedUserPassword, selectedUserRole);
                    if (editUserForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadUsers();
                    }
                }
                else
                {
                    MessageBox.Show("Помилка зчитування ID користувача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть користувача для редагування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedUserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                var result = MessageBox.Show("Ви впевнені, що хочете видалити цього користувача?", "Підтвердження видалення", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    userServices.RemoveUser(selectedUserId);
                    DataTable users = userServices.GetUsers();
                    if (users != null)
                    {
                        dataGridView4.DataSource = users;
                    }
                    MessageBox.Show("Користувача успішно видалено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Видалення скасовано.", "Скасування", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть користувача для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Взаємодія з парами
        private void addLessonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editLessonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removeLessonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Взаємодія з предметами
        private void addSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removeSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Взаємодія з викладачами
        private void addTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removeTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Кнопки виходу
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();
            this.Close();
            openFormThread = new Thread(BackToLoginForm);
            openFormThread.SetApartmentState(ApartmentState.STA);
            openFormThread.Start();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ____________________________________________________________________________________________

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                int selectedUserId = Convert.ToInt32(dataGridView4.SelectedRows[0].Cells["id"].Value);
                var result = MessageBox.Show("Ви впевнені, що хочете видалити цього користувача?", "Підтвердження видалення", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        userServices.RemoveUser(selectedUserId);
                        LoadUsers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка при видаленні користувача: " + ex.Message, "Помилка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть користувача для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();
            this.Close();
            openFormThread = new Thread(BackToLoginForm);
            openFormThread.SetApartmentState(ApartmentState.STA);
            openFormThread.Start();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
