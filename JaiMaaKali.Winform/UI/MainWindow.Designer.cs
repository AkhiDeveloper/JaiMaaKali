namespace JaiMaaKali.WinForm.UI
{
    partial class MainWindow
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.NavPanel = new System.Windows.Forms.Panel();
            this.WholeSalePageButton = new Guna.UI2.WinForms.Guna2TileButton();
            this.TransportClaimPageButton = new Guna.UI2.WinForms.Guna2TileButton();
            this.OutputPanel = new System.Windows.Forms.Panel();
            this.transportClaimControl = new JaiMaaKali.WinForm.TransportClaimControl();
            this.panel1.SuspendLayout();
            this.NavPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1191, 96);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(436, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Claim Generator";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NavPanel
            // 
            this.NavPanel.BackColor = System.Drawing.Color.Red;
            this.NavPanel.Controls.Add(this.WholeSalePageButton);
            this.NavPanel.Controls.Add(this.TransportClaimPageButton);
            this.NavPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NavPanel.Location = new System.Drawing.Point(0, 96);
            this.NavPanel.Name = "NavPanel";
            this.NavPanel.Size = new System.Drawing.Size(1191, 69);
            this.NavPanel.TabIndex = 1;
            // 
            // WholeSalePageButton
            // 
            this.WholeSalePageButton.BackColor = System.Drawing.Color.Transparent;
            this.WholeSalePageButton.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.WholeSalePageButton.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.WholeSalePageButton.CustomizableEdges = customizableEdges1;
            this.WholeSalePageButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.WholeSalePageButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.WholeSalePageButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.WholeSalePageButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.WholeSalePageButton.FillColor = System.Drawing.Color.Transparent;
            this.WholeSalePageButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WholeSalePageButton.ForeColor = System.Drawing.Color.Lavender;
            this.WholeSalePageButton.Location = new System.Drawing.Point(332, 6);
            this.WholeSalePageButton.Name = "WholeSalePageButton";
            this.WholeSalePageButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.WholeSalePageButton.Size = new System.Drawing.Size(273, 57);
            this.WholeSalePageButton.TabIndex = 3;
            this.WholeSalePageButton.Text = "WholeSale Claim";
            this.WholeSalePageButton.Click += new System.EventHandler(this.WholeSalePageButton_Click);
            // 
            // TransportClaimPageButton
            // 
            this.TransportClaimPageButton.BackColor = System.Drawing.Color.Transparent;
            this.TransportClaimPageButton.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.TransportClaimPageButton.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.TransportClaimPageButton.CustomizableEdges = customizableEdges3;
            this.TransportClaimPageButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.TransportClaimPageButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.TransportClaimPageButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.TransportClaimPageButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.TransportClaimPageButton.FillColor = System.Drawing.Color.Transparent;
            this.TransportClaimPageButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TransportClaimPageButton.ForeColor = System.Drawing.Color.Lavender;
            this.TransportClaimPageButton.Location = new System.Drawing.Point(25, 6);
            this.TransportClaimPageButton.Name = "TransportClaimPageButton";
            this.TransportClaimPageButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            this.TransportClaimPageButton.Size = new System.Drawing.Size(273, 57);
            this.TransportClaimPageButton.TabIndex = 2;
            this.TransportClaimPageButton.Text = "Transport Claim";
            this.TransportClaimPageButton.Click += new System.EventHandler(this.TransportClaimPageButton_Click);
            // 
            // OutputPanel
            // 
            this.OutputPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputPanel.BackColor = System.Drawing.Color.DarkGray;
            this.OutputPanel.Location = new System.Drawing.Point(0, 165);
            this.OutputPanel.Name = "OutputPanel";
            this.OutputPanel.Size = new System.Drawing.Size(1191, 438);
            this.OutputPanel.TabIndex = 2;
            // 
            // transportClaimControl
            // 
            this.transportClaimControl.BackColor = System.Drawing.SystemColors.Desktop;
            this.transportClaimControl.Location = new System.Drawing.Point(0, 0);
            this.transportClaimControl.Name = "transportClaimControl";
            this.transportClaimControl.Size = new System.Drawing.Size(745, 408);
            this.transportClaimControl.Margin = new Padding(10);
            this.transportClaimControl.TabIndex = 0;
            // 
            
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 603);
            this.Controls.Add(this.OutputPanel);
            this.Controls.Add(this.NavPanel);
            this.Controls.Add(this.panel1);
            this.Name = "MainWindow";
            this.Text = "Claim Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.NavPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel NavPanel;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TileButton WholeSalePageButton;
        private Guna.UI2.WinForms.Guna2TileButton TransportClaimPageButton;
        private UserControl transportClaimControl;
        private UserControl WholeSaleClaimControl;
        private Panel OutputPanel;
    }
}