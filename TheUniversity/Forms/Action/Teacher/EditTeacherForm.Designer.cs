namespace TheUniversity.Forms.Action.Teacher
{
    partial class EditTeacherForm
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
            button2 = new Button();
            button1 = new Button();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(50, 213);
            button2.Name = "button2";
            button2.Size = new Size(86, 23);
            button2.TabIndex = 23;
            button2.Text = "Відмінити";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(147, 213);
            button1.Name = "button1";
            button1.Size = new Size(86, 23);
            button1.TabIndex = 17;
            button1.Text = "Редагувати";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Магістр", "Кандидат наук", "Доктор філософії", "Доктор наук", "", "", "Почесний доктор" });
            comboBox3.Location = new Point(48, 176);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(183, 23);
            comboBox3.TabIndex = 46;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Інформатики та програмування", "", "Математики", "Фізики", "Права", "Іноземних мов", "", "Історії", "Хімії", "Біології", "Менеджменту та маркетингу" });
            comboBox2.Location = new Point(48, 132);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(183, 23);
            comboBox2.TabIndex = 45;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Аспірант", "Асистент", "Доцент", "Старший викладач", "Професор", "Науковий співробітник", "", "Завідувач кафедри", "", "", "Декан факультету", "", "", "Проректор", "Ректор" });
            comboBox1.Location = new Point(48, 88);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(183, 23);
            comboBox1.TabIndex = 44;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 158);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 43;
            label4.Text = "Вчений ступінь";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 114);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 42;
            label3.Text = "Кафедра";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 70);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 41;
            label2.Text = "Посада";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 26);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 40;
            label1.Text = "Ім'я";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(50, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 23);
            textBox1.TabIndex = 39;
            // 
            // EditTeacherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "EditTeacherForm";
            Text = "EditTeacherForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
    }
}