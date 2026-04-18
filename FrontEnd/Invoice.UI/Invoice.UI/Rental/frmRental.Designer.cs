namespace Invoice.UI.Rental
{
    partial class frmRental
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
            this.lblFromDate = new System.Windows.Forms.Label();
            this.pnlData = new System.Windows.Forms.Panel();
            this.pnlDetailInfo = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlDetailHeader = new System.Windows.Forms.Panel();
            this.txtItemDescription = new System.Windows.Forms.TextBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
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
            this.label2 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.txtVisitorName = new System.Windows.Forms.TextBox();
            this.maskEndFrom = new System.Windows.Forms.MaskedTextBox();
            this.maskStartFrom = new System.Windows.Forms.MaskedTextBox();
            this.pnlTaxCategory = new System.Windows.Forms.Panel();
            this.radTime = new Invoice.UI.CustomControl.CustomReadioButton();
            this.radKM = new Invoice.UI.CustomControl.CustomReadioButton();
            this.radNone = new Invoice.UI.CustomControl.CustomReadioButton();
            this.lblBillingWorkType = new System.Windows.Forms.Label();
            this.lblEndFrom = new System.Windows.Forms.Label();
            this.lblVisitorName = new System.Windows.Forms.Label();
            this.lblStartFrom = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.txtTotalDays = new System.Windows.Forms.TextBox();
            this.txtVoucherId = new System.Windows.Forms.TextBox();
            this.lblVouchderId = new System.Windows.Forms.Label();
            this.lblVoucherNo = new System.Windows.Forms.Label();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.lblDriver = new System.Windows.Forms.Label();
            this.cmbDriver = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpVoucherDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.cmbVehicleType = new System.Windows.Forms.ComboBox();
            this.lblRegistrationNo = new System.Windows.Forms.Label();
            this.txtDropLocation = new System.Windows.Forms.TextBox();
            this.cmbRegistration = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPickup = new System.Windows.Forms.Label();
            this.txtPickupLocation = new System.Windows.Forms.TextBox();
            this.flowPanelErrorMessage = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblVoucherStatus = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.pnlDetailInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlDetailHeader.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlTaxCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Location = new System.Drawing.Point(3, 3);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(6);
            this.pnlTitle.Size = new System.Drawing.Size(1179, 52);
            // 
            // heading1
            // 
            this.heading1.Margin = new System.Windows.Forms.Padding(8);
            this.heading1.Size = new System.Drawing.Size(1179, 52);
            this.heading1.Title = "Rental";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.lblVoucherStatus);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 962);
            this.panel1.Size = new System.Drawing.Size(1179, 70);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblFromDate.Location = new System.Drawing.Point(45, 18);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(127, 25);
            this.lblFromDate.TabIndex = 7;
            this.lblFromDate.Text = "From Date:";
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.pnlData.Controls.Add(this.pnlDetailInfo);
            this.pnlData.Controls.Add(this.pnlHeader);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(3, 55);
            this.pnlData.Margin = new System.Windows.Forms.Padding(5);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1179, 907);
            this.pnlData.TabIndex = 8;
            // 
            // pnlDetailInfo
            // 
            this.pnlDetailInfo.Controls.Add(this.dgvData);
            this.pnlDetailInfo.Controls.Add(this.pnlDetailHeader);
            this.pnlDetailInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailInfo.Location = new System.Drawing.Point(0, 316);
            this.pnlDetailInfo.Margin = new System.Windows.Forms.Padding(5);
            this.pnlDetailInfo.Name = "pnlDetailInfo";
            this.pnlDetailInfo.Size = new System.Drawing.Size(1179, 591);
            this.pnlDetailInfo.TabIndex = 35;
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
            this.dgvData.Location = new System.Drawing.Point(0, 207);
            this.dgvData.Margin = new System.Windows.Forms.Padding(5);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 62;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1179, 384);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvData_KeyDown);
            // 
            // pnlDetailHeader
            // 
            this.pnlDetailHeader.Controls.Add(this.txtItemDescription);
            this.pnlDetailHeader.Controls.Add(this.lblInterval);
            this.pnlDetailHeader.Controls.Add(this.txtInterval);
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
            this.pnlDetailHeader.Controls.Add(this.label2);
            this.pnlDetailHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDetailHeader.Margin = new System.Windows.Forms.Padding(5);
            this.pnlDetailHeader.Name = "pnlDetailHeader";
            this.pnlDetailHeader.Size = new System.Drawing.Size(1179, 207);
            this.pnlDetailHeader.TabIndex = 34;
            // 
            // txtItemDescription
            // 
            this.txtItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemDescription.Location = new System.Drawing.Point(148, 83);
            this.txtItemDescription.Margin = new System.Windows.Forms.Padding(5);
            this.txtItemDescription.Multiline = true;
            this.txtItemDescription.Name = "txtItemDescription";
            this.txtItemDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtItemDescription.Size = new System.Drawing.Size(925, 116);
            this.txtItemDescription.TabIndex = 47;
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblInterval.Location = new System.Drawing.Point(626, 12);
            this.lblInterval.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(92, 25);
            this.lblInterval.TabIndex = 46;
            this.lblInterval.Text = "Interval";
            // 
            // txtInterval
            // 
            this.txtInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInterval.Location = new System.Drawing.Point(622, 42);
            this.txtInterval.Margin = new System.Windows.Forms.Padding(5);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.ReadOnly = true;
            this.txtInterval.Size = new System.Drawing.Size(147, 31);
            this.txtInterval.TabIndex = 45;
            this.txtInterval.TabStop = false;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblAmount.Location = new System.Drawing.Point(931, 12);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(91, 25);
            this.lblAmount.TabIndex = 44;
            this.lblAmount.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Location = new System.Drawing.Point(926, 42);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(5);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(147, 31);
            this.txtAmount.TabIndex = 43;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Leave += new System.EventHandler(this.cmbVehicleType_Leave);
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblRate.Location = new System.Drawing.Point(780, 12);
            this.lblRate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(58, 25);
            this.lblRate.TabIndex = 42;
            this.lblRate.Text = "Rate";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1082, 42);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblUnit.Location = new System.Drawing.Point(473, 12);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(54, 25);
            this.lblUnit.TabIndex = 41;
            this.lblUnit.Text = "Unit";
            // 
            // txtUnit
            // 
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnit.Location = new System.Drawing.Point(468, 42);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(5);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(147, 31);
            this.txtUnit.TabIndex = 2;
            this.txtUnit.TabStop = false;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblQty.Location = new System.Drawing.Point(375, 12);
            this.lblQty.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(53, 25);
            this.lblQty.TabIndex = 40;
            this.lblQty.Text = "Qty.";
            // 
            // txtRate
            // 
            this.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRate.Location = new System.Drawing.Point(775, 42);
            this.txtRate.Margin = new System.Windows.Forms.Padding(5);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(147, 31);
            this.txtRate.TabIndex = 3;
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.Leave += new System.EventHandler(this.cmbVehicleType_Leave);
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
            this.txtQuantity.Location = new System.Drawing.Point(370, 42);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(5);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(90, 31);
            this.txtQuantity.TabIndex = 1;
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
            this.txtItemName.TabIndex = 0;
            this.txtItemName.Leave += new System.EventHandler(this.cmbVehicleType_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(8, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 48;
            this.label2.Text = "Description";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.txtVisitorName);
            this.pnlHeader.Controls.Add(this.maskEndFrom);
            this.pnlHeader.Controls.Add(this.maskStartFrom);
            this.pnlHeader.Controls.Add(this.pnlTaxCategory);
            this.pnlHeader.Controls.Add(this.lblBillingWorkType);
            this.pnlHeader.Controls.Add(this.lblEndFrom);
            this.pnlHeader.Controls.Add(this.lblVisitorName);
            this.pnlHeader.Controls.Add(this.lblStartFrom);
            this.pnlHeader.Controls.Add(this.lblDays);
            this.pnlHeader.Controls.Add(this.txtTotalDays);
            this.pnlHeader.Controls.Add(this.txtVoucherId);
            this.pnlHeader.Controls.Add(this.lblVouchderId);
            this.pnlHeader.Controls.Add(this.lblVoucherNo);
            this.pnlHeader.Controls.Add(this.txtVoucherNo);
            this.pnlHeader.Controls.Add(this.lblDriver);
            this.pnlHeader.Controls.Add(this.cmbDriver);
            this.pnlHeader.Controls.Add(this.lblDate);
            this.pnlHeader.Controls.Add(this.dtpVoucherDate);
            this.pnlHeader.Controls.Add(this.lblFromDate);
            this.pnlHeader.Controls.Add(this.lblToDate);
            this.pnlHeader.Controls.Add(this.dtpFromDate);
            this.pnlHeader.Controls.Add(this.dateTimePicker1);
            this.pnlHeader.Controls.Add(this.lblCustomer);
            this.pnlHeader.Controls.Add(this.cmbCustomer);
            this.pnlHeader.Controls.Add(this.lblVehicleType);
            this.pnlHeader.Controls.Add(this.cmbVehicleType);
            this.pnlHeader.Controls.Add(this.lblRegistrationNo);
            this.pnlHeader.Controls.Add(this.txtDropLocation);
            this.pnlHeader.Controls.Add(this.cmbRegistration);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.lblPickup);
            this.pnlHeader.Controls.Add(this.txtPickupLocation);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1179, 316);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // txtVisitorName
            // 
            this.txtVisitorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVisitorName.Location = new System.Drawing.Point(616, 198);
            this.txtVisitorName.Margin = new System.Windows.Forms.Padding(5);
            this.txtVisitorName.Name = "txtVisitorName";
            this.txtVisitorName.Size = new System.Drawing.Size(228, 31);
            this.txtVisitorName.TabIndex = 55;
            // 
            // maskEndFrom
            // 
            this.maskEndFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskEndFrom.Enabled = false;
            this.maskEndFrom.Location = new System.Drawing.Point(873, 244);
            this.maskEndFrom.Margin = new System.Windows.Forms.Padding(5);
            this.maskEndFrom.Mask = "00:00";
            this.maskEndFrom.Name = "maskEndFrom";
            this.maskEndFrom.Size = new System.Drawing.Size(83, 31);
            this.maskEndFrom.TabIndex = 54;
            this.maskEndFrom.ValidatingType = typeof(System.DateTime);
            // 
            // maskStartFrom
            // 
            this.maskStartFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskStartFrom.Enabled = false;
            this.maskStartFrom.Location = new System.Drawing.Point(725, 244);
            this.maskStartFrom.Margin = new System.Windows.Forms.Padding(5);
            this.maskStartFrom.Mask = "00:00";
            this.maskStartFrom.Name = "maskStartFrom";
            this.maskStartFrom.Size = new System.Drawing.Size(80, 31);
            this.maskStartFrom.TabIndex = 53;
            this.maskStartFrom.ValidatingType = typeof(System.DateTime);
            // 
            // pnlTaxCategory
            // 
            this.pnlTaxCategory.Controls.Add(this.radTime);
            this.pnlTaxCategory.Controls.Add(this.radKM);
            this.pnlTaxCategory.Controls.Add(this.radNone);
            this.pnlTaxCategory.Location = new System.Drawing.Point(176, 245);
            this.pnlTaxCategory.Margin = new System.Windows.Forms.Padding(5);
            this.pnlTaxCategory.Name = "pnlTaxCategory";
            this.pnlTaxCategory.Size = new System.Drawing.Size(447, 48);
            this.pnlTaxCategory.TabIndex = 52;
            // 
            // radTime
            // 
            this.radTime.Appearance = System.Windows.Forms.Appearance.Button;
            this.radTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.radTime.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.radTime.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radTime.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.radTime.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.radTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radTime.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.radTime.Location = new System.Drawing.Point(297, 3);
            this.radTime.Margin = new System.Windows.Forms.Padding(5);
            this.radTime.Name = "radTime";
            this.radTime.Size = new System.Drawing.Size(141, 41);
            this.radTime.TabIndex = 15;
            this.radTime.Tag = "TIME";
            this.radTime.Text = "Time";
            this.radTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radTime.UseVisualStyleBackColor = false;
            this.radTime.CheckedChanged += new System.EventHandler(this.radKM_CheckedChanged);
            // 
            // radKM
            // 
            this.radKM.Appearance = System.Windows.Forms.Appearance.Button;
            this.radKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.radKM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.radKM.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radKM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.radKM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.radKM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radKM.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radKM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.radKM.Location = new System.Drawing.Point(153, 3);
            this.radKM.Margin = new System.Windows.Forms.Padding(5);
            this.radKM.Name = "radKM";
            this.radKM.Size = new System.Drawing.Size(141, 41);
            this.radKM.TabIndex = 14;
            this.radKM.Tag = "KM";
            this.radKM.Text = "Kilometer";
            this.radKM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radKM.UseVisualStyleBackColor = false;
            this.radKM.CheckedChanged += new System.EventHandler(this.radKM_CheckedChanged);
            // 
            // radNone
            // 
            this.radNone.Appearance = System.Windows.Forms.Appearance.Button;
            this.radNone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radNone.Checked = true;
            this.radNone.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.radNone.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radNone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.radNone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.radNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radNone.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.radNone.Location = new System.Drawing.Point(8, 3);
            this.radNone.Margin = new System.Windows.Forms.Padding(5);
            this.radNone.Name = "radNone";
            this.radNone.Size = new System.Drawing.Size(141, 41);
            this.radNone.TabIndex = 13;
            this.radNone.TabStop = true;
            this.radNone.Tag = "NONE";
            this.radNone.Text = "None";
            this.radNone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radNone.UseVisualStyleBackColor = false;
            this.radNone.CheckedChanged += new System.EventHandler(this.radKM_CheckedChanged);
            // 
            // lblBillingWorkType
            // 
            this.lblBillingWorkType.AutoSize = true;
            this.lblBillingWorkType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblBillingWorkType.Location = new System.Drawing.Point(46, 250);
            this.lblBillingWorkType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBillingWorkType.Name = "lblBillingWorkType";
            this.lblBillingWorkType.Size = new System.Drawing.Size(126, 25);
            this.lblBillingWorkType.TabIndex = 38;
            this.lblBillingWorkType.Text = "Work Type:";
            // 
            // lblEndFrom
            // 
            this.lblEndFrom.AutoSize = true;
            this.lblEndFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblEndFrom.Location = new System.Drawing.Point(821, 248);
            this.lblEndFrom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEndFrom.Name = "lblEndFrom";
            this.lblEndFrom.Size = new System.Drawing.Size(43, 25);
            this.lblEndFrom.TabIndex = 37;
            this.lblEndFrom.Text = "To:";
            // 
            // lblVisitorName
            // 
            this.lblVisitorName.AutoSize = true;
            this.lblVisitorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblVisitorName.Location = new System.Drawing.Point(455, 206);
            this.lblVisitorName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVisitorName.Name = "lblVisitorName";
            this.lblVisitorName.Size = new System.Drawing.Size(151, 25);
            this.lblVisitorName.TabIndex = 36;
            this.lblVisitorName.Text = "Visitor Name:";
            // 
            // lblStartFrom
            // 
            this.lblStartFrom.AutoSize = true;
            this.lblStartFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblStartFrom.Location = new System.Drawing.Point(647, 250);
            this.lblStartFrom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStartFrom.Name = "lblStartFrom";
            this.lblStartFrom.Size = new System.Drawing.Size(73, 25);
            this.lblStartFrom.TabIndex = 35;
            this.lblStartFrom.Text = "From:";
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblDays.Location = new System.Drawing.Point(360, 15);
            this.lblDays.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(70, 25);
            this.lblDays.TabIndex = 34;
            this.lblDays.Text = "Days:";
            // 
            // txtTotalDays
            // 
            this.txtTotalDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalDays.Location = new System.Drawing.Point(442, 10);
            this.txtTotalDays.Margin = new System.Windows.Forms.Padding(5);
            this.txtTotalDays.Name = "txtTotalDays";
            this.txtTotalDays.Size = new System.Drawing.Size(96, 31);
            this.txtTotalDays.TabIndex = 5;
            this.txtTotalDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalDays.Leave += new System.EventHandler(this.cmbVehicleType_Leave);
            // 
            // txtVoucherId
            // 
            this.txtVoucherId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherId.Location = new System.Drawing.Point(1045, 11);
            this.txtVoucherId.Margin = new System.Windows.Forms.Padding(5);
            this.txtVoucherId.Name = "txtVoucherId";
            this.txtVoucherId.Size = new System.Drawing.Size(119, 31);
            this.txtVoucherId.TabIndex = 2;
            this.txtVoucherId.Visible = false;
            // 
            // lblVouchderId
            // 
            this.lblVouchderId.AutoSize = true;
            this.lblVouchderId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblVouchderId.Location = new System.Drawing.Point(997, 16);
            this.lblVouchderId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVouchderId.Name = "lblVouchderId";
            this.lblVouchderId.Size = new System.Drawing.Size(41, 25);
            this.lblVouchderId.TabIndex = 31;
            this.lblVouchderId.Text = "Id:";
            this.lblVouchderId.Visible = false;
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblVoucherNo.Location = new System.Drawing.Point(576, 16);
            this.lblVoucherNo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(137, 25);
            this.lblVoucherNo.TabIndex = 30;
            this.lblVoucherNo.Text = "Voucher No:";
            this.lblVoucherNo.Visible = false;
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherNo.Location = new System.Drawing.Point(724, 13);
            this.txtVoucherNo.Margin = new System.Windows.Forms.Padding(5);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(204, 31);
            this.txtVoucherNo.TabIndex = 0;
            this.txtVoucherNo.Text = "30-DEC-2025-1";
            this.txtVoucherNo.Visible = false;
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblDriver.Location = new System.Drawing.Point(852, 156);
            this.lblDriver.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(84, 25);
            this.lblDriver.TabIndex = 27;
            this.lblDriver.Text = "Driver:";
            // 
            // cmbDriver
            // 
            this.cmbDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDriver.FormattingEnabled = true;
            this.cmbDriver.Location = new System.Drawing.Point(939, 150);
            this.cmbDriver.Margin = new System.Windows.Forms.Padding(5);
            this.cmbDriver.Name = "cmbDriver";
            this.cmbDriver.Size = new System.Drawing.Size(223, 33);
            this.cmbDriver.TabIndex = 7;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblDate.Location = new System.Drawing.Point(648, 59);
            this.lblDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(68, 25);
            this.lblDate.TabIndex = 25;
            this.lblDate.Text = "Date:";
            this.lblDate.Visible = false;
            // 
            // dtpVoucherDate
            // 
            this.dtpVoucherDate.CustomFormat = "";
            this.dtpVoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVoucherDate.Location = new System.Drawing.Point(725, 54);
            this.dtpVoucherDate.Margin = new System.Windows.Forms.Padding(5);
            this.dtpVoucherDate.Name = "dtpVoucherDate";
            this.dtpVoucherDate.Size = new System.Drawing.Size(163, 31);
            this.dtpVoucherDate.TabIndex = 1;
            this.dtpVoucherDate.Visible = false;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblToDate.Location = new System.Drawing.Point(72, 59);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(97, 25);
            this.lblToDate.TabIndex = 8;
            this.lblToDate.Text = "To Date:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(184, 13);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(5);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(163, 31);
            this.dtpFromDate.TabIndex = 3;
            this.dtpFromDate.Leave += new System.EventHandler(this.cmbVehicleType_Leave);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(184, 54);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(163, 31);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.Leave += new System.EventHandler(this.cmbVehicleType_Leave);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCustomer.Location = new System.Drawing.Point(57, 109);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(118, 25);
            this.lblCustomer.TabIndex = 11;
            this.lblCustomer.Text = "Customer:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(184, 106);
            this.cmbCustomer.Margin = new System.Windows.Forms.Padding(5);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(979, 33);
            this.cmbCustomer.TabIndex = 6;
            this.cmbCustomer.Leave += new System.EventHandler(this.cmbVehicleType_Leave);
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.AutoSize = true;
            this.lblVehicleType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblVehicleType.Location = new System.Drawing.Point(23, 158);
            this.lblVehicleType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(146, 25);
            this.lblVehicleType.TabIndex = 13;
            this.lblVehicleType.Text = "Vehicle Type:";
            // 
            // cmbVehicleType
            // 
            this.cmbVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehicleType.FormattingEnabled = true;
            this.cmbVehicleType.Location = new System.Drawing.Point(184, 153);
            this.cmbVehicleType.Margin = new System.Windows.Forms.Padding(5);
            this.cmbVehicleType.Name = "cmbVehicleType";
            this.cmbVehicleType.Size = new System.Drawing.Size(236, 33);
            this.cmbVehicleType.TabIndex = 8;
            this.cmbVehicleType.SelectedIndexChanged += new System.EventHandler(this.cmbVehicleType_SelectedIndexChanged);
            this.cmbVehicleType.Leave += new System.EventHandler(this.cmbVehicleType_Leave);
            // 
            // lblRegistrationNo
            // 
            this.lblRegistrationNo.AutoSize = true;
            this.lblRegistrationNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblRegistrationNo.Location = new System.Drawing.Point(437, 159);
            this.lblRegistrationNo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRegistrationNo.Name = "lblRegistrationNo";
            this.lblRegistrationNo.Size = new System.Drawing.Size(166, 25);
            this.lblRegistrationNo.TabIndex = 15;
            this.lblRegistrationNo.Text = "Registration #:";
            // 
            // txtDropLocation
            // 
            this.txtDropLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDropLocation.Location = new System.Drawing.Point(935, 198);
            this.txtDropLocation.Margin = new System.Windows.Forms.Padding(5);
            this.txtDropLocation.Name = "txtDropLocation";
            this.txtDropLocation.Size = new System.Drawing.Size(238, 31);
            this.txtDropLocation.TabIndex = 11;
            this.txtDropLocation.Visible = false;
            // 
            // cmbRegistration
            // 
            this.cmbRegistration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegistration.FormattingEnabled = true;
            this.cmbRegistration.Location = new System.Drawing.Point(616, 155);
            this.cmbRegistration.Margin = new System.Windows.Forms.Padding(5);
            this.cmbRegistration.Name = "cmbRegistration";
            this.cmbRegistration.Size = new System.Drawing.Size(222, 33);
            this.cmbRegistration.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(857, 204);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Drop:";
            this.label1.Visible = false;
            // 
            // lblPickup
            // 
            this.lblPickup.AutoSize = true;
            this.lblPickup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblPickup.Location = new System.Drawing.Point(34, 205);
            this.lblPickup.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPickup.Name = "lblPickup";
            this.lblPickup.Size = new System.Drawing.Size(134, 25);
            this.lblPickup.TabIndex = 21;
            this.lblPickup.Text = "Description:";
            // 
            // txtPickupLocation
            // 
            this.txtPickupLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPickupLocation.Location = new System.Drawing.Point(184, 200);
            this.txtPickupLocation.Margin = new System.Windows.Forms.Padding(5);
            this.txtPickupLocation.Name = "txtPickupLocation";
            this.txtPickupLocation.Size = new System.Drawing.Size(238, 31);
            this.txtPickupLocation.TabIndex = 10;
            // 
            // flowPanelErrorMessage
            // 
            this.flowPanelErrorMessage.AutoSize = true;
            this.flowPanelErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPanelErrorMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowPanelErrorMessage.Location = new System.Drawing.Point(3, 55);
            this.flowPanelErrorMessage.Margin = new System.Windows.Forms.Padding(5);
            this.flowPanelErrorMessage.Name = "flowPanelErrorMessage";
            this.flowPanelErrorMessage.Size = new System.Drawing.Size(1179, 2);
            this.flowPanelErrorMessage.TabIndex = 15;
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
            this.button2.Location = new System.Drawing.Point(971, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 48);
            this.button2.TabIndex = 1;
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
            this.button1.Location = new System.Drawing.Point(768, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblVoucherStatus
            // 
            this.lblVoucherStatus.AutoSize = true;
            this.lblVoucherStatus.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucherStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblVoucherStatus.Location = new System.Drawing.Point(6, 9);
            this.lblVoucherStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVoucherStatus.Name = "lblVoucherStatus";
            this.lblVoucherStatus.Size = new System.Drawing.Size(162, 49);
            this.lblVoucherStatus.TabIndex = 2;
            this.lblVoucherStatus.Text = "label3";
            // 
            // frmRental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1185, 1035);
            this.Controls.Add(this.flowPanelErrorMessage);
            this.Controls.Add(this.pnlData);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmRental";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmRental_Load);
            this.Controls.SetChildIndex(this.pnlTitle, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlData, 0);
            this.Controls.SetChildIndex(this.flowPanelErrorMessage, 0);
            this.pnlTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlData.ResumeLayout(false);
            this.pnlDetailInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlDetailHeader.ResumeLayout(false);
            this.pnlDetailHeader.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTaxCategory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel flowPanelErrorMessage;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.ComboBox cmbRegistration;
        private System.Windows.Forms.Label lblRegistrationNo;
        private System.Windows.Forms.ComboBox cmbVehicleType;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtDropLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPickupLocation;
        private System.Windows.Forms.Label lblPickup;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlDetailInfo;
        private System.Windows.Forms.Panel pnlDetailHeader;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.ComboBox cmbDriver;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpVoucherDate;
        private System.Windows.Forms.Label lblVoucherNo;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.TextBox txtVoucherId;
        private System.Windows.Forms.Label lblVouchderId;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.TextBox txtTotalDays;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblVoucherStatus;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.Label lblBillingWorkType;
        private System.Windows.Forms.Label lblEndFrom;
        private System.Windows.Forms.Label lblVisitorName;
        private System.Windows.Forms.Label lblStartFrom;
        private System.Windows.Forms.Panel pnlTaxCategory;
        private CustomControl.CustomReadioButton radTime;
        private CustomControl.CustomReadioButton radKM;
        private CustomControl.CustomReadioButton radNone;
        private System.Windows.Forms.MaskedTextBox maskStartFrom;
        private System.Windows.Forms.TextBox txtVisitorName;
        private System.Windows.Forms.MaskedTextBox maskEndFrom;
        private System.Windows.Forms.TextBox txtItemDescription;
        private System.Windows.Forms.Label label2;
    }
}