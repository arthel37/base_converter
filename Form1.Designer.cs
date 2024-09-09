namespace base_converter
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            numTextBox = new TextBox();
            baseFromTextBox = new TextBox();
            baseToTextBox = new TextBox();
            outputTextBox = new TextBox();
            label4 = new Label();
            btnConvert = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F);
            label1.Location = new Point(291, 99);
            label1.Name = "label1";
            label1.Size = new Size(77, 19);
            label1.TabIndex = 3;
            label1.Text = "From base:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F);
            label2.Location = new Point(701, 99);
            label2.Name = "label2";
            label2.Size = new Size(60, 19);
            label2.TabIndex = 4;
            label2.Text = "To base:";
            // 
            // numTextBox
            // 
            numTextBox.Font = new Font("Times New Roman", 20.25F);
            numTextBox.Location = new Point(280, 20);
            numTextBox.Name = "numTextBox";
            numTextBox.Size = new Size(500, 39);
            numTextBox.TabIndex = 5;
            numTextBox.Text = "Enter a number with \",\" as decimal separator";
            numTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // baseFromTextBox
            // 
            baseFromTextBox.Font = new Font("Times New Roman", 20.25F);
            baseFromTextBox.Location = new Point(280, 158);
            baseFromTextBox.Name = "baseFromTextBox";
            baseFromTextBox.Size = new Size(100, 39);
            baseFromTextBox.TabIndex = 6;
            baseFromTextBox.Text = "10";
            baseFromTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // baseToTextBox
            // 
            baseToTextBox.Font = new Font("Times New Roman", 20.25F);
            baseToTextBox.Location = new Point(680, 158);
            baseToTextBox.Name = "baseToTextBox";
            baseToTextBox.Size = new Size(100, 39);
            baseToTextBox.TabIndex = 7;
            baseToTextBox.Text = "2";
            baseToTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // outputTextBox
            // 
            outputTextBox.Font = new Font("Times New Roman", 20.25F);
            outputTextBox.Location = new Point(280, 296);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.Size = new Size(500, 39);
            outputTextBox.TabIndex = 8;
            outputTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F);
            label4.Location = new Point(500, 237);
            label4.Name = "label4";
            label4.Size = new Size(49, 19);
            label4.TabIndex = 10;
            label4.Text = "Result:";
            // 
            // btnConvert
            // 
            btnConvert.BackColor = Color.Gold;
            btnConvert.Font = new Font("Times New Roman", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnConvert.Location = new Point(455, 158);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(150, 39);
            btnConvert.TabIndex = 11;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Click += btnConvert_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(1064, 371);
            Controls.Add(btnConvert);
            Controls.Add(label4);
            Controls.Add(outputTextBox);
            Controls.Add(baseToTextBox);
            Controls.Add(baseFromTextBox);
            Controls.Add(numTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private TextBox numTextBox;
        private TextBox baseFromTextBox;
        private TextBox baseToTextBox;
        private TextBox outputTextBox;
        private Label label4;
        private Button btnConvert;
    }
}
