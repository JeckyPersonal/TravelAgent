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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlData = new System.Windows.Forms.Panel();
            this.pnlInvoice = new System.Windows.Forms.Panel();
            this.dgvPayment = new System.Windows.Forms.DataGridView();
            this.pnlAmount = new System.Windows.Forms.Panel();
            this.lblReceiveAmount = new System.Windows.Forms.Label();
            this.txtReceiveAmount = new System.Windows.Forms.TextBox();
            this.lblIGST = new System.Windows.Forms.Label();
            this.txtInvoiceAmount = new System.Windows.Forms.TextBox();
            this.lblSGST = new System.Windows.Forms.Label();
            this.txtIGST = new System.Windows.Forms.TextBox();
            this.lblInvoiceAmount = new System.Windows.Forms.Label();
            this.lblCGST = new System.Windows.Forms.Label();
            this.txtTDS = new System.Windows.Forms.TextBox();
            this.txtSGST = new System.Windows.Forms.TextBox();
            this.lblTDS = new System.Windows.Forms.Label();
            this.txtCGST = new System.Windows.Forms.TextBox();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.btnShowVoucher = new System.Windows.Forms.Button();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtReferenceNo = new System.Windows.Forms.TextBox();
            this.lblReferenceNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.pnlInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            this.pnlAmount.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Location = new System.Drawing.Point(3, 3);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlTitle.Size = new System.Drawing.Size(1166, 52);
            // 
            // heading1
            // 
            this.heading1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.heading1.Size = new System.Drawing.Size(1166, 52);
            this.heading1.Title = "Payment Advice";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 472);
            this.panel1.Size = new System.Drawing.Size(1166, 64);
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.pnlData.Controls.Add(this.pnlInvoice);
            this.pnlData.Controls.Add(this.pnlInfo);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(3, 55);
            this.pnlData.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1166, 417);
            this.pnlData.TabIndex = 6;
            // 
            // pnlInvoice
            // 
            this.pnlInvoice.Controls.Add(this.dgvPayment);
            this.pnlInvoice.Controls.Add(this.pnlAmount);
            this.pnlInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInvoice.Location = new System.Drawing.Point(0, 98);
            this.pnlInvoice.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pnlInvoice.Name = "pnlInvoice";
            this.pnlInvoice.Size = new System.Drawing.Size(1166, 319);
            this.pnlInvoice.TabIndex = 1;
            // 
            // dgvPayment
            // 
            this.dgvPayment.AllowUserToAddRows = false;
            this.dgvPayment.AllowUserToDeleteRows = false;
            this.dgvPayment.AllowUserToResizeRows = false;
            this.dgvPayment.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.dgvPayment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPayment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPayment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPayment.EnableHeadersVisualStyles = false;
            this.dgvPayment.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgvPayment.Location = new System.Drawing.Point(0, 0);
            this.dgvPayment.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dgvPayment.MultiSelect = false;
            this.dgvPayment.Name = "dgvPayment";
            this.dgvPayment.RowHeadersVisible = false;
            this.dgvPayment.RowHeadersWidth = 62;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPayment.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayment.Size = new System.Drawing.Size(808, 319);
            this.dgvPayment.TabIndex = 1;
            // 
            // pnlAmount
            // 
            this.pnlAmount.Controls.Add(this.lblReceiveAmount);
            this.pnlAmount.Controls.Add(this.txtReceiveAmount);
            this.pnlAmount.Controls.Add(this.lblIGST);
            this.pnlAmount.Controls.Add(this.txtInvoiceAmount);
            this.pnlAmount.Controls.Add(this.lblSGST);
            this.pnlAmount.Controls.Add(this.txtIGST);
            this.pnlAmount.Controls.Add(this.lblInvoiceAmount);
            this.pnlAmount.Controls.Add(this.lblCGST);
            this.pnlAmount.Controls.Add(this.txtTDS);
            this.pnlAmount.Controls.Add(this.txtSGST);
            this.pnlAmount.Controls.Add(this.lblTDS);
            this.pnlAmount.Controls.Add(this.txtCGST);
            this.pnlAmount.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAmount.Location = new System.Drawing.Point(808, 0);
            this.pnlAmount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pnlAmount.Name = "pnlAmount";
            this.pnlAmount.Size = new System.Drawing.Size(358, 319);
            this.pnlAmount.TabIndex = 66;
            // 
            // lblReceiveAmount
            // 
            this.lblReceiveAmount.AutoSize = true;
            this.lblReceiveAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblReceiveAmount.Location = new System.Drawing.Point(10, 256);
            this.lblReceiveAmount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReceiveAmount.Name = "lblReceiveAmount";
            this.lblReceiveAmount.Size = new System.Drawing.Size(140, 25);
            this.lblReceiveAmount.TabIndex = 77;
            this.lblReceiveAmount.Text = "Net. Amount";
            // 
            // txtReceiveAmount
            // 
            this.txtReceiveAmount.BackColor = System.Drawing.Color.White;
            this.txtReceiveAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReceiveAmount.Location = new System.Drawing.Point(161, 252);
            this.txtReceiveAmount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtReceiveAmount.Name = "txtReceiveAmount";
            this.txtReceiveAmount.ReadOnly = true;
            this.txtReceiveAmount.Size = new System.Drawing.Size(187, 31);
            this.txtReceiveAmount.TabIndex = 72;
            this.txtReceiveAmount.Text = "100000.00";
            this.txtReceiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIGST
            // 
            this.lblIGST.AutoSize = true;
            this.lblIGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblIGST.Location = new System.Drawing.Point(130, 212);
            this.lblIGST.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblIGST.Name = "lblIGST";
            this.lblIGST.Size = new System.Drawing.Size(69, 25);
            this.lblIGST.TabIndex = 76;
            this.lblIGST.Text = "I.GST";
            // 
            // txtInvoiceAmount
            // 
            this.txtInvoiceAmount.BackColor = System.Drawing.Color.White;
            this.txtInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceAmount.Location = new System.Drawing.Point(210, 25);
            this.txtInvoiceAmount.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtInvoiceAmount.Name = "txtInvoiceAmount";
            this.txtInvoiceAmount.Size = new System.Drawing.Size(138, 31);
            this.txtInvoiceAmount.TabIndex = 67;
            this.txtInvoiceAmount.Text = "100000.00";
            this.txtInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSGST
            // 
            this.lblSGST.AutoSize = true;
            this.lblSGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblSGST.Location = new System.Drawing.Point(124, 167);
            this.lblSGST.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSGST.Name = "lblSGST";
            this.lblSGST.Size = new System.Drawing.Size(75, 25);
            this.lblSGST.TabIndex = 75;
            this.lblSGST.Text = "S.GST";
            // 
            // txtIGST
            // 
            this.txtIGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIGST.Location = new System.Drawing.Point(210, 206);
            this.txtIGST.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtIGST.Name = "txtIGST";
            this.txtIGST.Size = new System.Drawing.Size(138, 31);
            this.txtIGST.TabIndex = 71;
            this.txtIGST.Text = "100000.00";
            this.txtIGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIGST.Leave += new System.EventHandler(this.txtIGST_Leave);
            // 
            // lblInvoiceAmount
            // 
            this.lblInvoiceAmount.AutoSize = true;
            this.lblInvoiceAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblInvoiceAmount.Location = new System.Drawing.Point(109, 30);
            this.lblInvoiceAmount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInvoiceAmount.Name = "lblInvoiceAmount";
            this.lblInvoiceAmount.Size = new System.Drawing.Size(91, 25);
            this.lblInvoiceAmount.TabIndex = 66;
            this.lblInvoiceAmount.Text = "Amount";
            // 
            // lblCGST
            // 
            this.lblCGST.AutoSize = true;
            this.lblCGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCGST.Location = new System.Drawing.Point(124, 122);
            this.lblCGST.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCGST.Name = "lblCGST";
            this.lblCGST.Size = new System.Drawing.Size(75, 25);
            this.lblCGST.TabIndex = 74;
            this.lblCGST.Text = "C.GST";
            // 
            // txtTDS
            // 
            this.txtTDS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTDS.Location = new System.Drawing.Point(210, 70);
            this.txtTDS.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTDS.Name = "txtTDS";
            this.txtTDS.Size = new System.Drawing.Size(138, 31);
            this.txtTDS.TabIndex = 68;
            this.txtTDS.Text = "100000.00";
            this.txtTDS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTDS.Leave += new System.EventHandler(this.txtIGST_Leave);
            // 
            // txtSGST
            // 
            this.txtSGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSGST.Location = new System.Drawing.Point(210, 161);
            this.txtSGST.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtSGST.Name = "txtSGST";
            this.txtSGST.Size = new System.Drawing.Size(138, 31);
            this.txtSGST.TabIndex = 70;
            this.txtSGST.Text = "100000.00";
            this.txtSGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSGST.Leave += new System.EventHandler(this.txtIGST_Leave);
            // 
            // lblTDS
            // 
            this.lblTDS.AutoSize = true;
            this.lblTDS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblTDS.Location = new System.Drawing.Point(146, 77);
            this.lblTDS.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTDS.Name = "lblTDS";
            this.lblTDS.Size = new System.Drawing.Size(53, 25);
            this.lblTDS.TabIndex = 73;
            this.lblTDS.Text = "TDS";
            // 
            // txtCGST
            // 
            this.txtCGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCGST.Location = new System.Drawing.Point(210, 116);
            this.txtCGST.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtCGST.Name = "txtCGST";
            this.txtCGST.Size = new System.Drawing.Size(138, 31);
            this.txtCGST.TabIndex = 69;
            this.txtCGST.Text = "100000.00";
            this.txtCGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCGST.Leave += new System.EventHandler(this.txtIGST_Leave);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.btnShowVoucher);
            this.pnlInfo.Controls.Add(this.cmbCustomer);
            this.pnlInfo.Controls.Add(this.lblCustomer);
            this.pnlInfo.Controls.Add(this.txtReferenceNo);
            this.pnlInfo.Controls.Add(this.lblReferenceNo);
            this.pnlInfo.Controls.Add(this.lblDate);
            this.pnlInfo.Controls.Add(this.dtpPaymentDate);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(1166, 98);
            this.pnlInfo.TabIndex = 0;
            // 
            // btnShowVoucher
            // 
            this.btnShowVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnShowVoucher.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnShowVoucher.FlatAppearance.BorderSize = 2;
            this.btnShowVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowVoucher.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowVoucher.ForeColor = System.Drawing.Color.White;
            this.btnShowVoucher.Location = new System.Drawing.Point(962, 42);
            this.btnShowVoucher.Margin = new System.Windows.Forms.Padding(0);
            this.btnShowVoucher.Name = "btnShowVoucher";
            this.btnShowVoucher.Size = new System.Drawing.Size(195, 41);
            this.btnShowVoucher.TabIndex = 53;
            this.btnShowVoucher.Text = "Show &Invoice";
            this.btnShowVoucher.UseVisualStyleBackColor = false;
            this.btnShowVoucher.Click += new System.EventHandler(this.btnShowVoucher_Click);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(421, 45);
            this.cmbCustomer.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(527, 33);
            this.cmbCustomer.TabIndex = 52;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCustomer.Location = new System.Drawing.Point(426, 17);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(118, 25);
            this.lblCustomer.TabIndex = 40;
            this.lblCustomer.Text = "Customer:";
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReferenceNo.Location = new System.Drawing.Point(192, 47);
            this.txtReferenceNo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(218, 31);
            this.txtReferenceNo.TabIndex = 39;
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.AutoSize = true;
            this.lblReferenceNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblReferenceNo.Location = new System.Drawing.Point(195, 17);
            this.lblReferenceNo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(156, 25);
            this.lblReferenceNo.TabIndex = 38;
            this.lblReferenceNo.Text = "Reference No:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblDate.Location = new System.Drawing.Point(21, 17);
            this.lblDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(68, 25);
            this.lblDate.TabIndex = 37;
            this.lblDate.Text = "Date:";
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(18, 47);
            this.dtpPaymentDate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(163, 31);
            this.dtpPaymentDate.TabIndex = 36;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(963, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
            this.button1.Location = new System.Drawing.Point(760, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1172, 539);
            this.Controls.Add(this.pnlData);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmPayment";
            this.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPayment";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.Controls.SetChildIndex(this.pnlTitle, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlData, 0);
            this.pnlTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.pnlInvoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
            this.pnlAmount.ResumeLayout(false);
            this.pnlAmount.PerformLayout();
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
        private System.Windows.Forms.DataGridView dgvPayment;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlAmount;
        private System.Windows.Forms.Label lblReceiveAmount;
        private System.Windows.Forms.TextBox txtReceiveAmount;
        private System.Windows.Forms.Label lblIGST;
        private System.Windows.Forms.TextBox txtInvoiceAmount;
        private System.Windows.Forms.Label lblSGST;
        private System.Windows.Forms.TextBox txtIGST;
        private System.Windows.Forms.Label lblInvoiceAmount;
        private System.Windows.Forms.Label lblCGST;
        private System.Windows.Forms.TextBox txtTDS;
        private System.Windows.Forms.TextBox txtSGST;
        private System.Windows.Forms.Label lblTDS;
        private System.Windows.Forms.TextBox txtCGST;
    }
}