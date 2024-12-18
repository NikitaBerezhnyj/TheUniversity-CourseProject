using System.Threading;
using System.Data.SqlClient;
using TheUniversity.Services;
using TheUniversity.Configs;
using TheUniversity.Forms;
using TheUniversity.Forms.View;
using System.Data;

namespace TheUniversity
{
    public partial class LoginForm : Form
    {
        private AuthServices authService;
        private UserServices userServices;
        private SqlConnection connection;

        public LoginForm()
        {
            InitializeComponent();

            var dbConfig = new DatabaseConfig();
            connection = dbConfig.OpenConnection();
            authService = new AuthServices(connection);
            userServices = new UserServices(connection);

            textBox1.Text = Properties.Settings.Default.Username;
            textBox2.Text = Properties.Settings.Default.Password;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar)
            {
                textBox2.UseSystemPasswordChar = false;
                button2.Text = "X";
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                button2.Text = "O";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            string role;
            if (authService.AuthenticateUser(username, password, out role))
            {
                Properties.Settings.Default.Username = username;
                Properties.Settings.Default.Password = password;
                Properties.Settings.Default.Save();

                this.Hide();
                MainForm mainForm = new MainForm(role);
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("����������� ������� ��'� ��� ������");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm("guest");
            mainForm.ShowDialog();
            this.Close();
        }
    }
}
