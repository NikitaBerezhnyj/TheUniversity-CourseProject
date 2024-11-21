using iTextSharp.text.pdf;
using iTextSharp.text;
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
using TheUniversity.Forms.Action.Lesson;
using TheUniversity.Forms.Action.Subject;
using TheUniversity.Forms.Action.Teacher;
using TheUniversity.Forms.Action.User;
using TheUniversity.Services;
using System.Windows.Forms.VisualStyles;
using System.Drawing.Drawing2D;

namespace TheUniversity.Forms.View
{
    public partial class MainForm : Form
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

        public MainForm(string role)
        {
            InitializeComponent();

            if (role == "admin")
            {
                tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
                tabControl1.DrawItem += (sender, e) => tabControl1_DrawItem(sender, e, role);
            }
            else if (role == "teacher")
            {
                teacherActionsToolStripMenuItem.Enabled = false;
                usersActionsToolStripMenuItem.Enabled = false;
                exportUserTableToolStripMenuItem.Enabled = false;

                tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
                tabControl1.DrawItem += (sender, e) => tabControl1_DrawItem(sender, e, role);
                tabControl1.Selecting += tabControl1_Selecting;
            }
            else if (role == "student")
            {
                lessonActionsToolStripMenuItem.Enabled = false;
                subjectActionsToolStripMenuItem.Enabled = false;
                teacherActionsToolStripMenuItem.Enabled = false;
                usersActionsToolStripMenuItem.Enabled = false;
                exportUserTableToolStripMenuItem.Enabled = false;

                tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
                tabControl1.DrawItem += (sender, e) => tabControl1_DrawItem(sender, e, role);
                tabControl1.Selecting += tabControl1_Selecting;
            }
            else if (role == "guest")
            {
                lessonActionsToolStripMenuItem.Enabled = false;
                subjectActionsToolStripMenuItem.Enabled = false;
                teacherActionsToolStripMenuItem.Enabled = false;
                usersActionsToolStripMenuItem.Enabled = false;
                exportActionsToolStripMenuItem.Enabled = false;

                tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
                tabControl1.DrawItem += (sender, e) => tabControl1_DrawItem(sender, e, role);
                tabControl1.Selecting += tabControl1_Selecting;
            }
            else
            {
                MessageBox.Show("Ви ввійшли з незнайомою роллю. Через це програма не може продовжити свою роботу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

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

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e, string role)
        {
            TabControl tabControl = sender as TabControl;
            TabPage tabPage = tabControl.TabPages[e.Index];

            bool isGrayText = role != "admin" && tabPage == tabPage4;
            bool isSelected = e.Index == tabControl.SelectedIndex;

            Graphics graphics = e.Graphics;
            System.Drawing.Rectangle tabBounds = e.Bounds;
            tabBounds.Inflate(-2, -2);

            Color backgroundColor = isGrayText ? Color.FromArgb(230, 230, 230) : isSelected ? Color.White : Color.FromArgb(240, 240, 240);
            using (Brush backgroundBrush = new SolidBrush(backgroundColor))
            {
                graphics.FillRectangle(backgroundBrush, tabBounds);
            }

            using (Pen borderPen = new Pen(Color.FromArgb(200, 200, 200), 1))
            {
                graphics.DrawRectangle(borderPen, tabBounds);
            }

            Color textColor = isGrayText ? Color.DarkGray : isSelected ? Color.Black : Color.FromArgb(100, 100, 100);
            TextRenderer.DrawText(
                graphics,
                tabPage.Text,
                new System.Drawing.Font(e.Font.FontFamily, e.Font.Size, FontStyle.Regular),
                tabBounds,
                textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );

            if (isSelected)
            {
                System.Drawing.Rectangle shadowBounds = new System.Drawing.Rectangle(tabBounds.X + 1, tabBounds.Y + tabBounds.Height, tabBounds.Width, 3);
                using (Brush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                {
                    graphics.FillRectangle(shadowBrush, shadowBounds);
                }
            }

            if (isGrayText)
            {
                using (Brush overlayBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255)))
                {
                    graphics.FillRectangle(overlayBrush, tabBounds);
                }
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabPage4)
            {
                e.Cancel = true;
            }
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

                dataGridView1.Columns["Дата"].DisplayIndex = 0;
                dataGridView1.Columns["Час"].DisplayIndex = 1;
                dataGridView1.Columns["Аудиторія"].DisplayIndex = 2;
                dataGridView1.Columns["Тип заняття"].DisplayIndex = 3;
                dataGridView1.Columns["Група"].DisplayIndex = 4;
                dataGridView1.Columns["Викладач"].DisplayIndex = 5;
                dataGridView1.Columns["Предмет"].DisplayIndex = 6;
            }
        }

