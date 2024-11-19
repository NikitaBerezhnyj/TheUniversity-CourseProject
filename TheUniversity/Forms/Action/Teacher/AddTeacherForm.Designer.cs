namespace TheUniversity.Forms.Action.Teacher
{
    partial class AddTeacherForm
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
            label4 = new Label();
            button2 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(95, 200);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 35;
            label4.Text = "Вчений ступінь";
            // 
            // button2
            // 
            button2.Location = new Point(95, 262);
            button2.Name = "button2";
            button2.Size = new Size(86, 23);
            button2.TabIndex = 34;
            button2.Text = "Відмінити";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(95, 156);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 33;
            label3.Text = "Кафедра";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 112);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 32;
            label2.Text = "Посада";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 68);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 30;
            label1.Text = "Ім'я";
            // 
            // button1
            // 
            button1.Location = new Point(192, 262);
            button1.Name = "button1";
            button1.Size = new Size(86, 23);
            button1.TabIndex = 29;
            button1.Text = "Додати";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(97, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 23);
            textBox1.TabIndex = 28;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Аспірант", "Асистент", "Доцент", "Старший викладач", "Професор", "Науковий співробітник", "Завідувач кафедри", "Декан факультету", "Проректор", "Ректор" });
            comboBox1.Location = new Point(95, 130);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(183, 23);
            comboBox1.TabIndex = 36;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Інформатики та програмування", "Математики", "Фізики", "Права", "Іноземних мов", "Історії", "Хімії", "Біології", "Менеджменту та маркетингу" });
            comboBox2.Location = new Point(95, 174);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(183, 23);
            comboBox2.TabIndex = 37;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Магістр", "Кандидат наук", "Доктор філософії", "Доктор наук", "Почесний доктор" });
            comboBox3.Location = new Point(95, 218);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(183, 23);
            comboBox3.TabIndex = 38;
            // 
            // AddTeacherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "AddTeacherForm";
            Text = "AddTeacherForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private Button button2;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
    }
}