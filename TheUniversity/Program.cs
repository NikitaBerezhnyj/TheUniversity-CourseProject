using TheUniversity.Configs;

namespace TheUniversity
{
    internal static class Program
    {
        private static DatabaseConfig dbConfig = new DatabaseConfig();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.ApplicationExit += OnApplicationExit;
            Application.Run(new LoginForm());
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            dbConfig.CloseConnection();
        }
    }
}
