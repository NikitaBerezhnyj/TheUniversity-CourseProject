using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheUniversity.Forms.View
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();

            label2.AutoSize = false;
            label2.AutoEllipsis = false;
            label2.TextAlign = ContentAlignment.TopLeft;
            label2.Size = new Size(410, 333);
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            label2.Text = "The University – система для керування навчальним процесом.\r\n\r\n" +
                          "Основні можливості::\r\n\n" +
                          "- Користувачі: Вхід, вихід, розмежування ролей (гість, студент, викладач, адміністратор).\r\n" +
                          "- Перегляд: Розклади пар, викладачі, предмети.\r\n" +
                          "- Редагування (викладач/адміністратор): Додавання, змінення, видалення даних.\r\n" +
                          "- Експорт: Усі таблиці можна зберегти у форматі PDF.\r\n\r\n" +
                          "Система забезпечує просте та зручне керування навчальними даними.";
        }
    }
}
