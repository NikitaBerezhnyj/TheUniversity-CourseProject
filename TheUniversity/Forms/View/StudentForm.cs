using System.Data;
using System.Threading;
using System.Data.SqlClient;
using TheUniversity.Configs;
using TheUniversity.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace TheUniversity.Forms
{
    public partial class StudentForm : Form
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

        public StudentForm()
        {
            InitializeComponent();

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            lessonServices = new LessonServices(connection);
            subjectServices = new SubjectServices(connection);
            teacherServices = new TeacherServices(connection);

            LoadLessons();
            LoadSubject();
            LoadTeachers();
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

            LoadTeachers();
        }

        // Верхня панель
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

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();

            Form loginForm = new LoginForm();

            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void закритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
