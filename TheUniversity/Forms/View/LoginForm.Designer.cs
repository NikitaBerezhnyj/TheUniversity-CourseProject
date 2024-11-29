
namespace TheUniversity
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            linkLabel1 = new LinkLabel();
            button2 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(276, 162);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(265, 23);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(276, 144);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 1;
            label1.Text = "Ім'я користувача";
            // 
            // button1
            // 
            button1.Location = new Point(276, 286);
            button1.Name = "button1";
            button1.Size = new Size(265, 23);
            button1.TabIndex = 2;
            button1.Text = "Ввійти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(276, 203);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 4;
            label2.Text = "Пароль";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(276, 221);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(265, 23);
            textBox2.TabIndex = 3;
            textBox2.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(243, 39);
            label3.Name = "label3";
            label3.Size = new Size(340, 65);
            label3.TabIndex = 5;
            label3.Text = "TheUniversity";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(366, 322);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(85, 15);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Ввійти як гість";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // button2
            // 
            button2.Location = new Point(510, 221);
            button2.Name = "button2";
            button2.Size = new Size(31, 23);
            button2.TabIndex = 6;
            button2.Text = "O";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "The University [Login]";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private LinkLabel linkLabel1;
        private Button button2;
    }
}
