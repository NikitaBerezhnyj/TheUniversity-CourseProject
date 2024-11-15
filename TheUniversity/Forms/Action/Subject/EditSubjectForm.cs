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
    public partial class EditSubjectForm : Form
    {
        private SqlConnection connection;
        private SubjectServices subjectServices;

        int userId;

        public EditSubjectForm(int selectedId, string selectedName, string selectedControlType, bool selectedMandatory, int selectedHours)
        {
            InitializeComponent();

            textBox1.Text = selectedName;
            textBox2.Text = selectedControlType;
            checkBox1.Checked = selectedMandatory;
            numericUpDown1.Value = Convert.ToDecimal(selectedHours);

            userId = selectedId;

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            subjectServices = new SubjectServices(connection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string control_type = textBox2.Text;
            bool mandatory = checkBox1.Checked;
            int hours = (int)numericUpDown1.Value;

            try
            {
                subjectServices.EditSubject(userId, name, control_type, mandatory, hours);
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
