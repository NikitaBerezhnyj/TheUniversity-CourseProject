namespace TheUniversity.Forms.Action.User
{
    partial class ManageUserForm
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
            label3 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 146);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 29;
            label3.Text = "Роль в системі";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 102);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 28;
            label2.Text = "Пароль";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 120);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(410, 23);
            textBox2.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 58);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 26;
            label1.Text = "Ім'я користувача";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Студент", "Викладач", "Адміністратор" });
            comboBox1.Location = new Point(12, 164);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(410, 23);
            comboBox1.TabIndex = 25;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 76);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(410, 23);
            textBox1.TabIndex = 24;
            // 
            // button2
            // 
            button2.Location = new Point(12, 193);
            button2.Name = "button2";
            button2.Size = new Size(208, 23);
            button2.TabIndex = 23;
            button2.Text = "Відмінити";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(226, 193);
            button1.Name = "button1";
            button1.Size = new Size(196, 23);
            button1.TabIndex = 22;
            button1.Text = "Додати";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 9);
            label4.Name = "label4";
            label4.Size = new Size(363, 40);
            label4.TabIndex = 30;
            label4.Text = "Додавання користувача";
            // 
            // ManageUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 411);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "ManageUserForm";
            Text = "ManageUserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private TextBox textBox2;
        private Label label1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Button button2;
        private Button button1;
        private Label label4;
    }
}