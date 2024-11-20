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

namespace TheUniversity.Forms.Action.Subject
{
    public partial class ManageSubjectForm : Form
    {
        private SqlConnection connection;
        private SubjectServices subjectServices;

        private bool isEditMode = false;

        private int subjectId;
        private string subjectName;
        private string subjectControlType;
        private bool subjectMandatory;
        private int subjectHours;

        public ManageSubjectForm()
        {
            InitializeComponent();

            isEditMode = false;

            label3.Text = "Додати предмет";
            button1.Text = "Додати";

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            subjectServices = new SubjectServices(connection);
        }

        public ManageSubjectForm(int selectedId, string selectedName, string selectedControlType, bool selectedMandatory, int selectedHours)
        {
            InitializeComponent();

            isEditMode = true;

            label3.Text = "Редагувати предмет";
            textBox1.Text = selectedName;
            comboBox1.Text = selectedControlType;
            checkBox1.Checked = selectedMandatory;
            numericUpDown1.Value = Convert.ToDecimal(selectedHours);
            button1.Text = "Редагувати";

            subjectId = selectedId;
            subjectName = selectedName;
            subjectMandatory = selectedMandatory;
            subjectControlType = selectedControlType;
            subjectHours = selectedHours;

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            subjectServices = new SubjectServices(connection);
        }

        private bool ValidateManageSubjectForm()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Будь ласка, введіть назву предмета.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Будь ласка, введіть тип контролю.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBox1.Text != "Залік" && comboBox1.Text != "Екзамен" && comboBox1.Text != "Курсова робота")
            {
                MessageBox.Show("Будь ласка, оберіть коректний тип контролю.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Будь ласка, введіть кількість годин, більшу за 0.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (isEditMode == true)
            {
                if (textBox1.Text == subjectName && comboBox1.Text == subjectControlType && numericUpDown1.Value == subjectHours && checkBox1.Checked == subjectMandatory)
                {
                    MessageBox.Show("Ви не змінили жодного з полів. Зміни не потрібні.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateManageSubjectForm())
            {
                string name = textBox1.Text;
                string control_type = comboBox1.Text;
                bool mandatory = checkBox1.Checked;
                int hours = (int)numericUpDown1.Value;

                try
                {
                    if (isEditMode == true)
                    {
                        subjectServices.EditSubject(subjectId, name, control_type, mandatory, hours);
                    }
                    else
                    {
                        subjectServices.AddSubject(name, control_type, mandatory, hours);
                    }
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при додаванні предмету: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
