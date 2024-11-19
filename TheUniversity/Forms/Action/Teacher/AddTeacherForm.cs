﻿using System;
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

        private bool ValidateAddTeacherForm()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Будь ласка, введіть повне ім'я викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Будь ласка, оберіть посаду викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox1.Text) || !new List<string> { "Аспірант", "Асистент", "Доцент", "Старший викладач", "Професор", "Науковий співробітник", "Завідувач кафедри", "Декан факультету", "Проректор", "Ректор" }.Contains(comboBox1.Text))
            {
                MessageBox.Show("Будь ласка, оберіть коректну посаду викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Будь ласка, оберіть кафедру викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox2.Text) || !new List<string> { "Інформатики та програмування", "Математики", "Фізики", "Права", "Іноземних мов", "Історії", "Хімії", "Біології", "Менеджменту та маркетингу" }.Contains(comboBox2.Text))
            {
                MessageBox.Show("Будь ласка, оберіть коректну кафедру викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(comboBox3.Text))
            {
                MessageBox.Show("Будь ласка, оберіть академічний ступінь викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(comboBox3.Text) || !new List<string> { "Магістр", "Кандидат наук", "Доктор філософії", "Доктор наук", "Почесний доктор" }.Contains(comboBox3.Text))
            {
                MessageBox.Show("Будь ласка, оберіть коректний академічний ступінь викладача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateAddTeacherForm())
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
