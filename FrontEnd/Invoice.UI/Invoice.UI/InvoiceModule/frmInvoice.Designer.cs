namespace Invoice.UI.InvoiceModule
{
    partial class frmInvoice
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
            this.pnlDetailInfo = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.txtTotalIGST = new System.Windows.Forms.TextBox();
            this.lblIGST = new System.Windows.Forms.Label();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.txtTotalSGST = new System.Windows.Forms.TextBox();
            this.lblTotalSGST = new System.Windows.Forms.Label();
            this.txtTotalCGST = new System.Windows.Forms.TextBox();
            this.lblTotalCGST = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.pnlDetailHeader = new System.Windows.Forms.Panel();
            this.txtItemDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIGST = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSGST = new System.Windows.Forms.TextBox();
            this.lblCGST = new System.Windows.Forms.Label();
            this.txtCGst = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblRate = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.cmbAccountNo = new System.Windows.Forms.ComboBox();
            this.lblBankAccountNumber = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.btnShowVoucher = new System.Windows.Forms.Button();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtInvoiceId = new System.Windows.Forms.TextBox();
            this.lblVouchderId = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.flowPanelErrorMessage = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnTender = new System.Windows.Forms.Button();
            this.pnlTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.pnlDetailInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlDetailHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Location = new System.Drawing.Point(3, 3);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(6);
            this.pnlTitle.Size = new System.Drawing.Size(1509, 52);
            // 
            // heading1
            // 
            this.heading1.Margin = new System.Windows.Forms.Padding(8);
            this.heading1.Size = new System.Drawing.Size(1509, 52);
            this.heading1.Title = "Invoice";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.btnTender);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 902);
            this.panel1.Size = new System.Drawing.Size(1509, 69);
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.pnlData.Controls.Add(this.pnlDetailInfo);
            this.pnlData.Controls.Add(this.pnlInfo);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(3, 55);
            this.pnlData.Margin = new System.Windows.Forms.Padding(5);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1509, 847);
            this.pnlData.TabIndex = 6;
            // 
            // pnlDetailInfo
            // 
            this.pnlDetailInfo.Controls.Add(this.dgvData);
            this.pnlDetailInfo.Controls.Add(this.pnlFooter);
            this.pnlDetailInfo.Controls.Add(this.pnlDetailHeader);
            this.pnlDetailInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailInfo.Location = new System.Drawing.Point(0, 111);
            this.pnlDetailInfo.Margin = new System.Windows.Forms.Padding(5);
            this.pnlDetailInfo.Name = "pnlDetailInfo";
            this.pnlDetailInfo.Size = new System.Drawing.Size(1509, 736);
            this.pnlDetailInfo.TabIndex = 36;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgvData.Location = new System.Drawing.Point(0, 197);
            this.dgvData.Margin = new System.Windows.Forms.Padding(5);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 62;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1509, 442);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentDoubleClick);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.txtTotalIGST);
            this.pnlFooter.Controls.Add(this.lblIGST);
            this.pnlFooter.Controls.Add(this.txtNetAmount);
            this.pnlFooter.Controls.Add(this.lblNetAmount);
            this.pnlFooter.Controls.Add(this.txtTotalSGST);
            this.pnlFooter.Controls.Add(this.lblTotalSGST);
            this.pnlFooter.Controls.Add(this.txtTotalCGST);
            this.pnlFooter.Controls.Add(this.lblTotalCGST);
            this.pnlFooter.Controls.Add(this.txtTotalAmount);
            this.pnlFooter.Controls.Add(this.lblTotalAmount);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 639);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(5);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1509, 97);
            this.pnlFooter.TabIndex = 35;
            // 
            // txtTotalIGST
            // 
            this.txtTotalIGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalIGST.Location = new System.Drawing.Point(965, 48);
            this.txtTotalIGST.Margin = new System.Windows.Forms.Padding(5);
            this.txtTotalIGST.Name = "txtTotalIGST";
            this.txtTotalIGST.Size = new System.Drawing.Size(173, 31);
            this.txtTotalIGST.TabIndex = 52;
            this.txtTotalIGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIGST
            // 
            this.lblIGST.AutoSize = true;
            this.lblIGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblIGST.Location = new System.Drawing.Point(968, 19);
            this.lblIGST.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblIGST.Name = "lblIGST";
            this.lblIGST.Size = new System.Drawing.Size(117, 25);
            this.lblIGST.TabIndex = 51;
            this.lblIGST.Text = "Total IGST";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNetAmount.Location = new System.Drawing.Point(1285, 48);
            this.txtNetAmount.Margin = new System.Windows.Forms.Padding(5);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.Size = new System.Drawing.Size(173, 31);
            this.txtNetAmount.TabIndex = 50;
            this.txtNetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.AutoSize = true;
            this.lblNetAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblNetAmount.Location = new System.Drawing.Point(1289, 19);
            this.lblNetAmount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Size = new System.Drawing.Size(133, 25);
            this.lblNetAmount.TabIndex = 49;
            this.lblNetAmount.Text = "Net Amount";
            // 
            // txtTotalSGST
            // 
            this.txtTotalSGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalSGST.Location = new System.Drawing.Point(645, 48);
            this.txtTotalSGST.Margin = new System.Windows.Forms.Padding(5);
            this.txtTotalSGST.Name = "txtTotalSGST";
            this.txtTotalSGST.Size = new System.Drawing.Size(173, 31);
            this.txtTotalSGST.TabIndex = 48;
            this.txtTotalSGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalSGST
            // 
            this.lblTotalSGST.AutoSize = true;
            this.lblTotalSGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblTotalSGST.Location = new System.Drawing.Point(650, 19);
            this.lblTotalSGST.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalSGST.Name = "lblTotalSGST";
            this.lblTotalSGST.Size = new System.Drawing.Size(123, 25);
            this.lblTotalSGST.TabIndex = 47;
            this.lblTotalSGST.Text = "Total SGST";
            // 
            // txtTotalCGST
            // 
            this.txtTotalCGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalCGST.Location = new System.Drawing.Point(325, 48);
            this.txtTotalCGST.Margin = new System.Windows.Forms.Padding(5);
            this.txtTotalCGST.Name = "txtTotalCGST";
            this.txtTotalCGST.Size = new System.Drawing.Size(173, 31);
            this.txtTotalCGST.TabIndex = 46;
            this.txtTotalCGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalCGST
            // 
            this.lblTotalCGST.AutoSize = true;
            this.lblTotalCGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblTotalCGST.Location = new System.Drawing.Point(330, 19);
            this.lblTotalCGST.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalCGST.Name = "lblTotalCGST";
            this.lblTotalCGST.Size = new System.Drawing.Size(123, 25);
            this.lblTotalCGST.TabIndex = 42;
            this.lblTotalCGST.Text = "Total CGST";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmount.Location = new System.Drawing.Point(5, 48);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(5);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(173, 31);
            this.txtTotalAmount.TabIndex = 41;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(8, 19);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(146, 25);
            this.lblTotalAmount.TabIndex = 40;
            this.lblTotalAmount.Text = "Total Amount";
            // 
            // pnlDetailHeader
            // 
            this.pnlDetailHeader.Controls.Add(this.txtItemDescription);
            this.pnlDetailHeader.Controls.Add(this.label2);
            this.pnlDetailHeader.Controls.Add(this.txtIGST);
            this.pnlDetailHeader.Controls.Add(this.label1);
            this.pnlDetailHeader.Controls.Add(this.txtSGST);
            this.pnlDetailHeader.Controls.Add(this.lblCGST);
            this.pnlDetailHeader.Controls.Add(this.txtCGst);
            this.pnlDetailHeader.Controls.Add(this.lblAmount);
            this.pnlDetailHeader.Controls.Add(this.txtAmount);
            this.pnlDetailHeader.Controls.Add(this.lblRate);
            this.pnlDetailHeader.Controls.Add(this.btnSave);
            this.pnlDetailHeader.Controls.Add(this.lblUnit);
            this.pnlDetailHeader.Controls.Add(this.txtUnit);
            this.pnlDetailHeader.Controls.Add(this.lblQty);
            this.pnlDetailHeader.Controls.Add(this.txtRate);
            this.pnlDetailHeader.Controls.Add(this.lblItemName);
            this.pnlDetailHeader.Controls.Add(this.txtQuantity);
            this.pnlDetailHeader.Controls.Add(this.txtItemName);
            this.pnlDetailHeader.Controls.Add(this.label3);
            this.pnlDetailHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDetailHeader.Margin = new System.Windows.Forms.Padding(5);
            this.pnlDetailHeader.Name = "pnlDetailHeader";
            this.pnlDetailHeader.Size = new System.Drawing.Size(1509, 197);
            this.pnlDetailHeader.TabIndex = 34;
            // 
            // txtItemDescription
            // 
            this.txtItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemDescription.Location = new System.Drawing.Point(146, 86);
            this.txtItemDescription.Margin = new System.Windows.Forms.Padding(5);
            this.txtItemDescription.Multiline = true;
            this.txtItemDescription.Name = "txtItemDescription";
            this.txtItemDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtItemDescription.Size = new System.Drawing.Size(1218, 99);
            this.txtItemDescription.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(1061, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 50;
            this.label2.Text = "IGST(5%)";
            // 
            // txtIGST
            // 
            this.txtIGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIGST.Location = new System.Drawing.Point(1066, 42);
            this.txtIGST.Margin = new System.Windows.Forms.Padding(5);
            this.txtIGST.Name = "txtIGST";
            this.txtIGST.Size = new System.Drawing.Size(147, 31);
            this.txtIGST.TabIndex = 11;
            this.txtIGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(920, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 48;
            this.label1.Text = "SGST(2.5%)";
            // 
            // txtSGST
            // 
            this.txtSGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSGST.Location = new System.Drawing.Point(915, 42);
            this.txtSGST.Margin = new System.Windows.Forms.Padding(5);
            this.txtSGST.Name = "txtSGST";
            this.txtSGST.Size = new System.Drawing.Size(147, 31);
            this.txtSGST.TabIndex = 10;
            this.txtSGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCGST
            // 
            this.lblCGST.AutoSize = true;
            this.lblCGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCGST.Location = new System.Drawing.Point(769, 12);
            this.lblCGST.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCGST.Name = "lblCGST";
            this.lblCGST.Size = new System.Drawing.Size(141, 25);
            this.lblCGST.TabIndex = 46;
            this.lblCGST.Text = "CGST(2.5%)";
            // 
            // txtCGst
            // 
            this.txtCGst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCGst.Location = new System.Drawing.Point(764, 42);
            this.txtCGst.Margin = new System.Windows.Forms.Padding(5);
            this.txtCGst.Name = "txtCGst";
            this.txtCGst.Size = new System.Drawing.Size(147, 31);
            this.txtCGst.TabIndex = 9;
            this.txtCGst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblAmount.Location = new System.Drawing.Point(1222, 12);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(91, 25);
            this.lblAmount.TabIndex = 44;
            this.lblAmount.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Location = new System.Drawing.Point(1217, 42);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(5);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(147, 31);
            this.txtAmount.TabIndex = 12;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Leave += new System.EventHandler(this.txtItemName_Leave);
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblRate.Location = new System.Drawing.Point(618, 12);
            this.lblRate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(58, 25);
            this.lblRate.TabIndex = 42;
            this.lblRate.Text = "Rate";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1386, 37);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 56);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblUnit.Location = new System.Drawing.Point(466, 12);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(54, 25);
            this.lblUnit.TabIndex = 41;
            this.lblUnit.Text = "Unit";
            // 
            // txtUnit
            // 
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnit.Location = new System.Drawing.Point(462, 42);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(5);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(147, 31);
            this.txtUnit.TabIndex = 7;
            this.txtUnit.TabStop = false;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblQty.Location = new System.Drawing.Point(372, 12);
            this.lblQty.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(53, 25);
            this.lblQty.TabIndex = 40;
            this.lblQty.Text = "Qty.";
            // 
            // txtRate
            // 
            this.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRate.Location = new System.Drawing.Point(613, 42);
            this.txtRate.Margin = new System.Windows.Forms.Padding(5);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(147, 31);
            this.txtRate.TabIndex = 8;
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.Leave += new System.EventHandler(this.txtItemName_Leave);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblItemName.Location = new System.Drawing.Point(8, 12);
            this.lblItemName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(124, 25);
            this.lblItemName.TabIndex = 39;
            this.lblItemName.Text = "Item Name";
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Location = new System.Drawing.Point(367, 42);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(5);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(90, 31);
            this.txtQuantity.TabIndex = 6;
            this.txtQuantity.TabStop = false;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtItemName
            // 
            this.txtItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemName.Location = new System.Drawing.Point(5, 42);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(5);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(358, 31);
            this.txtItemName.TabIndex = 5;
            this.txtItemName.Leave += new System.EventHandler(this.txtItemName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 25);
            this.label3.TabIndex = 52;
            this.label3.Text = "Description";
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.cmbAccountNo);
            this.pnlInfo.Controls.Add(this.lblBankAccountNumber);
            this.pnlInfo.Controls.Add(this.cmbBank);
            this.pnlInfo.Controls.Add(this.lblBank);
            this.pnlInfo.Controls.Add(this.btnShowVoucher);
            this.pnlInfo.Controls.Add(this.cmbCustomer);
            this.pnlInfo.Controls.Add(this.lblCustomer);
            this.pnlInfo.Controls.Add(this.txtInvoiceId);
            this.pnlInfo.Controls.Add(this.lblVouchderId);
            this.pnlInfo.Controls.Add(this.lblInvoiceNo);
            this.pnlInfo.Controls.Add(this.txtInvoiceNo);
            this.pnlInfo.Controls.Add(this.lblDate);
            this.pnlInfo.Controls.Add(this.dtpInvoiceDate);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Margin = new System.Windows.Forms.Padding(5);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(1509, 111);
            this.pnlInfo.TabIndex = 0;
            // 
            // cmbAccountNo
            // 
            this.cmbAccountNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountNo.FormattingEnabled = true;
            this.cmbAccountNo.Location = new System.Drawing.Point(1042, 64);
            this.cmbAccountNo.Margin = new System.Windows.Forms.Padding(5);
            this.cmbAccountNo.Name = "cmbAccountNo";
            this.cmbAccountNo.Size = new System.Drawing.Size(410, 33);
            this.cmbAccountNo.TabIndex = 4;
            // 
            // lblBankAccountNumber
            // 
            this.lblBankAccountNumber.AutoSize = true;
            this.lblBankAccountNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblBankAccountNumber.Location = new System.Drawing.Point(881, 69);
            this.lblBankAccountNumber.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBankAccountNumber.Name = "lblBankAccountNumber";
            this.lblBankAccountNumber.Size = new System.Drawing.Size(142, 25);
            this.lblBankAccountNumber.TabIndex = 54;
            this.lblBankAccountNumber.Text = "Account No.:";
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(447, 59);
            this.cmbBank.Margin = new System.Windows.Forms.Padding(5);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(423, 33);
            this.cmbBank.TabIndex = 3;
            this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.cmbBank_SelectedIndexChanged);
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblBank.Location = new System.Drawing.Point(370, 64);
            this.lblBank.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(72, 25);
            this.lblBank.TabIndex = 52;
            this.lblBank.Text = "Bank:";
            // 
            // btnShowVoucher
            // 
            this.btnShowVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnShowVoucher.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnShowVoucher.FlatAppearance.BorderSize = 2;
            this.btnShowVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowVoucher.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowVoucher.ForeColor = System.Drawing.Color.White;
            this.btnShowVoucher.Location = new System.Drawing.Point(1251, 11);
            this.btnShowVoucher.Margin = new System.Windows.Forms.Padding(0);
            this.btnShowVoucher.Name = "btnShowVoucher";
            this.btnShowVoucher.Size = new System.Drawing.Size(203, 41);
            this.btnShowVoucher.TabIndex = 2;
            this.btnShowVoucher.Text = "Show &Voucher";
            this.btnShowVoucher.UseVisualStyleBackColor = false;
            this.btnShowVoucher.Click += new System.EventHandler(this.btnShowVoucher_Click);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(691, 11);
            this.cmbCustomer.Margin = new System.Windows.Forms.Padding(5);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(553, 33);
            this.cmbCustomer.TabIndex = 1;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCustomer.Location = new System.Drawing.Point(561, 17);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(118, 25);
            this.lblCustomer.TabIndex = 38;
            this.lblCustomer.Text = "Customer:";
            // 
            // txtInvoiceId
            // 
            this.txtInvoiceId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceId.Location = new System.Drawing.Point(422, 13);
            this.txtInvoiceId.Margin = new System.Windows.Forms.Padding(5);
            this.txtInvoiceId.Name = "txtInvoiceId";
            this.txtInvoiceId.Size = new System.Drawing.Size(119, 31);
            this.txtInvoiceId.TabIndex = 34;
            this.txtInvoiceId.Visible = false;
            // 
            // lblVouchderId
            // 
            this.lblVouchderId.AutoSize = true;
            this.lblVouchderId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblVouchderId.Location = new System.Drawing.Point(372, 18);
            this.lblVouchderId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVouchderId.Name = "lblVouchderId";
            this.lblVouchderId.Size = new System.Drawing.Size(41, 25);
            this.lblVouchderId.TabIndex = 37;
            this.lblVouchderId.Text = "Id:";
            this.lblVouchderId.Visible = false;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblInvoiceNo.Location = new System.Drawing.Point(6, 62);
            this.lblInvoiceNo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(126, 25);
            this.lblInvoiceNo.TabIndex = 36;
            this.lblInvoiceNo.Text = "Invoice No.";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Location = new System.Drawing.Point(146, 58);
            this.txtInvoiceNo.Margin = new System.Windows.Forms.Padding(5);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(204, 31);
            this.txtInvoiceNo.TabIndex = 32;
            this.txtInvoiceNo.Text = "30-DEC-2025-1";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblDate.Location = new System.Drawing.Point(67, 17);
            this.lblDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(68, 25);
            this.lblDate.TabIndex = 35;
            this.lblDate.Text = "Date:";
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(146, 12);
            this.dtpInvoiceDate.Margin = new System.Windows.Forms.Padding(5);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(163, 31);
            this.dtpInvoiceDate.TabIndex = 0;
            // 
            // flowPanelErrorMessage
            // 
            this.flowPanelErrorMessage.AutoSize = true;
            this.flowPanelErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPanelErrorMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowPanelErrorMessage.Location = new System.Drawing.Point(3, 55);
            this.flowPanelErrorMessage.Margin = new System.Windows.Forms.Padding(5);
            this.flowPanelErrorMessage.Name = "flowPanelErrorMessage";
            this.flowPanelErrorMessage.Size = new System.Drawing.Size(1509, 2);
            this.flowPanelErrorMessage.TabIndex = 16;
            this.flowPanelErrorMessage.Visible = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1309, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 48);
            this.button2.TabIndex = 16;
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
            this.button1.Location = new System.Drawing.Point(1105, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 48);
            this.button1.TabIndex = 15;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnPrint.FlatAppearance.BorderSize = 2;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(13, 9);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(203, 48);
            this.btnPrint.TabIndex = 52;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnTender
            // 
            this.btnTender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTender.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnTender.FlatAppearance.BorderSize = 2;
            this.btnTender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTender.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTender.ForeColor = System.Drawing.Color.White;
            this.btnTender.Location = new System.Drawing.Point(250, 9);
            this.btnTender.Margin = new System.Windows.Forms.Padding(0);
            this.btnTender.Name = "btnTender";
            this.btnTender.Size = new System.Drawing.Size(203, 48);
            this.btnTender.TabIndex = 53;
            this.btnTender.Text = "&Apply Tender";
            this.btnTender.UseVisualStyleBackColor = false;
            this.btnTender.Visible = false;
            this.btnTender.Click += new System.EventHandler(this.btnTender_Click);
            // 
            // frmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 974);
            this.Controls.Add(this.flowPanelErrorMessage);
            this.Controls.Add(this.pnlData);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmInvoice";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInvoice";
            this.Load += new System.EventHandler(this.frmInvoice_Load);
            this.Controls.SetChildIndex(this.pnlTitle, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlData, 0);
            this.Controls.SetChildIndex(this.flowPanelErrorMessage, 0);
            this.pnlTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.pnlDetailInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlDetailHeader.ResumeLayout(false);
            this.pnlDetailHeader.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel flowPanelErrorMessage;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.TextBox txtInvoiceId;
        private System.Windows.Forms.Label lblVouchderId;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnShowVoucher;
        private System.Windows.Forms.Panel pnlDetailInfo;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel pnlDetailHeader;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCGST;
        private System.Windows.Forms.TextBox txtCGst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIGST;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSGST;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTotalSGST;
        private System.Windows.Forms.TextBox txtTotalCGST;
        private System.Windows.Forms.Label lblTotalCGST;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.TextBox txtTotalSGST;
        private System.Windows.Forms.TextBox txtTotalIGST;
        private System.Windows.Forms.Label lblIGST;
        private System.Windows.Forms.ComboBox cmbAccountNo;
        private System.Windows.Forms.Label lblBankAccountNumber;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtItemDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTender;
    }
}