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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TheUniversity.Forms.Action.Subject
{
    public partial class EditSubjectForm : Form
    {
        private SqlConnection connection;
        private SubjectServices subjectServices;

        private int subjectId;
        private string subjectName;
        private string subjectControlType;
        private bool subjectMandatory;
        private int subjectHours;

        public EditSubjectForm(int selectedId, string selectedName, string selectedControlType, bool selectedMandatory, int selectedHours)
        {
            InitializeComponent();

            textBox1.Text = selectedName;
            comboBox1.Text = selectedControlType;
            checkBox1.Checked = selectedMandatory;
            numericUpDown1.Value = Convert.ToDecimal(selectedHours);

            subjectId = selectedId;
            subjectName = selectedName;
            subjectMandatory = selectedMandatory;
            subjectControlType = selectedControlType;
            subjectHours = selectedHours;

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            subjectServices = new SubjectServices(connection);
        }

        private bool ValidateEditSubjectForm()
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

            if (textBox1.Text == subjectName && comboBox1.Text == subjectControlType && numericUpDown1.Value == subjectHours && checkBox1.Checked == subjectMandatory)
            {
                MessageBox.Show("Ви не змінили жодного з полів. Зміни не потрібні.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ValidateEditSubjectForm())
            {
                string name = textBox1.Text;
                string control_type = comboBox1.Text;
                bool mandatory = checkBox1.Checked;
                int hours = (int)numericUpDown1.Value;

                try
                {
                    subjectServices.EditSubject(subjectId, name, control_type, mandatory, hours);
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
