namespace Invoice.UI.Payment
{
    partial class frmPayment
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
            this.pnlData = new System.Windows.Forms.Panel();
            this.pnlInvoice = new System.Windows.Forms.Panel();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblReceiveAmount = new System.Windows.Forms.Label();
            this.lblIGST = new System.Windows.Forms.Label();
            this.lblSGST = new System.Windows.Forms.Label();
            this.lblCGST = new System.Windows.Forms.Label();
            this.lblTDS = new System.Windows.Forms.Label();
            this.txtReceiveAmount = new System.Windows.Forms.TextBox();
            this.txtIGST = new System.Windows.Forms.TextBox();
            this.txtSGST = new System.Windows.Forms.TextBox();
            this.txtCGST = new System.Windows.Forms.TextBox();
            this.txtTDS = new System.Windows.Forms.TextBox();
            this.txtInvoiceAmount = new System.Windows.Forms.TextBox();
            this.lblInvoiceAmount = new System.Windows.Forms.Label();
            this.btnShowVoucher = new System.Windows.Forms.Button();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtReferenceNo = new System.Windows.Forms.TextBox();
            this.lblReferenceNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.pnlTitle.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Location = new System.Drawing.Point(2, 2);
            this.pnlTitle.Size = new System.Drawing.Size(717, 33);
            // 
            // heading1
            // 
            this.heading1.Size = new System.Drawing.Size(717, 33);
            this.heading1.Title = "Payment Advice";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.panel1.Location = new System.Drawing.Point(2, 389);
            this.panel1.Size = new System.Drawing.Size(717, 59);
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.pnlData.Controls.Add(this.pnlInvoice);
            this.pnlData.Controls.Add(this.pnlInfo);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(2, 35);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(717, 354);
            this.pnlData.TabIndex = 6;
            // 
            // pnlInvoice
            // 
            this.pnlInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInvoice.Location = new System.Drawing.Point(0, 116);
            this.pnlInvoice.Name = "pnlInvoice";
            this.pnlInvoice.Size = new System.Drawing.Size(717, 238);
            this.pnlInvoice.TabIndex = 1;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblReceiveAmount);
            this.pnlInfo.Controls.Add(this.lblIGST);
            this.pnlInfo.Controls.Add(this.lblSGST);
            this.pnlInfo.Controls.Add(this.lblCGST);
            this.pnlInfo.Controls.Add(this.lblTDS);
            this.pnlInfo.Controls.Add(this.txtReceiveAmount);
            this.pnlInfo.Controls.Add(this.txtIGST);
            this.pnlInfo.Controls.Add(this.txtSGST);
            this.pnlInfo.Controls.Add(this.txtCGST);
            this.pnlInfo.Controls.Add(this.txtTDS);
            this.pnlInfo.Controls.Add(this.txtInvoiceAmount);
            this.pnlInfo.Controls.Add(this.lblInvoiceAmount);
            this.pnlInfo.Controls.Add(this.btnShowVoucher);
            this.pnlInfo.Controls.Add(this.cmbCustomer);
            this.pnlInfo.Controls.Add(this.lblCustomer);
            this.pnlInfo.Controls.Add(this.txtReferenceNo);
            this.pnlInfo.Controls.Add(this.lblReferenceNo);
            this.pnlInfo.Controls.Add(this.lblDate);
            this.pnlInfo.Controls.Add(this.dtpPaymentDate);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(717, 116);
            this.pnlInfo.TabIndex = 0;
            // 
            // lblReceiveAmount
            // 
            this.lblReceiveAmount.AutoSize = true;
            this.lblReceiveAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblReceiveAmount.Location = new System.Drawing.Point(502, 62);
            this.lblReceiveAmount.Name = "lblReceiveAmount";
            this.lblReceiveAmount.Size = new System.Drawing.Size(113, 16);
            this.lblReceiveAmount.TabIndex = 65;
            this.lblReceiveAmount.Text = "Receive Amount";
            // 
            // lblIGST
            // 
            this.lblIGST.AutoSize = true;
            this.lblIGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblIGST.Location = new System.Drawing.Point(405, 62);
            this.lblIGST.Name = "lblIGST";
            this.lblIGST.Size = new System.Drawing.Size(44, 16);
            this.lblIGST.TabIndex = 64;
            this.lblIGST.Text = "I.GST";
            // 
            // lblSGST
            // 
            this.lblSGST.AutoSize = true;
            this.lblSGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblSGST.Location = new System.Drawing.Point(308, 62);
            this.lblSGST.Name = "lblSGST";
            this.lblSGST.Size = new System.Drawing.Size(48, 16);
            this.lblSGST.TabIndex = 63;
            this.lblSGST.Text = "S.GST";
            // 
            // lblCGST
            // 
            this.lblCGST.AutoSize = true;
            this.lblCGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCGST.Location = new System.Drawing.Point(211, 62);
            this.lblCGST.Name = "lblCGST";
            this.lblCGST.Size = new System.Drawing.Size(48, 16);
            this.lblCGST.TabIndex = 62;
            this.lblCGST.Text = "C.GST";
            // 
            // lblTDS
            // 
            this.lblTDS.AutoSize = true;
            this.lblTDS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblTDS.Location = new System.Drawing.Point(112, 62);
            this.lblTDS.Name = "lblTDS";
            this.lblTDS.Size = new System.Drawing.Size(34, 16);
            this.lblTDS.TabIndex = 61;
            this.lblTDS.Text = "TDS";
            // 
            // txtReceiveAmount
            // 
            this.txtReceiveAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReceiveAmount.Location = new System.Drawing.Point(499, 81);
            this.txtReceiveAmount.Name = "txtReceiveAmount";
            this.txtReceiveAmount.Size = new System.Drawing.Size(116, 23);
            this.txtReceiveAmount.TabIndex = 60;
            this.txtReceiveAmount.Text = "100000.00";
            this.txtReceiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIGST
            // 
            this.txtIGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIGST.Location = new System.Drawing.Point(402, 81);
            this.txtIGST.Name = "txtIGST";
            this.txtIGST.Size = new System.Drawing.Size(86, 23);
            this.txtIGST.TabIndex = 59;
            this.txtIGST.Text = "100000.00";
            this.txtIGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSGST
            // 
            this.txtSGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSGST.Location = new System.Drawing.Point(305, 81);
            this.txtSGST.Name = "txtSGST";
            this.txtSGST.Size = new System.Drawing.Size(86, 23);
            this.txtSGST.TabIndex = 58;
            this.txtSGST.Text = "100000.00";
            this.txtSGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCGST
            // 
            this.txtCGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCGST.Location = new System.Drawing.Point(208, 81);
            this.txtCGST.Name = "txtCGST";
            this.txtCGST.Size = new System.Drawing.Size(86, 23);
            this.txtCGST.TabIndex = 57;
            this.txtCGST.Text = "100000.00";
            this.txtCGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTDS
            // 
            this.txtTDS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTDS.Location = new System.Drawing.Point(109, 81);
            this.txtTDS.Name = "txtTDS";
            this.txtTDS.Size = new System.Drawing.Size(86, 23);
            this.txtTDS.TabIndex = 56;
            this.txtTDS.Text = "100000.00";
            this.txtTDS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInvoiceAmount
            // 
            this.txtInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceAmount.Location = new System.Drawing.Point(11, 81);
            this.txtInvoiceAmount.Name = "txtInvoiceAmount";
            this.txtInvoiceAmount.Size = new System.Drawing.Size(86, 23);
            this.txtInvoiceAmount.TabIndex = 55;
            this.txtInvoiceAmount.Text = "100000.00";
            this.txtInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblInvoiceAmount
            // 
            this.lblInvoiceAmount.AutoSize = true;
            this.lblInvoiceAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblInvoiceAmount.Location = new System.Drawing.Point(13, 62);
            this.lblInvoiceAmount.Name = "lblInvoiceAmount";
            this.lblInvoiceAmount.Size = new System.Drawing.Size(57, 16);
            this.lblInvoiceAmount.TabIndex = 54;
            this.lblInvoiceAmount.Text = "Amount";
            // 
            // btnShowVoucher
            // 
            this.btnShowVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnShowVoucher.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnShowVoucher.FlatAppearance.BorderSize = 2;
            this.btnShowVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowVoucher.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowVoucher.ForeColor = System.Drawing.Color.White;
            this.btnShowVoucher.Location = new System.Drawing.Point(588, 29);
            this.btnShowVoucher.Margin = new System.Windows.Forms.Padding(0);
            this.btnShowVoucher.Name = "btnShowVoucher";
            this.btnShowVoucher.Size = new System.Drawing.Size(120, 26);
            this.btnShowVoucher.TabIndex = 53;
            this.btnShowVoucher.Text = "Show &Invoice";
            this.btnShowVoucher.UseVisualStyleBackColor = false;
            this.btnShowVoucher.Click += new System.EventHandler(this.btnShowVoucher_Click);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(259, 29);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(326, 24);
            this.cmbCustomer.TabIndex = 52;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCustomer.Location = new System.Drawing.Point(262, 11);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(75, 16);
            this.lblCustomer.TabIndex = 40;
            this.lblCustomer.Text = "Customer:";
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReferenceNo.Location = new System.Drawing.Point(118, 30);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(135, 23);
            this.txtReferenceNo.TabIndex = 39;
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.AutoSize = true;
            this.lblReferenceNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblReferenceNo.Location = new System.Drawing.Point(120, 11);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(101, 16);
            this.lblReferenceNo.TabIndex = 38;
            this.lblReferenceNo.Text = "Reference No:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblDate.Location = new System.Drawing.Point(13, 11);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(44, 16);
            this.lblDate.TabIndex = 37;
            this.lblDate.Text = "Date:";
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaymentDate.Location = new System.Drawing.Point(11, 30);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(102, 23);
            this.dtpPaymentDate.TabIndex = 36;
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(721, 450);
            this.Controls.Add(this.pnlData);
            this.Name = "frmPayment";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPayment";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.Controls.SetChildIndex(this.pnlTitle, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlData, 0);
            this.pnlTitle.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel pnlInvoice;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label lblReferenceNo;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtReferenceNo;
        private System.Windows.Forms.Button btnShowVoucher;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.TextBox txtInvoiceAmount;
        private System.Windows.Forms.Label lblInvoiceAmount;
        private System.Windows.Forms.TextBox txtTDS;
        private System.Windows.Forms.TextBox txtReceiveAmount;
        private System.Windows.Forms.TextBox txtIGST;
        private System.Windows.Forms.TextBox txtSGST;
        private System.Windows.Forms.TextBox txtCGST;
        private System.Windows.Forms.Label lblSGST;
        private System.Windows.Forms.Label lblCGST;
        private System.Windows.Forms.Label lblTDS;
        private System.Windows.Forms.Label lblReceiveAmount;
        private System.Windows.Forms.Label lblIGST;
    }
}