using System.Threading;
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
        private Thread openFormThread;

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

        private void OpenViewForm(object viewForm)
        {
            if (viewForm is Form form)
            {
                Application.Run(form);
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

                Form viewForm = null;
                if (role == "admin")
                {
                    viewForm = new AdminForm();
                }
                else if (role == "teacher")
                {
                    viewForm = new TeacherForm();
                }
                else if (role == "student")
                {
                    viewForm = new StudentForm();
                }

                if (viewForm != null)
                {
                    this.Close();
                    openFormThread = new Thread(() => OpenViewForm(viewForm));
                    openFormThread.SetApartmentState(ApartmentState.STA);
                    openFormThread.Start();
                }
            }
            else
            {
                MessageBox.Show("Неправильно введене ім'я або пароль");
            }
        }

    }
}
