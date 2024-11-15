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

namespace TheUniversity.Forms.Action.Teacher
{
    public partial class AddTeacherForm : Form
    {
        private SqlConnection connection;
        private TeacherServices teacherServices;

        public AddTeacherForm()
        {
            InitializeComponent();

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            teacherServices = new TeacherServices(connection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string full_name = textBox1.Text;
            string position = comboBox1.Text;
            string department = comboBox2.Text;
            string academic_degree = comboBox2.Text;

            try
            {
                teacherServices.AddTeacher(full_name, position, department, academic_degree);
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
