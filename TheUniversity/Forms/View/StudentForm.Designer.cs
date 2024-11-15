namespace TheUniversity.Forms
{
    partial class StudentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            button1 = new Button();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            tabPage2 = new TabPage();
            button3 = new Button();
            dataGridView2 = new DataGridView();
            label3 = new Label();
            button4 = new Button();
            comboBox2 = new ComboBox();
            textBox2 = new TextBox();
            tabPage3 = new TabPage();
            button5 = new Button();
            dataGridView3 = new DataGridView();
            label4 = new Label();
            button6 = new Button();
            comboBox3 = new ComboBox();
            textBox3 = new TextBox();
            menuStrip1 = new MenuStrip();
            діїToolStripMenuItem = new ToolStripMenuItem();
            користувачіToolStripMenuItem = new ToolStripMenuItem();
            додатиToolStripMenuItem = new ToolStripMenuItem();
            редагуватиToolStripMenuItem = new ToolStripMenuItem();
            видалитиToolStripMenuItem = new ToolStripMenuItem();
            париToolStripMenuItem = new ToolStripMenuItem();
            додатиToolStripMenuItem1 = new ToolStripMenuItem();
            редагуватиToolStripMenuItem1 = new ToolStripMenuItem();
            видалитиToolStripMenuItem1 = new ToolStripMenuItem();
            предметиToolStripMenuItem = new ToolStripMenuItem();
            додатиToolStripMenuItem2 = new ToolStripMenuItem();
            редагуватиToolStripMenuItem2 = new ToolStripMenuItem();
            видалитиToolStripMenuItem2 = new ToolStripMenuItem();
            викладачіToolStripMenuItem = new ToolStripMenuItem();
            додатиToolStripMenuItem3 = new ToolStripMenuItem();
            редагуватиToolStripMenuItem3 = new ToolStripMenuItem();
            видалитиВикладачаToolStripMenuItem = new ToolStripMenuItem();
            вихідToolStripMenuItem = new ToolStripMenuItem();
            закритиToolStripMenuItem = new ToolStripMenuItem();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(0, 30);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 408);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 380);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Пари";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(711, 5);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Скинути";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 35);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(792, 345);
            dataGridView1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 9);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 3;
            label2.Text = "Пошук по";
            // 
            // button1
            // 
            button1.Location = new Point(316, 6);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Пошук";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "групі", "аудиторії", "даті", "часу", "виду заняття" });
            comboBox1.Location = new Point(69, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(196, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(114, 23);
            textBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(comboBox2);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 380);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Предмети";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(711, 3);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 11;
            button3.Text = "Скинути";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(0, 33);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(792, 345);
            dataGridView2.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 7);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 9;
            label3.Text = "Пошук по";
            // 
            // button4
            // 
            button4.Location = new Point(316, 4);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 8;
            button4.Text = "Пошук";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "назві", "типу контролю", "обов'язковості", "кількості годин" });
            comboBox2.Location = new Point(69, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(196, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(114, 23);
            textBox2.TabIndex = 6;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button5);
            tabPage3.Controls.Add(dataGridView3);
            tabPage3.Controls.Add(label4);
            tabPage3.Controls.Add(button6);
            tabPage3.Controls.Add(comboBox3);
            tabPage3.Controls.Add(textBox3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(792, 380);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Викладачі";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(711, 3);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 17;
            button5.Text = "Скинути";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // dataGridView3
            // 
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(0, 33);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(792, 345);
            dataGridView3.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(0, 7);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 15;
            label4.Text = "Пошук по";
            // 
            // button6
            // 
            button6.Location = new Point(316, 4);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 14;
            button6.Text = "Пошук";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "піп", "посаді", "кафедрі", "вченому ступеню" });
            comboBox3.Location = new Point(69, 4);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 13;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(196, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(114, 23);
            textBox3.TabIndex = 12;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlLight;
            menuStrip1.Items.AddRange(new ToolStripItem[] { діїToolStripMenuItem, вихідToolStripMenuItem, закритиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // діїToolStripMenuItem
            // 
            діїToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { користувачіToolStripMenuItem, париToolStripMenuItem, предметиToolStripMenuItem, викладачіToolStripMenuItem });
            діїToolStripMenuItem.Name = "діїToolStripMenuItem";
            діїToolStripMenuItem.Size = new Size(33, 20);
            діїToolStripMenuItem.Text = "Дії";
            // 
            // користувачіToolStripMenuItem
            // 
            користувачіToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { додатиToolStripMenuItem, редагуватиToolStripMenuItem, видалитиToolStripMenuItem });
            користувачіToolStripMenuItem.Enabled = false;
            користувачіToolStripMenuItem.Name = "користувачіToolStripMenuItem";
            користувачіToolStripMenuItem.Size = new Size(141, 22);
            користувачіToolStripMenuItem.Text = "Користувачі";
            // 
            // додатиToolStripMenuItem
            // 
            додатиToolStripMenuItem.Name = "додатиToolStripMenuItem";
            додатиToolStripMenuItem.Size = new Size(206, 22);
            додатиToolStripMenuItem.Text = "Додати користувача";
            // 
            // редагуватиToolStripMenuItem
            // 
            редагуватиToolStripMenuItem.Name = "редагуватиToolStripMenuItem";
            редагуватиToolStripMenuItem.Size = new Size(206, 22);
            редагуватиToolStripMenuItem.Text = "Редагувати користувача";
            // 
            // видалитиToolStripMenuItem
            // 
            видалитиToolStripMenuItem.Name = "видалитиToolStripMenuItem";
            видалитиToolStripMenuItem.Size = new Size(206, 22);
            видалитиToolStripMenuItem.Text = "Видалити користувача";
            // 
            // париToolStripMenuItem
            // 
            париToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { додатиToolStripMenuItem1, редагуватиToolStripMenuItem1, видалитиToolStripMenuItem1 });
            париToolStripMenuItem.Enabled = false;
            париToolStripMenuItem.Name = "париToolStripMenuItem";
            париToolStripMenuItem.Size = new Size(141, 22);
            париToolStripMenuItem.Text = "Пари";
            // 
            // додатиToolStripMenuItem1
            // 
            додатиToolStripMenuItem1.Name = "додатиToolStripMenuItem1";
            додатиToolStripMenuItem1.Size = new Size(163, 22);
            додатиToolStripMenuItem1.Text = "Додати пару";
            // 
            // редагуватиToolStripMenuItem1
            // 
            редагуватиToolStripMenuItem1.Name = "редагуватиToolStripMenuItem1";
            редагуватиToolStripMenuItem1.Size = new Size(163, 22);
            редагуватиToolStripMenuItem1.Text = "Редагувати пару";
            // 
            // видалитиToolStripMenuItem1
            // 
            видалитиToolStripMenuItem1.Name = "видалитиToolStripMenuItem1";
            видалитиToolStripMenuItem1.Size = new Size(163, 22);
            видалитиToolStripMenuItem1.Text = "Видалити пару";
            // 
            // предметиToolStripMenuItem
            // 
            предметиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { додатиToolStripMenuItem2, редагуватиToolStripMenuItem2, видалитиToolStripMenuItem2 });
            предметиToolStripMenuItem.Enabled = false;
            предметиToolStripMenuItem.Name = "предметиToolStripMenuItem";
            предметиToolStripMenuItem.Size = new Size(141, 22);
            предметиToolStripMenuItem.Text = "Предмети";
            // 
            // додатиToolStripMenuItem2
            // 
            додатиToolStripMenuItem2.Name = "додатиToolStripMenuItem2";
            додатиToolStripMenuItem2.Size = new Size(183, 22);
            додатиToolStripMenuItem2.Text = "Додати предмет";
            // 
            // редагуватиToolStripMenuItem2
            // 
            редагуватиToolStripMenuItem2.Name = "редагуватиToolStripMenuItem2";
            редагуватиToolStripMenuItem2.Size = new Size(183, 22);
            редагуватиToolStripMenuItem2.Text = "Редагувати предмет";
            // 
            // видалитиToolStripMenuItem2
            // 
            видалитиToolStripMenuItem2.Name = "видалитиToolStripMenuItem2";
            видалитиToolStripMenuItem2.Size = new Size(183, 22);
            видалитиToolStripMenuItem2.Text = "Видалити предмет";
            // 
            // викладачіToolStripMenuItem
            // 
            викладачіToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { додатиToolStripMenuItem3, редагуватиToolStripMenuItem3, видалитиВикладачаToolStripMenuItem });
            викладачіToolStripMenuItem.Enabled = false;
            викладачіToolStripMenuItem.Name = "викладачіToolStripMenuItem";
            викладачіToolStripMenuItem.Size = new Size(141, 22);
            викладачіToolStripMenuItem.Text = "Викладачі";
            // 
            // додатиToolStripMenuItem3
            // 
            додатиToolStripMenuItem3.Name = "додатиToolStripMenuItem3";
            додатиToolStripMenuItem3.Size = new Size(194, 22);
            додатиToolStripMenuItem3.Text = "Додати викладача";
            // 
            // редагуватиToolStripMenuItem3
            // 
            редагуватиToolStripMenuItem3.Name = "редагуватиToolStripMenuItem3";
            редагуватиToolStripMenuItem3.Size = new Size(194, 22);
            редагуватиToolStripMenuItem3.Text = "Редагувати викладача";
            // 
            // видалитиВикладачаToolStripMenuItem
            // 
            видалитиВикладачаToolStripMenuItem.Name = "видалитиВикладачаToolStripMenuItem";
            видалитиВикладачаToolStripMenuItem.Size = new Size(194, 22);
            видалитиВикладачаToolStripMenuItem.Text = "Видалити викладача";
            // 
            // вихідToolStripMenuItem
            // 
            вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            вихідToolStripMenuItem.Size = new Size(48, 20);
            вихідToolStripMenuItem.Text = "Вихід";
            вихідToolStripMenuItem.Click += вихідToolStripMenuItem_Click;
            // 
            // закритиToolStripMenuItem
            // 
            закритиToolStripMenuItem.Name = "закритиToolStripMenuItem";
            закритиToolStripMenuItem.Size = new Size(64, 20);
            закритиToolStripMenuItem.Text = "Закрити";
            закритиToolStripMenuItem.Click += закритиToolStripMenuItem_Click;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "StudentForm";
            Text = "StudentViewForm";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label2;
        private Button button1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView2;
        private Label label3;
        private Button button4;
        private ComboBox comboBox2;
        private TextBox textBox2;
        private Button button5;
        private DataGridView dataGridView3;
        private Label label4;
        private Button button6;
        private ComboBox comboBox3;
        private TextBox textBox3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem діїToolStripMenuItem;
        private ToolStripMenuItem вихідToolStripMenuItem;
        private ToolStripMenuItem закритиToolStripMenuItem;
        private ToolStripMenuItem користувачіToolStripMenuItem;
        private ToolStripMenuItem додатиToolStripMenuItem;
        private ToolStripMenuItem редагуватиToolStripMenuItem;
        private ToolStripMenuItem видалитиToolStripMenuItem;
        private ToolStripMenuItem париToolStripMenuItem;
        private ToolStripMenuItem додатиToolStripMenuItem1;
        private ToolStripMenuItem редагуватиToolStripMenuItem1;
        private ToolStripMenuItem видалитиToolStripMenuItem1;
        private ToolStripMenuItem предметиToolStripMenuItem;
        private ToolStripMenuItem додатиToolStripMenuItem2;
        private ToolStripMenuItem редагуватиToolStripMenuItem2;
        private ToolStripMenuItem видалитиToolStripMenuItem2;
        private ToolStripMenuItem викладачіToolStripMenuItem;
        private ToolStripMenuItem додатиToolStripMenuItem3;
        private ToolStripMenuItem редагуватиToolStripMenuItem3;
        private ToolStripMenuItem видалитиВикладачаToolStripMenuItem;
    }
}