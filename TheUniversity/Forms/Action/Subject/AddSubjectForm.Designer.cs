namespace TheUniversity.Forms.Action.Subject
{
    partial class AddSubjectForm
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
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            checkBox1 = new CheckBox();
            numericUpDown1 = new NumericUpDown();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(92, 184);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 45;
            label4.Text = "Кількість годин";
            // 
            // button2
            // 
            button2.Location = new Point(92, 256);
            button2.Name = "button2";
            button2.Size = new Size(86, 23);
            button2.TabIndex = 44;
            button2.Text = "Відмінити";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 140);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 42;
            label2.Text = "Тип контролю";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 96);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 40;
            label1.Text = "Назва предмету";
            // 
            // button1
            // 
            button1.Location = new Point(189, 256);
            button1.Name = "button1";
            button1.Size = new Size(86, 23);
            button1.TabIndex = 39;
            button1.Text = "Додати";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(94, 114);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 23);
            textBox1.TabIndex = 38;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(92, 231);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(108, 19);
            checkBox1.TabIndex = 48;
            checkBox1.Text = "Обов'язковість";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(92, 202);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(181, 23);
            numericUpDown1.TabIndex = 49;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Екзамен", "Залік", "Курсова робота" });
            comboBox1.Location = new Point(94, 158);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(181, 23);
            comboBox1.TabIndex = 50;
            // 
            // AddSubjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(comboBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "AddSubjectForm";
            Text = "AddSubjectForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private Button button2;
        private Label label2;
        private Label label1;
        private Button button1;
        private TextBox textBox1;
        private CheckBox checkBox1;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox1;
    }
}