        private void LoadSubject()
        {
            DataTable subjects = subjectServices.GetSubjects();
            if (subjects != null)
            {
                dataGridView2.DataSource = subjects;
                dataGridView2.Columns["id"].Visible = false;

                dataGridView2.Columns["Назва"].DisplayIndex = 0;
                dataGridView2.Columns["Тип контролю"].DisplayIndex = 1;
                dataGridView2.Columns["Кількість годин"].DisplayIndex = 2;
                dataGridView2.Columns["Обов'язковість"].DisplayIndex = 3;
            }
        }

        private void LoadTeachers()
        {
            DataTable teachers = teacherServices.GetTeachers();
            if (teachers != null)
            {
                dataGridView3.DataSource = teachers;
                dataGridView3.Columns["id"].Visible = false;

                dataGridView3.Columns["ПІП"].DisplayIndex = 0;
                dataGridView3.Columns["Посада"].DisplayIndex = 1;
                dataGridView3.Columns["Кафедра"].DisplayIndex = 2;
                dataGridView3.Columns["Вчений ступінь"].DisplayIndex = 3;
            }
        }

        private void LoadUsers()
        {
            DataTable users = userServices.GetUsers();
            if (users != null)
            {
                dataGridView4.DataSource = users;
                dataGridView4.Columns["id"].Visible = false;

                dataGridView4.Columns["Ім'я"].DisplayIndex = 0;
                dataGridView4.Columns["Пароль"].DisplayIndex = 1;
                dataGridView4.Columns["Роль в системі"].DisplayIndex = 2;
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

                dataGridView1.Columns["Дата"].DisplayIndex = 0;
                dataGridView1.Columns["Час"].DisplayIndex = 1;
                dataGridView1.Columns["Аудиторія"].DisplayIndex = 2;
                dataGridView1.Columns["Тип заняття"].DisplayIndex = 3;
                dataGridView1.Columns["Група"].DisplayIndex = 4;
                dataGridView1.Columns["Викладач"].DisplayIndex = 5;
                dataGridView1.Columns["Предмет"].DisplayIndex = 6;
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

                dataGridView2.Columns["Назва"].DisplayIndex = 0;
                dataGridView2.Columns["Тип контролю"].DisplayIndex = 1;
                dataGridView2.Columns["Кількість годин"].DisplayIndex = 2;
                dataGridView2.Columns["Обов'язковість"].DisplayIndex = 3;
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

                dataGridView3.Columns["ПІП"].DisplayIndex = 0;
                dataGridView3.Columns["Посада"].DisplayIndex = 1;
                dataGridView3.Columns["Кафедра"].DisplayIndex = 2;
                dataGridView3.Columns["Вчений ступінь"].DisplayIndex = 3;
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

                dataGridView4.Columns["Ім'я"].DisplayIndex = 0;
                dataGridView4.Columns["Пароль"].DisplayIndex = 1;
                dataGridView4.Columns["Роль в системі"].DisplayIndex = 2;
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
        // Взаємодія з парами
        private void addLessonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLessonForm manageLessonForm = new ManageLessonForm();
            if (manageLessonForm.ShowDialog() == DialogResult.OK)
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

                    ManageLessonForm manageLessonForm = new ManageLessonForm(selectedId, selectedRoom, selectedDate, selectedTime, selectedLessonType, selectedGroup, selectedTeacherId, selectedSubjectId);
                    if (manageLessonForm.ShowDialog() == DialogResult.OK)
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
            ManageSubjectForm manageSubjectForm = new ManageSubjectForm();
            if (manageSubjectForm.ShowDialog() == DialogResult.OK)
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

                    ManageSubjectForm manageSubjectForm = new ManageSubjectForm(selectedId, selectedName, selectedControlType, selectedMandatory, selectedHours);
                    if (manageSubjectForm.ShowDialog() == DialogResult.OK)
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
            ManageTeacherForm manageTeacherForm = new ManageTeacherForm();
            if (manageTeacherForm.ShowDialog() == DialogResult.OK)
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

                    ManageTeacherForm manageTeacherForm = new ManageTeacherForm(selectedUserId, selectedFullName, selectedPosition, selectedDepartment, selectedAcademicDegree);
                    if (manageTeacherForm.ShowDialog() == DialogResult.OK)
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

        // Взаємодія з користувачами
        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUserForm manageUserForm = new ManageUserForm();
            if (manageUserForm.ShowDialog() == DialogResult.OK)
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

                    ManageUserForm manageUserForm = new ManageUserForm(selectedUserId, selectedUsername, selectedUserPassword, selectedUserRole);
                    if (manageUserForm.ShowDialog() == DialogResult.OK)
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

        // Експортування таблиць в pdf
        private void exportUserTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView4.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF (*.pdf)|*.pdf",
                    FileName = "Користувачі"
                };
                bool errorMessage = false;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        try
                        {
                            File.Delete(saveFileDialog.FileName);
                        }
                        catch
                        {
                            errorMessage = true;
                            MessageBox.Show($"Неможливо записати дані на диск: {saveFileDialog.FileName}", "Помилка");
                        }
                    }

