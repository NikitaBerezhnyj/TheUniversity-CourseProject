using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheUniversity.Forms
{
    public partial class TeacherForm : Form
    {
        private Thread openFormThread;

        public TeacherForm()
        {
            InitializeComponent();
        }

        private void BackToLoginForm(object form)
        {
            Application.Run(new LoginForm());
        }

        // Верхня панель
        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();
            this.Close();
            openFormThread = new Thread(BackToLoginForm);
            openFormThread.SetApartmentState(ApartmentState.STA);
            openFormThread.Start();
        }

        private void закритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
