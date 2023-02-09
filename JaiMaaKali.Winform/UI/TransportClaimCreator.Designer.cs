namespace JaiMaaKali.WinForm
{
    partial class TransportClaimControl
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
            this.DataFileLabel = new System.Windows.Forms.Label();
            this.DataFileInput = new System.Windows.Forms.TextBox();
            this.FormatFileInput = new System.Windows.Forms.TextBox();
            this.FormatFileLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OutputPathInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.MonthComboBox = new System.Windows.Forms.ComboBox();
            this.YearComboBox = new System.Windows.Forms.ComboBox();
            this.RateLabel = new System.Windows.Forms.Label();
            this.RateInputBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DataFileLabel
            // 
            this.DataFileLabel.AutoSize = true;
            this.DataFileLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataFileLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.DataFileLabel.Location = new System.Drawing.Point(20, 39);
            this.DataFileLabel.Name = "DataFileLabel";
            this.DataFileLabel.Size = new System.Drawing.Size(84, 22);
            this.DataFileLabel.TabIndex = 1;
            this.DataFileLabel.Text = "Data File";
            // 
            // DataFileInput
            // 
            this.DataFileInput.BackColor = System.Drawing.Color.White;
            this.DataFileInput.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataFileInput.Location = new System.Drawing.Point(110, 32);
            this.DataFileInput.Name = "DataFileInput";
            this.DataFileInput.Size = new System.Drawing.Size(762, 30);
            this.DataFileInput.TabIndex = 2;
            this.DataFileInput.TextChanged += new System.EventHandler(this.AllTextFilled);
            this.DataFileInput.DoubleClick += new System.EventHandler(this.DataFileInput_OpenExplorer);
            // 
            // FormatFileInput
            // 
            this.FormatFileInput.BackColor = System.Drawing.Color.White;
            this.FormatFileInput.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormatFileInput.Location = new System.Drawing.Point(127, 124);
            this.FormatFileInput.Name = "FormatFileInput";
            this.FormatFileInput.Size = new System.Drawing.Size(745, 30);
            this.FormatFileInput.TabIndex = 4;
            this.FormatFileInput.TextChanged += new System.EventHandler(this.AllTextFilled);
            this.FormatFileInput.DoubleClick += new System.EventHandler(this.FormatFileInput_OpenExplorer);
            // 
            // FormatFileLabel
            // 
            this.FormatFileLabel.AutoSize = true;
            this.FormatFileLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormatFileLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.FormatFileLabel.Location = new System.Drawing.Point(18, 127);
            this.FormatFileLabel.Name = "FormatFileLabel";
            this.FormatFileLabel.Size = new System.Drawing.Size(103, 22);
            this.FormatFileLabel.TabIndex = 3;
            this.FormatFileLabel.Text = "Format File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.RosyBrown;
            this.label1.Location = new System.Drawing.Point(50, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.RosyBrown;
            this.label2.Location = new System.Drawing.Point(246, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Month";
            // 
            // OutputPathInput
            // 
            this.OutputPathInput.BackColor = System.Drawing.Color.White;
            this.OutputPathInput.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutputPathInput.Location = new System.Drawing.Point(127, 172);
            this.OutputPathInput.Name = "OutputPathInput";
            this.OutputPathInput.Size = new System.Drawing.Size(745, 30);
            this.OutputPathInput.TabIndex = 10;
            this.OutputPathInput.TextChanged += new System.EventHandler(this.AllTextFilled);
            this.OutputPathInput.DoubleClick += new System.EventHandler(this.OutputPath_OpenExplorer);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.RosyBrown;
            this.label3.Location = new System.Drawing.Point(19, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "Output Path";
            // 
            // GenerateButton
            // 
            this.GenerateButton.BackColor = System.Drawing.Color.DarkGray;
            this.GenerateButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GenerateButton.Location = new System.Drawing.Point(138, 299);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(154, 52);
            this.GenerateButton.TabIndex = 11;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = false;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = System.Drawing.Color.Red;
            this.ResetButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ResetButton.Location = new System.Drawing.Point(660, 299);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(154, 52);
            this.ResetButton.TabIndex = 12;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // MonthComboBox
            // 
            this.MonthComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MonthComboBox.FormattingEnabled = true;
            this.MonthComboBox.Location = new System.Drawing.Point(319, 78);
            this.MonthComboBox.Name = "MonthComboBox";
            this.MonthComboBox.Size = new System.Drawing.Size(117, 30);
            this.MonthComboBox.TabIndex = 13;
            this.MonthComboBox.TextChanged += new System.EventHandler(this.AllTextFilled);
            // 
            // YearComboBox
            // 
            this.YearComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Location = new System.Drawing.Point(109, 78);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(117, 30);
            this.YearComboBox.TabIndex = 14;
            this.YearComboBox.TextChanged += new System.EventHandler(this.AllTextFilled);
            // 
            // RateLabel
            // 
            this.RateLabel.AutoSize = true;
            this.RateLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RateLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.RateLabel.Location = new System.Drawing.Point(698, 81);
            this.RateLabel.Name = "RateLabel";
            this.RateLabel.Size = new System.Drawing.Size(46, 22);
            this.RateLabel.TabIndex = 15;
            this.RateLabel.Text = "Rate";
            // 
            // RateInputBox
            // 
            this.RateInputBox.BackColor = System.Drawing.Color.White;
            this.RateInputBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RateInputBox.Location = new System.Drawing.Point(759, 78);
            this.RateInputBox.Name = "RateInputBox";
            this.RateInputBox.Size = new System.Drawing.Size(113, 30);
            this.RateInputBox.TabIndex = 16;
            this.RateInputBox.TextChanged += new System.EventHandler(this.AllTextFilled);
            // 
            // TransportClaimControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.Controls.Add(this.RateInputBox);
            this.Controls.Add(this.RateLabel);
            this.Controls.Add(this.YearComboBox);
            this.Controls.Add(this.MonthComboBox);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.OutputPathInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FormatFileInput);
            this.Controls.Add(this.FormatFileLabel);
            this.Controls.Add(this.DataFileInput);
            this.Controls.Add(this.DataFileLabel);
            this.Name = "TransportClaimControl";
            this.Size = new System.Drawing.Size(913, 408);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label DataFileLabel;
        private TextBox DataFileInput;
        private TextBox FormatFileInput;
        private Label FormatFileLabel;
        private Label label1;
        private Label label2;
        private TextBox OutputPathInput;
        private Label label3;
        private Button GenerateButton;
        private Button ResetButton;
        private ComboBox MonthComboBox;
        private ComboBox YearComboBox;
        private Label RateLabel;
        private TextBox RateInputBox;
    }
}