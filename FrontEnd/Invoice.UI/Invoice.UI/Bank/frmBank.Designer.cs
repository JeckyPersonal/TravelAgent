namespace Invoice.UI.Bank
{
    partial class frmBank
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
            this.button1 = new System.Windows.Forms.Button();
            this.pnlBankInfo = new System.Windows.Forms.Panel();
            this.btnAccountInfo = new System.Windows.Forms.Button();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.flowPanelErrorMessage = new System.Windows.Forms.Panel();
            this.pnlTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlBankInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Location = new System.Drawing.Point(3, 3);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(6);
            this.pnlTitle.Size = new System.Drawing.Size(923, 52);
            // 
            // heading1
            // 
            this.heading1.Margin = new System.Windows.Forms.Padding(8);
            this.heading1.Size = new System.Drawing.Size(923, 52);
            this.heading1.Title = "Bank";
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 168);
            this.panel1.Size = new System.Drawing.Size(923, 61);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(720, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 48);
            this.button2.TabIndex = 3;
            this.button2.Text = "C&lose";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(515, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlBankInfo
            // 
            this.pnlBankInfo.AutoSize = true;
            this.pnlBankInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBankInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.pnlBankInfo.Controls.Add(this.btnAccountInfo);
            this.pnlBankInfo.Controls.Add(this.lblCompanyName);
            this.pnlBankInfo.Controls.Add(this.lblId);
            this.pnlBankInfo.Controls.Add(this.txtId);
            this.pnlBankInfo.Controls.Add(this.txtBankName);
            this.pnlBankInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBankInfo.Location = new System.Drawing.Point(3, 57);
            this.pnlBankInfo.Margin = new System.Windows.Forms.Padding(5);
            this.pnlBankInfo.Name = "pnlBankInfo";
            this.pnlBankInfo.Size = new System.Drawing.Size(923, 111);
            this.pnlBankInfo.TabIndex = 11;
            // 
            // btnAccountInfo
            // 
            this.btnAccountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccountInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAccountInfo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAccountInfo.FlatAppearance.BorderSize = 2;
            this.btnAccountInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccountInfo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountInfo.ForeColor = System.Drawing.Color.White;
            this.btnAccountInfo.Location = new System.Drawing.Point(645, 58);
            this.btnAccountInfo.Margin = new System.Windows.Forms.Padding(5);
            this.btnAccountInfo.Name = "btnAccountInfo";
            this.btnAccountInfo.Size = new System.Drawing.Size(263, 48);
            this.btnAccountInfo.TabIndex = 2;
            this.btnAccountInfo.Text = "&Add Account Info";
            this.btnAccountInfo.UseVisualStyleBackColor = false;
            this.btnAccountInfo.Click += new System.EventHandler(this.btnAccountInfo_Click);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCompanyName.Location = new System.Drawing.Point(63, 20);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(137, 25);
            this.lblCompanyName.TabIndex = 7;
            this.lblCompanyName.Text = "Bank Name:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblId.Location = new System.Drawing.Point(786, 20);
            this.lblId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(41, 25);
            this.lblId.TabIndex = 9;
            this.lblId.Text = "Id:";
            this.lblId.Visible = false;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtId.Location = new System.Drawing.Point(834, 14);
            this.txtId.Margin = new System.Windows.Forms.Padding(5);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(74, 31);
            this.txtId.TabIndex = 10;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtId.Visible = false;
            this.txtId.Leave += new System.EventHandler(this.txtBankName_Leave);
            // 
            // txtBankName
            // 
            this.txtBankName.BackColor = System.Drawing.Color.White;
            this.txtBankName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBankName.Location = new System.Drawing.Point(210, 14);
            this.txtBankName.Margin = new System.Windows.Forms.Padding(5);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(561, 31);
            this.txtBankName.TabIndex = 1;
            this.txtBankName.Leave += new System.EventHandler(this.txtBankName_Leave);
            // 
            // flowPanelErrorMessage
            // 
            this.flowPanelErrorMessage.AutoSize = true;
            this.flowPanelErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPanelErrorMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowPanelErrorMessage.Location = new System.Drawing.Point(3, 55);
            this.flowPanelErrorMessage.Margin = new System.Windows.Forms.Padding(5);
            this.flowPanelErrorMessage.Name = "flowPanelErrorMessage";
            this.flowPanelErrorMessage.Size = new System.Drawing.Size(923, 2);
            this.flowPanelErrorMessage.TabIndex = 12;
            this.flowPanelErrorMessage.Visible = false;
            // 
            // frmBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(929, 232);
            this.Controls.Add(this.pnlBankInfo);
            this.Controls.Add(this.flowPanelErrorMessage);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmBank";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlTitle, 0);
            this.Controls.SetChildIndex(this.flowPanelErrorMessage, 0);
            this.Controls.SetChildIndex(this.pnlBankInfo, 0);
            this.pnlTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlBankInfo.ResumeLayout(false);
            this.pnlBankInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlBankInfo;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Button btnAccountInfo;
        private System.Windows.Forms.Panel flowPanelErrorMessage;
    }
}