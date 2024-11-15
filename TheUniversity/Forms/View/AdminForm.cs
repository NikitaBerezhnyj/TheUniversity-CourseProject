using System.Data;
using System.Threading;
using System.Data.SqlClient;
using TheUniversity.Configs;
using TheUniversity.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using TheUniversity.Forms.Action.User;
using System.Windows.Forms;
using TheUniversity.Forms.Action.Teacher;
using TheUniversity.Forms.Action.Subject;
using TheUniversity.Forms.Action.Lesson;

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

        // Взаємодія з парами
        private void addLessonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLessonForm addLessonForm = new AddLessonForm();
            if (addLessonForm.ShowDialog() == DialogResult.OK)
            {
                LoadLessons();
            }
        }

        private void editLessonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (int.TryParse(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString(), out int selectedId))
                {
                    string selectedRoom = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Аудиторія"].Value);
                    DateTime selectedDate = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["Дата"].Value);
                    TimeSpan selectedTime = (TimeSpan)dataGridView1.SelectedRows[0].Cells["Час"].Value;
                    string selectedLessonType = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Тип заняття"].Value);
                    string selectedGroup = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Група"].Value);
                    int selectedTeacherId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["teacher_id"].Value);
                    int selectedSubjectId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["subject_id"].Value);

                    EditLessonForm editLessonForm = new EditLessonForm(selectedId, selectedRoom, selectedDate, selectedTime, selectedLessonType, selectedGroup, selectedTeacherId, selectedSubjectId);
                    if (editLessonForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadLessons();
                    }
                }
                else
                {
                    MessageBox.Show("Помилка зчитування ID предмета.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть предмет для редагування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeLessonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedUserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                var result = MessageBox.Show("Ви впевнені, що хочете видалити цю пару?", "Підтвердження видалення", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        lessonServices.RemoveLesson(selectedUserId);
                        LoadLessons();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка при видаленні пари: " + ex.Message, "Помилка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть пару для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Взаємодія з предметами
        private void addSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSubjectForm addSubjectForm = new AddSubjectForm();
            if (addSubjectForm.ShowDialog() == DialogResult.OK)
            {
                LoadSubject();
            }
        }

        private void editSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                if (int.TryParse(dataGridView2.SelectedRows[0].Cells["id"].Value.ToString(), out int selectedId))
                {
                    string selectedName = Convert.ToString(dataGridView2.SelectedRows[0].Cells["Назва"].Value);
                    string selectedControlType = Convert.ToString(dataGridView2.SelectedRows[0].Cells["Тип контролю"].Value);
                    bool selectedMandatory = Convert.ToBoolean(dataGridView2.SelectedRows[0].Cells["Обов'язковість"].Value);
                    int selectedHours = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Кількість годин"].Value);

                    EditSubjectForm editSubjectForm = new EditSubjectForm(selectedId, selectedName, selectedControlType, selectedMandatory, selectedHours);
                    if (editSubjectForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadSubject();
                    }
                }
                else
                {
                    MessageBox.Show("Помилка зчитування ID предмета.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть предмет для редагування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedUserId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id"].Value);
                var result = MessageBox.Show("Ви впевнені, що хочете видалити цей предмет?", "Підтвердження видалення", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        subjectServices.RemoveSubject(selectedUserId);
                        LoadSubject();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка при видаленні предему: " + ex.Message, "Помилка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть предмет для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Взаємодія з викладачами
        private void addTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTeacherForm addTeacherForm = new AddTeacherForm();
            if (addTeacherForm.ShowDialog() == DialogResult.OK)
            {
                LoadTeachers();
            }
        }

        private void editTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                if (int.TryParse(dataGridView3.SelectedRows[0].Cells["id"].Value.ToString(), out int selectedUserId))
                {
                    string selectedFullName = Convert.ToString(dataGridView3.SelectedRows[0].Cells["ПІП"].Value);
                    string selectedPosition = Convert.ToString(dataGridView3.SelectedRows[0].Cells["Посада"].Value);
                    string selectedDepartment = Convert.ToString(dataGridView3.SelectedRows[0].Cells["Кафедра"].Value);
                    string selectedAcademicDegree = Convert.ToString(dataGridView3.SelectedRows[0].Cells["Вчений ступінь"].Value);

                    EditTeacherForm editTeacherForm = new EditTeacherForm(selectedUserId, selectedFullName, selectedPosition, selectedDepartment, selectedAcademicDegree);
                    if (editTeacherForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadTeachers();
                    }
                }
                else
                {
                    MessageBox.Show("Помилка зчитування ID викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть викладача для редагування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                int selectedUserId = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells["id"].Value);
                var result = MessageBox.Show("Ви впевнені, що хочете видалити цього викладача?", "Підтвердження видалення", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        teacherServices.RemoveTeacher(selectedUserId);
                        LoadTeachers();
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

        // Кнопки виходу
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();

            Form loginForm = new LoginForm();

            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
