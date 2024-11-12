using System.Data.SqlClient;
using TheUniversity.Services;
using TheUniversity.Configs;
using TheUniversity.Forms;

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            string role;
            if (authService.AuthenticateUser(username, password, out role))
            {
                Form viewForm = null;
                if (role == "admin")
                {
                    viewForm = new AdminViewForm();
                }
                else if (role == "teacher")
                {
                    viewForm = new TeacherViewForm();
                }
                else if (role == "student")
                {
                    viewForm = new StudentViewForm();
                }

                if (viewForm != null)
                {
                    viewForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Неправильно введене ім'я або пароль");
            }
        }
    }
}
