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

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string control_type = textBox2.Text;
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