                    if (!errorMessage)
                    {
                        try
                        {
                            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                            BaseFont baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                            iTextSharp.text.Font arialFont = new iTextSharp.text.Font(baseFont, 10);

                            var excludedColumns = new HashSet<string> { "ID" };

                            var visibleColumns = dataGridView4.Columns.Cast<DataGridViewColumn>()
                                .Where(col => !excludedColumns.Contains(col.Name))
                                .ToList();

                            PdfPTable pTable = new PdfPTable(visibleColumns.Count)
                            {
                                DefaultCell = { Padding = 4 },
                                WidthPercentage = 100,
                                HorizontalAlignment = Element.ALIGN_LEFT
                            };

                            foreach (var col in visibleColumns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText, arialFont))
                                {
                                    HorizontalAlignment = Element.ALIGN_CENTER
                                };
                                pTable.AddCell(pCell);
                            }

                            foreach (DataGridViewRow row in dataGridView4.Rows)
                            {
                                foreach (var col in visibleColumns)
                                {
                                    var cell = row.Cells[col.Index];
                                    string cellValue = cell.Value?.ToString() ?? string.Empty;
                                    pTable.AddCell(new Phrase(cellValue, arialFont));
                                }
                            }

                            using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                                document.Open();

                                Paragraph title = new Paragraph("Таблиця Користувачі з TheUniversity", new iTextSharp.text.Font(baseFont, 20))
                                {
                                    Alignment = Element.ALIGN_CENTER
                                };
                                document.Add(title);
                                document.Add(new Phrase("\n"));


