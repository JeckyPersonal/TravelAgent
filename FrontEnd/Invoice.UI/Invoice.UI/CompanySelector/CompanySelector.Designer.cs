namespace Invoice.UI.CompanySelector
{
    partial class CompanySelector
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
            this.button2 = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.pnlData = new System.Windows.Forms.Panel();
            this.cmbFinancialYear = new System.Windows.Forms.ComboBox();
            this.lblFinancialYear = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Location = new System.Drawing.Point(5, 4);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(6);
            this.pnlTitle.Size = new System.Drawing.Size(836, 50);
            // 
            // heading1
            // 
            this.heading1.Margin = new System.Windows.Forms.Padding(8);
            this.heading1.Size = new System.Drawing.Size(836, 50);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Location = new System.Drawing.Point(5, 257);
            this.panel1.Size = new System.Drawing.Size(836, 79);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(632, 10);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 60);
            this.button2.TabIndex = 3;
            this.button2.Text = "C&lose";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.Black;
            this.btnSelect.Location = new System.Drawing.Point(429, 10);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(6);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(190, 60);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "&Select";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.pnlData.Controls.Add(this.cmbFinancialYear);
            this.pnlData.Controls.Add(this.lblFinancialYear);
            this.pnlData.Controls.Add(this.cmbCompany);
            this.pnlData.Controls.Add(this.lblCompanyName);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(5, 54);
            this.pnlData.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(836, 203);
            this.pnlData.TabIndex = 6;
            // 
            // cmbFinancialYear
            // 
            this.cmbFinancialYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFinancialYear.FormattingEnabled = true;
            this.cmbFinancialYear.Location = new System.Drawing.Point(226, 83);
            this.cmbFinancialYear.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbFinancialYear.Name = "cmbFinancialYear";
            this.cmbFinancialYear.Size = new System.Drawing.Size(432, 33);
            this.cmbFinancialYear.TabIndex = 1;
            this.cmbFinancialYear.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblFinancialYear
            // 
            this.lblFinancialYear.AutoSize = true;
            this.lblFinancialYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblFinancialYear.Location = new System.Drawing.Point(40, 86);
            this.lblFinancialYear.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFinancialYear.Name = "lblFinancialYear";
            this.lblFinancialYear.Size = new System.Drawing.Size(162, 25);
            this.lblFinancialYear.TabIndex = 3;
            this.lblFinancialYear.Text = "Financial Year:";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(226, 29);
            this.cmbCompany.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(590, 33);
            this.cmbCompany.TabIndex = 0;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCompanyName.Location = new System.Drawing.Point(16, 33);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(180, 25);
            this.lblCompanyName.TabIndex = 1;
            this.lblCompanyName.Text = "Company Name:";
            // 
            // CompanySelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 340);
            this.Controls.Add(this.pnlData);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "CompanySelector";
            this.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CompanySelector_Load);
            this.Leave += new System.EventHandler(this.CompanySelector_Leave);
            this.Controls.SetChildIndex(this.pnlTitle, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlData, 0);
            this.pnlTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.ComboBox cmbFinancialYear;
        private System.Windows.Forms.Label lblFinancialYear;
    }
}