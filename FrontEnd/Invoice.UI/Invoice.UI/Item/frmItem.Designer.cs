namespace Invoice.UI.Item
{
    partial class frmItem
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
            this.flowPanelErrorMessage = new System.Windows.Forms.Panel();
            this.pnlData = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radForInvoice = new Invoice.UI.CustomControl.CustomReadioButton();
            this.radForVoucher = new Invoice.UI.CustomControl.CustomReadioButton();
            this.lineControl2 = new Invoice.UI.CustomControl.LineControl();
            this.pnlTaxCategory = new System.Windows.Forms.Panel();
            this.radApplyGST = new Invoice.UI.CustomControl.CustomReadioButton();
            this.radNoGST = new Invoice.UI.CustomControl.CustomReadioButton();
            this.lineControl1 = new Invoice.UI.CustomControl.LineControl();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbInterval = new System.Windows.Forms.ComboBox();
            this.lblItemInterval = new System.Windows.Forms.Label();
            this.txtItemQuantity = new System.Windows.Forms.TextBox();
            this.lblItemQuanity = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTaxCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Location = new System.Drawing.Point(3, 3);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(6);
            this.pnlTitle.Size = new System.Drawing.Size(725, 52);
            // 
            // heading1
            // 
            this.heading1.Margin = new System.Windows.Forms.Padding(8);
            this.heading1.Size = new System.Drawing.Size(725, 52);
            this.heading1.Title = "Item";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 564);
            this.panel1.Size = new System.Drawing.Size(725, 66);
            // 
            // flowPanelErrorMessage
            // 
            this.flowPanelErrorMessage.AutoSize = true;
            this.flowPanelErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPanelErrorMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowPanelErrorMessage.Location = new System.Drawing.Point(3, 55);
            this.flowPanelErrorMessage.Margin = new System.Windows.Forms.Padding(5);
            this.flowPanelErrorMessage.Name = "flowPanelErrorMessage";
            this.flowPanelErrorMessage.Size = new System.Drawing.Size(725, 2);
            this.flowPanelErrorMessage.TabIndex = 6;
            this.flowPanelErrorMessage.Visible = false;
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.pnlData.Controls.Add(this.txtDescription);
            this.pnlData.Controls.Add(this.panel2);
            this.pnlData.Controls.Add(this.lineControl2);
            this.pnlData.Controls.Add(this.pnlTaxCategory);
            this.pnlData.Controls.Add(this.lineControl1);
            this.pnlData.Controls.Add(this.cmbType);
            this.pnlData.Controls.Add(this.label2);
            this.pnlData.Controls.Add(this.cmbInterval);
            this.pnlData.Controls.Add(this.lblItemInterval);
            this.pnlData.Controls.Add(this.txtItemQuantity);
            this.pnlData.Controls.Add(this.lblItemQuanity);
            this.pnlData.Controls.Add(this.lblUnit);
            this.pnlData.Controls.Add(this.cmbUnit);
            this.pnlData.Controls.Add(this.label1);
            this.pnlData.Controls.Add(this.txtRate);
            this.pnlData.Controls.Add(this.txtCompanyName);
            this.pnlData.Controls.Add(this.lblItemName);
            this.pnlData.Controls.Add(this.txtId);
            this.pnlData.Controls.Add(this.lblId);
            this.pnlData.Controls.Add(this.label3);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(3, 57);
            this.pnlData.Margin = new System.Windows.Forms.Padding(5);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(725, 507);
            this.pnlData.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtDescription.Location = new System.Drawing.Point(152, 73);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(5);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(560, 82);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Leave += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radForInvoice);
            this.panel2.Controls.Add(this.radForVoucher);
            this.panel2.Location = new System.Drawing.Point(245, 414);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 58);
            this.panel2.TabIndex = 54;
            // 
            // radForInvoice
            // 
            this.radForInvoice.Appearance = System.Windows.Forms.Appearance.Button;
            this.radForInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.radForInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radForInvoice.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radForInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.radForInvoice.Location = new System.Drawing.Point(240, 9);
            this.radForInvoice.Margin = new System.Windows.Forms.Padding(5);
            this.radForInvoice.Name = "radForInvoice";
            this.radForInvoice.Size = new System.Drawing.Size(216, 44);
            this.radForInvoice.TabIndex = 10;
            this.radForInvoice.Tag = "FOR_INVOICE";
            this.radForInvoice.Text = "INVOICE";
            this.radForInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radForInvoice.UseVisualStyleBackColor = false;
            this.radForInvoice.CheckedChanged += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // radForVoucher
            // 
            this.radForVoucher.Appearance = System.Windows.Forms.Appearance.Button;
            this.radForVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radForVoucher.Checked = true;
            this.radForVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radForVoucher.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radForVoucher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.radForVoucher.Location = new System.Drawing.Point(5, 9);
            this.radForVoucher.Margin = new System.Windows.Forms.Padding(5);
            this.radForVoucher.Name = "radForVoucher";
            this.radForVoucher.Size = new System.Drawing.Size(213, 44);
            this.radForVoucher.TabIndex = 9;
            this.radForVoucher.TabStop = true;
            this.radForVoucher.Tag = "FOR_VOUCHER";
            this.radForVoucher.Text = "VOUCHER";
            this.radForVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radForVoucher.UseVisualStyleBackColor = false;
            this.radForVoucher.CheckedChanged += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // lineControl2
            // 
            this.lineControl2.Location = new System.Drawing.Point(14, 386);
            this.lineControl2.Margin = new System.Windows.Forms.Padding(13, 10, 13, 10);
            this.lineControl2.Name = "lineControl2";
            this.lineControl2.Size = new System.Drawing.Size(681, 31);
            this.lineControl2.TabIndex = 53;
            this.lineControl2.Title = "Created For";
            // 
            // pnlTaxCategory
            // 
            this.pnlTaxCategory.Controls.Add(this.radApplyGST);
            this.pnlTaxCategory.Controls.Add(this.radNoGST);
            this.pnlTaxCategory.Location = new System.Drawing.Point(242, 317);
            this.pnlTaxCategory.Margin = new System.Windows.Forms.Padding(5);
            this.pnlTaxCategory.Name = "pnlTaxCategory";
            this.pnlTaxCategory.Size = new System.Drawing.Size(471, 58);
            this.pnlTaxCategory.TabIndex = 52;
            // 
            // radApplyGST
            // 
            this.radApplyGST.Appearance = System.Windows.Forms.Appearance.Button;
            this.radApplyGST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.radApplyGST.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radApplyGST.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radApplyGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.radApplyGST.Location = new System.Drawing.Point(240, 8);
            this.radApplyGST.Margin = new System.Windows.Forms.Padding(5);
            this.radApplyGST.Name = "radApplyGST";
            this.radApplyGST.Size = new System.Drawing.Size(218, 44);
            this.radApplyGST.TabIndex = 8;
            this.radApplyGST.Tag = "APPLY_GST";
            this.radApplyGST.Text = "APPLY GST";
            this.radApplyGST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radApplyGST.UseVisualStyleBackColor = false;
            this.radApplyGST.CheckedChanged += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // radNoGST
            // 
            this.radNoGST.Appearance = System.Windows.Forms.Appearance.Button;
            this.radNoGST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radNoGST.Checked = true;
            this.radNoGST.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radNoGST.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNoGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.radNoGST.Location = new System.Drawing.Point(7, 8);
            this.radNoGST.Margin = new System.Windows.Forms.Padding(5);
            this.radNoGST.Name = "radNoGST";
            this.radNoGST.Size = new System.Drawing.Size(208, 44);
            this.radNoGST.TabIndex = 7;
            this.radNoGST.TabStop = true;
            this.radNoGST.Tag = "NO_GST";
            this.radNoGST.Text = "NO GST";
            this.radNoGST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radNoGST.UseVisualStyleBackColor = false;
            this.radNoGST.CheckedChanged += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // lineControl1
            // 
            this.lineControl1.Location = new System.Drawing.Point(8, 281);
            this.lineControl1.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.lineControl1.Name = "lineControl1";
            this.lineControl1.Size = new System.Drawing.Size(700, 31);
            this.lineControl1.TabIndex = 51;
            this.lineControl1.Title = "Tax Detail";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(488, 168);
            this.cmbType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(188, 33);
            this.cmbType.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(412, 168);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Type:";
            // 
            // cmbInterval
            // 
            this.cmbInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterval.FormattingEnabled = true;
            this.cmbInterval.Location = new System.Drawing.Point(152, 169);
            this.cmbInterval.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbInterval.Name = "cmbInterval";
            this.cmbInterval.Size = new System.Drawing.Size(188, 33);
            this.cmbInterval.TabIndex = 3;
            // 
            // lblItemInterval
            // 
            this.lblItemInterval.AutoSize = true;
            this.lblItemInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblItemInterval.Location = new System.Drawing.Point(40, 168);
            this.lblItemInterval.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblItemInterval.Name = "lblItemInterval";
            this.lblItemInterval.Size = new System.Drawing.Size(101, 25);
            this.lblItemInterval.TabIndex = 18;
            this.lblItemInterval.Text = "Interval:";
            // 
            // txtItemQuantity
            // 
            this.txtItemQuantity.BackColor = System.Drawing.Color.White;
            this.txtItemQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtItemQuantity.Location = new System.Drawing.Point(489, 221);
            this.txtItemQuantity.Margin = new System.Windows.Forms.Padding(5);
            this.txtItemQuantity.Name = "txtItemQuantity";
            this.txtItemQuantity.Size = new System.Drawing.Size(153, 31);
            this.txtItemQuantity.TabIndex = 6;
            this.txtItemQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtItemQuantity.Leave += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // lblItemQuanity
            // 
            this.lblItemQuanity.AutoSize = true;
            this.lblItemQuanity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblItemQuanity.Location = new System.Drawing.Point(370, 221);
            this.lblItemQuanity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblItemQuanity.Name = "lblItemQuanity";
            this.lblItemQuanity.Size = new System.Drawing.Size(109, 25);
            this.lblItemQuanity.TabIndex = 16;
            this.lblItemQuanity.Text = "Quantity:";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblUnit.Location = new System.Drawing.Point(192, 483);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(117, 25);
            this.lblUnit.TabIndex = 15;
            this.lblUnit.Text = "Item Unit:";
            this.lblUnit.Visible = false;
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Items.AddRange(new object[] {
            "NOs",
            "MONTHLY",
            "HOURLY",
            "DAILY",
            "KM"});
            this.cmbUnit.Location = new System.Drawing.Point(320, 476);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(224, 33);
            this.cmbUnit.TabIndex = 14;
            this.cmbUnit.Visible = false;
            this.cmbUnit.Leave += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(20, 227);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Item Rate:";
            // 
            // txtRate
            // 
            this.txtRate.BackColor = System.Drawing.Color.White;
            this.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtRate.Location = new System.Drawing.Point(152, 221);
            this.txtRate.Margin = new System.Windows.Forms.Padding(5);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(188, 31);
            this.txtRate.TabIndex = 5;
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.Leave += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.Color.White;
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCompanyName.Location = new System.Drawing.Point(152, 28);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(5);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(561, 31);
            this.txtCompanyName.TabIndex = 1;
            this.txtCompanyName.Leave += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblItemName.Location = new System.Drawing.Point(8, 33);
            this.lblItemName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(133, 25);
            this.lblItemName.TabIndex = 9;
            this.lblItemName.Text = "Item Name:";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtId.Location = new System.Drawing.Point(552, 476);
            this.txtId.Margin = new System.Windows.Forms.Padding(5);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(74, 31);
            this.txtId.TabIndex = 8;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtId.Visible = false;
            this.txtId.Leave += new System.EventHandler(this.txtCompanyName_Leave);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblId.Location = new System.Drawing.Point(636, 478);
            this.lblId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(41, 25);
            this.lblId.TabIndex = 7;
            this.lblId.Text = "Id:";
            this.lblId.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(8, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 25);
            this.label3.TabIndex = 56;
            this.label3.Text = "Description :";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(516, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 48);
            this.button2.TabIndex = 12;
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
            this.button1.Location = new System.Drawing.Point(311, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 48);
            this.button1.TabIndex = 11;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 633);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.flowPanelErrorMessage);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmItem";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmItem_Load);
            this.Controls.SetChildIndex(this.pnlTitle, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.flowPanelErrorMessage, 0);
            this.Controls.SetChildIndex(this.pnlData, 0);
            this.pnlTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlTaxCategory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel flowPanelErrorMessage;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.TextBox txtItemQuantity;
        private System.Windows.Forms.Label lblItemQuanity;
        private System.Windows.Forms.ComboBox cmbInterval;
        private System.Windows.Forms.Label lblItemInterval;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label2;
        private CustomControl.LineControl lineControl1;
        private System.Windows.Forms.Panel pnlTaxCategory;
        private CustomControl.CustomReadioButton radApplyGST;
        private CustomControl.CustomReadioButton radNoGST;
        private System.Windows.Forms.Panel panel2;
        private CustomControl.CustomReadioButton radForInvoice;
        private CustomControl.CustomReadioButton radForVoucher;
        private CustomControl.LineControl lineControl2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
    }
}