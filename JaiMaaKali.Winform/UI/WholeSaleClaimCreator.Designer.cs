namespace JaiMaaKali.WinForm.UI
{
    partial class WholeSaleClaimCreator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ClaimDataFileInput = new System.Windows.Forms.TextBox();
            this.DataFileLabel = new System.Windows.Forms.Label();
            this.BillFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.ExpectedClaimAmountNumericField = new System.Windows.Forms.NumericUpDown();
            this.OutputPathInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TaxRateNumericField = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.DiscountRateNumericField = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.DiscountRateFileTextField = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ExpectedClaimAmountNumericField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRateNumericField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountRateNumericField)).BeginInit();
            this.SuspendLayout();
            // 
            // ClaimDataFileInput
            // 
            this.ClaimDataFileInput.BackColor = System.Drawing.Color.White;
            this.ClaimDataFileInput.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ClaimDataFileInput.Location = new System.Drawing.Point(325, 170);
            this.ClaimDataFileInput.Name = "ClaimDataFileInput";
            this.ClaimDataFileInput.Size = new System.Drawing.Size(594, 30);
            this.ClaimDataFileInput.TabIndex = 4;
            this.ClaimDataFileInput.TextChanged += new System.EventHandler(this.AllTextFilled);
            this.ClaimDataFileInput.Leave += new System.EventHandler(this.ClaimDataFileInput_Leave);
            this.ClaimDataFileInput.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ClaimCriteriaFileInput_OpenExplorer);
            // 
            // DataFileLabel
            // 
            this.DataFileLabel.AutoSize = true;
            this.DataFileLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataFileLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.DataFileLabel.Location = new System.Drawing.Point(49, 177);
            this.DataFileLabel.Name = "DataFileLabel";
            this.DataFileLabel.Size = new System.Drawing.Size(259, 22);
            this.DataFileLabel.TabIndex = 3;
            this.DataFileLabel.Text = "Whole Sale Claim Criteria File";
            // 
            // BillFolder
            // 
            this.BillFolder.BackColor = System.Drawing.Color.White;
            this.BillFolder.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BillFolder.Location = new System.Drawing.Point(244, 232);
            this.BillFolder.Name = "BillFolder";
            this.BillFolder.Size = new System.Drawing.Size(675, 30);
            this.BillFolder.TabIndex = 6;
            this.BillFolder.TextChanged += new System.EventHandler(this.AllTextFilled);
            this.BillFolder.Leave += new System.EventHandler(this.BillFolder_Leave);
            this.BillFolder.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SampleBillPath_OpenExplorer);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.RosyBrown;
            this.label1.Location = new System.Drawing.Point(54, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sample Bill Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.RosyBrown;
            this.label2.Location = new System.Drawing.Point(53, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Expected Whole Sale Claim Amount";
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = System.Drawing.Color.Red;
            this.ResetButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ResetButton.Location = new System.Drawing.Point(588, 471);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(154, 52);
            this.ResetButton.TabIndex = 14;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // GenerateButton
            // 
            this.GenerateButton.BackColor = System.Drawing.Color.DarkGray;
            this.GenerateButton.Enabled = false;
            this.GenerateButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GenerateButton.Location = new System.Drawing.Point(123, 471);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(154, 52);
            this.GenerateButton.TabIndex = 13;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = false;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // ExpectedClaimAmountNumericField
            // 
            this.ExpectedClaimAmountNumericField.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExpectedClaimAmountNumericField.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ExpectedClaimAmountNumericField.Location = new System.Drawing.Point(379, 37);
            this.ExpectedClaimAmountNumericField.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ExpectedClaimAmountNumericField.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ExpectedClaimAmountNumericField.Name = "ExpectedClaimAmountNumericField";
            this.ExpectedClaimAmountNumericField.Size = new System.Drawing.Size(256, 30);
            this.ExpectedClaimAmountNumericField.TabIndex = 15;
            this.ExpectedClaimAmountNumericField.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ExpectedClaimAmountNumericField.ValueChanged += new System.EventHandler(this.ExpectedClaimAmountNumericField_ValueChanged);
            // 
            // OutputPathInput
            // 
            this.OutputPathInput.BackColor = System.Drawing.Color.White;
            this.OutputPathInput.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutputPathInput.Location = new System.Drawing.Point(160, 333);
            this.OutputPathInput.Name = "OutputPathInput";
            this.OutputPathInput.Size = new System.Drawing.Size(745, 30);
            this.OutputPathInput.TabIndex = 17;
            this.OutputPathInput.TextChanged += new System.EventHandler(this.AllTextFilled);
            this.OutputPathInput.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OutputPath_OpenExplorer);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.RosyBrown;
            this.label3.Location = new System.Drawing.Point(52, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 22);
            this.label3.TabIndex = 16;
            this.label3.Text = "Output Path";
            // 
            // TaxRateNumericField
            // 
            this.TaxRateNumericField.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TaxRateNumericField.Location = new System.Drawing.Point(195, 101);
            this.TaxRateNumericField.Name = "TaxRateNumericField";
            this.TaxRateNumericField.Size = new System.Drawing.Size(81, 30);
            this.TaxRateNumericField.TabIndex = 19;
            this.TaxRateNumericField.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.TaxRateNumericField.ValueChanged += new System.EventHandler(this.TaxRateNumericField_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.RosyBrown;
            this.label4.Location = new System.Drawing.Point(53, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 22);
            this.label4.TabIndex = 18;
            this.label4.Text = "Tax Rate (In %)";
            // 
            // DiscountRateNumericField
            // 
            this.DiscountRateNumericField.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DiscountRateNumericField.Location = new System.Drawing.Point(573, 101);
            this.DiscountRateNumericField.Name = "DiscountRateNumericField";
            this.DiscountRateNumericField.Size = new System.Drawing.Size(81, 30);
            this.DiscountRateNumericField.TabIndex = 21;
            this.DiscountRateNumericField.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.DiscountRateNumericField.ValueChanged += new System.EventHandler(this.DiscountRateNumericField_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.RosyBrown;
            this.label5.Location = new System.Drawing.Point(354, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 22);
            this.label5.TabIndex = 20;
            this.label5.Text = "Bill Discount Rate (In %)";
            // 
            // DiscountRateFileTextField
            // 
            this.DiscountRateFileTextField.BackColor = System.Drawing.Color.White;
            this.DiscountRateFileTextField.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DiscountRateFileTextField.Location = new System.Drawing.Point(244, 284);
            this.DiscountRateFileTextField.Name = "DiscountRateFileTextField";
            this.DiscountRateFileTextField.Size = new System.Drawing.Size(675, 30);
            this.DiscountRateFileTextField.TabIndex = 23;
            this.DiscountRateFileTextField.TextChanged += new System.EventHandler(this.AllTextFilled);
            this.DiscountRateFileTextField.Leave += new System.EventHandler(this.DiscountRateFileTextField_Leave);
            this.DiscountRateFileTextField.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DiscountRateFileTextField_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.RosyBrown;
            this.label6.Location = new System.Drawing.Point(54, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 22);
            this.label6.TabIndex = 22;
            this.label6.Text = "Discount Rate File";
            // 
            // WholeSaleClaimCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.DiscountRateFileTextField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DiscountRateNumericField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TaxRateNumericField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.OutputPathInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ExpectedClaimAmountNumericField);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BillFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClaimDataFileInput);
            this.Controls.Add(this.DataFileLabel);
            this.Name = "WholeSaleClaimCreator";
            this.Size = new System.Drawing.Size(1008, 581);
            this.Load += new System.EventHandler(this.WholeSaleClaimCreator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExpectedClaimAmountNumericField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRateNumericField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountRateNumericField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox ClaimDataFileInput;
        private Label DataFileLabel;
        private TextBox BillFolder;
        private Label label1;
        private Label label2;
        private Button ResetButton;
        private Button GenerateButton;
        private NumericUpDown ExpectedClaimAmountNumericField;
        private TextBox OutputPathInput;
        private Label label3;
        private NumericUpDown TaxRateNumericField;
        private Label label4;
        private NumericUpDown DiscountRateNumericField;
        private Label label5;
        private TextBox DiscountRateFileTextField;
        private Label label6;
    }
}
