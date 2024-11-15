namespace TheUniversity.Forms.Action.Subject
{
    partial class EditSubjectForm
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
            checkBox1 = new CheckBox();
            label4 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(51, 216);
            button2.Name = "button2";
            button2.Size = new Size(86, 23);
            button2.TabIndex = 34;
            button2.Text = "Відмінити";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(148, 216);
            button1.Name = "button1";
            button1.Size = new Size(86, 23);
            button1.TabIndex = 29;
            button1.Text = "Редагувати";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(49, 173);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(108, 19);
            checkBox1.TabIndex = 55;
            checkBox1.Text = "Обов'язковість";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 126);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 53;
            label4.Text = "Кількість годин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 82);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 52;
            label2.Text = "Тип контролю";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(49, 100);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(181, 23);
            textBox2.TabIndex = 51;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 38);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 50;
            label1.Text = "Назва предмету";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(51, 56);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 23);
            textBox1.TabIndex = 49;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(49, 144);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(181, 23);
            numericUpDown1.TabIndex = 56;
            // 
            // EditSubjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(numericUpDown1);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "EditSubjectForm";
            Text = "EditSubjectForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Button button1;
        private CheckBox checkBox1;
        private Label label4;
        private Label label2;
        private TextBox textBox2;
        private Label label1;
        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
    }
}