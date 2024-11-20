namespace TheUniversity.Forms.Action.Subject
{
    partial class ManageLessonForm
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
            label7 = new Label();
            textBox2 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            comboBox3 = new ComboBox();
            textBox1 = new TextBox();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            button2 = new Button();
            button1 = new Button();
            label8 = new Label();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(215, 210);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 55;
            label7.Text = "Група";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(215, 227);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 54;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(70, 235);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 53;
            label6.Text = "Предмет";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(73, 191);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 52;
            label5.Text = "Викладач";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(76, 17);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 51;
            label4.Text = "Дата";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 70);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 50;
            label3.Text = "Час";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(194, 144);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 49;
            label2.Text = "Тип заняття";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 114);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 48;
            label1.Text = "Аудиторія";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Лекція", "Практика", "Лабораторна робота", "Семінар", "Консультації", "Індивідуальне заняття" });
            comboBox3.Location = new Point(194, 162);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 47;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(73, 131);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 46;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.Location = new Point(76, 88);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 45;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(76, 35);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 44;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(73, 251);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 43;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(73, 209);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 42;
            // 
            // button2
            // 
            button2.Location = new Point(83, 321);
            button2.Name = "button2";
            button2.Size = new Size(86, 23);
            button2.TabIndex = 41;
            button2.Text = "Відмінити";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(180, 321);
            button1.Name = "button1";
            button1.Size = new Size(86, 23);
            button1.TabIndex = 40;
            button1.Text = "Редагувати";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(304, 65);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 56;
            label8.Text = "label8";
            // 
            // ManageLessonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox3);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "ManageLessonForm";
            Text = "ManageLessonForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private TextBox textBox2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBox3;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button button2;
        private Button button1;
        private Label label8;
    }
}