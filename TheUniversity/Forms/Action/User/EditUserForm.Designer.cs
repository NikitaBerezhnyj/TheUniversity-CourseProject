namespace TheUniversity.Forms.Action.User
{
    partial class EditUserForm
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
            label3 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(96, 254);
            button2.Name = "button2";
            button2.Size = new Size(86, 23);
            button2.TabIndex = 15;
            button2.Text = "Відмінити";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(188, 254);
            button1.Name = "button1";
            button1.Size = new Size(86, 23);
            button1.TabIndex = 9;
            button1.Text = "Редагувати";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(93, 207);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 21;
            label3.Text = "Роль в системі";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 155);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 20;
            label2.Text = "Пароль";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(93, 173);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(181, 23);
            textBox2.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 102);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 18;
            label1.Text = "Ім'я користувача";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Студент", "Викладач", "Адміністратор" });
            comboBox1.Location = new Point(93, 225);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(181, 23);
            comboBox1.TabIndex = 17;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(93, 120);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 23);
            textBox1.TabIndex = 16;
            // 
            // EditUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "EditUserForm";
            Text = "EditUserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private Label label3;
        private Label label2;
        private TextBox textBox2;
        private Label label1;
        private ComboBox comboBox1;
        private TextBox textBox1;
    }
}