                                document.Add(pTable);
                                document.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Помилка при отриманні даних з таблиці", "Помилка");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Записів не знайдено", "Помилка");
            }
        }

        private void exportLessonTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = "Пари";
                bool errorMessage = false;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        try
                        {
                            File.Delete(saveFileDialog.FileName);
                        }
                        catch
                        {
                            errorMessage = true;
                            MessageBox.Show($"Неможливо записати дані на диск: {saveFileDialog.FileName}", "Помилка");
                        }
                    }

                    if (!errorMessage)
                    {
                        try
                        {
                            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                            BaseFont baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                            iTextSharp.text.Font arialFont = new iTextSharp.text.Font(baseFont, 10);

                            var excludedColumns = new HashSet<string> { "id", "teacher_id", "subject_id" };
                            var visibleColumns = dataGridView1.Columns.Cast<DataGridViewColumn>()
                                .Where(col => !excludedColumns.Contains(col.Name))
                                .ToList();

                            PdfPTable pTable = new PdfPTable(visibleColumns.Count);
                            pTable.DefaultCell.Padding = 4;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (var col in visibleColumns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText, arialFont));
                                pCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (var col in visibleColumns)
                                {
                                    var cell = row.Cells[col.Index];
                                    string cellValue;

                                    if (cell.Value is DateTime dateTimeValue)
                                    {
                                        cellValue = dateTimeValue.ToString("dd.MM.yyyy");
                                    }
                                    else
                                    {
                                        cellValue = cell.Value?.ToString() ?? string.Empty;
                                    }

                                    pTable.AddCell(new Phrase(cellValue, arialFont));
                                }
                            }


                            using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                                document.Open();

                                Paragraph title = new Paragraph("Таблиця Пари з TheUniversity", new iTextSharp.text.Font(baseFont, 20));
                                title.Alignment = Element.ALIGN_CENTER;
                                document.Add(title);
                                document.Add(new Phrase("\n"));

                                document.Add(pTable);
                                document.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Помилка при отриманні даних з таблиці", "Помилка");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Записів не знайдено", "Помилка");
            }
        }

        private void exportSubjectTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = "Предмети";
                bool errorMessage = false;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        try
                        {
                            File.Delete(saveFileDialog.FileName);
                        }
                        catch
                        {
                            errorMessage = true;
                            MessageBox.Show($"Неможливо записати дані на диск: {saveFileDialog.FileName}", "Помилка");
                        }
                    }

                    if (!errorMessage)
                    {
                        try
                        {
                            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                            BaseFont baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                            iTextSharp.text.Font arialFont = new iTextSharp.text.Font(baseFont, 10);

                            var excludedColumns = new HashSet<string> { "id" };
                            var visibleColumns = dataGridView2.Columns.Cast<DataGridViewColumn>()
                                .Where(col => !excludedColumns.Contains(col.Name))
                                .ToList();

                            PdfPTable pTable = new PdfPTable(visibleColumns.Count);
                            pTable.DefaultCell.Padding = 4;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (var col in visibleColumns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText, arialFont));
                                pCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                pTable.AddCell(pCell);
                            }

                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                foreach (var col in visibleColumns)
                                {
                                    var cell = row.Cells[col.Index];
                                    string cellValue;

                                    if (cell.Value is bool boolValue)
                                    {
                                        cellValue = boolValue ? "Обов'язковий" : "Не обов'язковий";
                                    }
                                    else
                                    {
                                        cellValue = cell.Value?.ToString() ?? string.Empty;
                                    }

                                    pTable.AddCell(new Phrase(cellValue, arialFont));
                                }
                            }

                            using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                                document.Open();

                                Paragraph title = new Paragraph("Таблиця Предмети з TheUniversity", new iTextSharp.text.Font(baseFont, 20));
                                title.Alignment = Element.ALIGN_CENTER;
                                document.Add(title);
                                document.Add(new Phrase("\n"));

                                document.Add(pTable);
                                document.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Помилка при отриманні даних з таблиці", "Помилка");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Записів не знайдено", "Помилка");
            }
        }

        private void exportTeacherTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = "Викладачі";
                bool errorMessage = false;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        try
                        {
                            File.Delete(saveFileDialog.FileName);
                        }
                        catch
                        {
                            errorMessage = true;
                            MessageBox.Show($"Неможливо записати дані на диск: {saveFileDialog.FileName}", "Помилка");
                        }
                    }

                    if (!errorMessage)
                    {
                        try
                        {
                            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                            BaseFont baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                            iTextSharp.text.Font arialFont = new iTextSharp.text.Font(baseFont, 10);

                            var excludedColumns = new HashSet<string> { "id" };
                            var visibleColumns = dataGridView3.Columns.Cast<DataGridViewColumn>()
                                .Where(col => !excludedColumns.Contains(col.Name))
                                .ToList();

                            PdfPTable pTable = new PdfPTable(visibleColumns.Count);
                            pTable.DefaultCell.Padding = 4;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (var col in visibleColumns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText, arialFont));
                                pCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                pTable.AddCell(pCell);
                            }

                            foreach (DataGridViewRow row in dataGridView3.Rows)
                            {
                                foreach (var col in visibleColumns)
                                {
                                    string cellValue = row.Cells[col.Index].Value?.ToString() ?? string.Empty;
                                    pTable.AddCell(new Phrase(cellValue, arialFont));
                                }
                            }

                            using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                                document.Open();

                                Paragraph title = new Paragraph("Таблиця Викладачі з TheUniversity", new iTextSharp.text.Font(baseFont, 20));
                                title.Alignment = Element.ALIGN_CENTER;
                                document.Add(title);
                                document.Add(new Phrase("\n"));

                                document.Add(pTable);
                                document.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Помилка при отриманні даних з таблиці", "Помилка");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Записів не знайдено", "Помилка");
            }
        }

        // Конопки взаємодії з системою
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }

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
