namespace TheUniversity.Forms.Action.Subject
{
    partial class ManageSubjectForm
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
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            checkBox1 = new CheckBox();
            label4 = new Label();
            button2 = new Button();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Екзамен", "Залік", "Курсова робота" });
            comboBox1.Location = new Point(103, 151);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(181, 23);
            comboBox1.TabIndex = 59;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(101, 195);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(181, 23);
            numericUpDown1.TabIndex = 58;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(101, 224);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(108, 19);
            checkBox1.TabIndex = 57;
            checkBox1.Text = "Обов'язковість";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(101, 177);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 56;
            label4.Text = "Кількість годин";
            // 
            // button2
            // 
            button2.Location = new Point(101, 249);
            button2.Name = "button2";
            button2.Size = new Size(86, 23);
            button2.TabIndex = 55;
            button2.Text = "Відмінити";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(101, 133);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 54;
            label2.Text = "Тип контролю";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 89);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 53;
            label1.Text = "Назва предмету";
            // 
            // button1
            // 
            button1.Location = new Point(198, 249);
            button1.Name = "button1";
            button1.Size = new Size(86, 23);
            button1.TabIndex = 52;
            button1.Text = "Додати";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(103, 107);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 23);
            textBox1.TabIndex = 51;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(147, 31);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 60;
            label3.Text = "label3";
            // 
            // ManageSubjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "ManageSubjectForm";
            Text = "ManageSubjectForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private CheckBox checkBox1;
        private Label label4;
        private Button button2;
        private Label label2;
        private Label label1;
        private Button button1;
        private TextBox textBox1;
        private Label label3;
    }
}