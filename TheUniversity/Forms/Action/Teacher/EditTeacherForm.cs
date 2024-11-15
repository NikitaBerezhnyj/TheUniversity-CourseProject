using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TheUniversity.Services;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using TheUniversity.Configs;

namespace TheUniversity.Forms.Action.Teacher
{
    public partial class EditTeacherForm : Form
    {
        private SqlConnection connection;
        private TeacherServices teacherServices;

        private int userId;

        public EditTeacherForm(int id, string full_name, string position, string department, string academic_degree)
        {
            InitializeComponent();

            userId = id;

            textBox1.Text = full_name;
            comboBox1.Text = position;
            comboBox2.Text = department;
            comboBox3.Text = academic_degree;

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            teacherServices = new TeacherServices(connection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string full_name = textBox1.Text;
            string position = comboBox1.Text;
            string department = comboBox2.Text;
            string academic_degree = comboBox3.Text;

            try
            {
                teacherServices.EditTeacher(userId, full_name, position, department, academic_degree);
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
