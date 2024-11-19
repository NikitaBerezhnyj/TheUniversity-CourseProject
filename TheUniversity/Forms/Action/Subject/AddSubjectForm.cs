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
    public partial class AddSubjectForm : Form
    {
        private SqlConnection connection;
        private SubjectServices subjectServices;

        public AddSubjectForm()
        {
            InitializeComponent();

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            subjectServices = new SubjectServices(connection);
        }

        private bool ValidateAddSubjectForm()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Будь ласка, введіть назву предмета.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Будь ласка, введіть тип контролю (екзамен/залік/тощо).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string control_type = comboBox1.Text;
            bool mandatory = checkBox1.Checked;
            int hours = (int)numericUpDown1.Value;

            try
            {
                subjectServices.AddSubject(name, control_type, mandatory, hours);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при додаванні викладача: " + ex.Message, "Помилка");
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
