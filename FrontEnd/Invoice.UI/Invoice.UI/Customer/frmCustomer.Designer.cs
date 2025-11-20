namespace Invoice.UI.Customer
{
    partial class frmCustomer
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
            this.pnlData = new System.Windows.Forms.Panel();
            this.pnlInvoiceFomat = new System.Windows.Forms.Panel();
            this.radWithoutGST = new Invoice.UI.CustomControl.CustomReadioButton();
            this.radWithGST = new Invoice.UI.CustomControl.CustomReadioButton();
            this.lineControl2 = new Invoice.UI.CustomControl.LineControl();
            this.pnlTaxCategory = new System.Windows.Forms.Panel();
            this.radLUT = new Invoice.UI.CustomControl.CustomReadioButton();
            this.radRCM = new Invoice.UI.CustomControl.CustomReadioButton();
            this.radGST = new Invoice.UI.CustomControl.CustomReadioButton();
            this.lineControl1 = new Invoice.UI.CustomControl.LineControl();
            this.txtCess = new System.Windows.Forms.TextBox();
            this.lblCessNo = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPanNo = new System.Windows.Forms.Label();
            this.txtPan = new System.Windows.Forms.TextBox();
            this.txtGST = new System.Windows.Forms.TextBox();
            this.lblGST = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtAddress3 = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblAddress3 = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.btnAddRateInfo = new System.Windows.Forms.Button();
            this.flowPanelErrorMessage = new System.Windows.Forms.Panel();
            this.pnlTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.pnlInvoiceFomat.SuspendLayout();
            this.pnlTaxCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Location = new System.Drawing.Point(3, 3);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(6);
            this.pnlTitle.Size = new System.Drawing.Size(924, 52);
            // 
            // heading1
            // 
            this.heading1.Margin = new System.Windows.Forms.Padding(8);
            this.heading1.Size = new System.Drawing.Size(924, 52);
            this.heading1.Title = "Customer";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.btnAddRateInfo);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 568);
            this.panel1.Size = new System.Drawing.Size(924, 62);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(721, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 48);
            this.button2.TabIndex = 19;
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
            this.button1.Location = new System.Drawing.Point(516, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlData
            // 
            this.pnlData.AutoSize = true;
            this.pnlData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.pnlData.Controls.Add(this.pnlInvoiceFomat);
            this.pnlData.Controls.Add(this.lineControl2);
            this.pnlData.Controls.Add(this.pnlTaxCategory);
            this.pnlData.Controls.Add(this.lineControl1);
            this.pnlData.Controls.Add(this.txtCess);
            this.pnlData.Controls.Add(this.lblCessNo);
            this.pnlData.Controls.Add(this.txtZipCode);
            this.pnlData.Controls.Add(this.label2);
            this.pnlData.Controls.Add(this.txtPhone);
            this.pnlData.Controls.Add(this.label1);
            this.pnlData.Controls.Add(this.lblPanNo);
            this.pnlData.Controls.Add(this.txtPan);
            this.pnlData.Controls.Add(this.txtGST);
            this.pnlData.Controls.Add(this.lblGST);
            this.pnlData.Controls.Add(this.txtCountry);
            this.pnlData.Controls.Add(this.lblCountry);
            this.pnlData.Controls.Add(this.txtState);
            this.pnlData.Controls.Add(this.lblState);
            this.pnlData.Controls.Add(this.txtCity);
            this.pnlData.Controls.Add(this.lblCity);
            this.pnlData.Controls.Add(this.txtAddress3);
            this.pnlData.Controls.Add(this.txtAddress2);
            this.pnlData.Controls.Add(this.txtAddress1);
            this.pnlData.Controls.Add(this.txtId);
            this.pnlData.Controls.Add(this.lblId);
            this.pnlData.Controls.Add(this.txtCompanyName);
            this.pnlData.Controls.Add(this.lblAddress3);
            this.pnlData.Controls.Add(this.lblAddress2);
            this.pnlData.Controls.Add(this.lblAddress1);
            this.pnlData.Controls.Add(this.lblCustomerName);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(3, 55);
            this.pnlData.Margin = new System.Windows.Forms.Padding(5);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(924, 513);
            this.pnlData.TabIndex = 6;
            // 
            // pnlInvoiceFomat
            // 
            this.pnlInvoiceFomat.Controls.Add(this.radWithoutGST);
            this.pnlInvoiceFomat.Controls.Add(this.radWithGST);
            this.pnlInvoiceFomat.Location = new System.Drawing.Point(206, 439);
            this.pnlInvoiceFomat.Margin = new System.Windows.Forms.Padding(5);
            this.pnlInvoiceFomat.Name = "pnlInvoiceFomat";
            this.pnlInvoiceFomat.Size = new System.Drawing.Size(699, 53);
            this.pnlInvoiceFomat.TabIndex = 53;
            // 
            // radWithoutGST
            // 
            this.radWithoutGST.Appearance = System.Windows.Forms.Appearance.Button;
            this.radWithoutGST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.radWithoutGST.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radWithoutGST.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radWithoutGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.radWithoutGST.Location = new System.Drawing.Point(358, 5);
            this.radWithoutGST.Margin = new System.Windows.Forms.Padding(5);
            this.radWithoutGST.Name = "radWithoutGST";
            this.radWithoutGST.Size = new System.Drawing.Size(335, 44);
            this.radWithoutGST.TabIndex = 17;
            this.radWithoutGST.TabStop = true;
            this.radWithoutGST.Text = "GST Not Included";
            this.radWithoutGST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radWithoutGST.UseVisualStyleBackColor = false;
            // 
            // radWithGST
            // 
            this.radWithGST.Appearance = System.Windows.Forms.Appearance.Button;
            this.radWithGST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.radWithGST.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radWithGST.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radWithGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.radWithGST.Location = new System.Drawing.Point(6, 5);
            this.radWithGST.Margin = new System.Windows.Forms.Padding(5);
            this.radWithGST.Name = "radWithGST";
            this.radWithGST.Size = new System.Drawing.Size(335, 44);
            this.radWithGST.TabIndex = 16;
            this.radWithGST.TabStop = true;
            this.radWithGST.Text = "GST Included";
            this.radWithGST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radWithGST.UseVisualStyleBackColor = false;
            // 
            // lineControl2
            // 
            this.lineControl2.Location = new System.Drawing.Point(6, 412);
            this.lineControl2.Margin = new System.Windows.Forms.Padding(8);
            this.lineControl2.Name = "lineControl2";
            this.lineControl2.Size = new System.Drawing.Size(899, 31);
            this.lineControl2.TabIndex = 52;
            this.lineControl2.Title = "Invoice Format";
            // 
            // pnlTaxCategory
            // 
            this.pnlTaxCategory.Controls.Add(this.radLUT);
            this.pnlTaxCategory.Controls.Add(this.radRCM);
            this.pnlTaxCategory.Controls.Add(this.radGST);
            this.pnlTaxCategory.Location = new System.Drawing.Point(206, 355);
            this.pnlTaxCategory.Margin = new System.Windows.Forms.Padding(5);
            this.pnlTaxCategory.Name = "pnlTaxCategory";
            this.pnlTaxCategory.Size = new System.Drawing.Size(699, 58);
            this.pnlTaxCategory.TabIndex = 51;
            // 
            // radLUT
            // 
            this.radLUT.Appearance = System.Windows.Forms.Appearance.Button;
            this.radLUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.radLUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radLUT.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLUT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.radLUT.Location = new System.Drawing.Point(470, 8);
            this.radLUT.Margin = new System.Windows.Forms.Padding(5);
            this.radLUT.Name = "radLUT";
            this.radLUT.Size = new System.Drawing.Size(223, 44);
            this.radLUT.TabIndex = 15;
            this.radLUT.TabStop = true;
            this.radLUT.Tag = "LUT";
            this.radLUT.Text = "LUT";
            this.radLUT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radLUT.UseVisualStyleBackColor = false;
            this.radLUT.CheckedChanged += new System.EventHandler(this.radLUT_CheckedChanged);
            // 
            // radRCM
            // 
            this.radRCM.Appearance = System.Windows.Forms.Appearance.Button;
            this.radRCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.radRCM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radRCM.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRCM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.radRCM.Location = new System.Drawing.Point(239, 8);
            this.radRCM.Margin = new System.Windows.Forms.Padding(5);
            this.radRCM.Name = "radRCM";
            this.radRCM.Size = new System.Drawing.Size(223, 44);
            this.radRCM.TabIndex = 14;
            this.radRCM.TabStop = true;
            this.radRCM.Tag = "RCM";
            this.radRCM.Text = "RCM";
            this.radRCM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radRCM.UseVisualStyleBackColor = false;
            this.radRCM.CheckedChanged += new System.EventHandler(this.radLUT_CheckedChanged);
            // 
            // radGST
            // 
            this.radGST.Appearance = System.Windows.Forms.Appearance.Button;
            this.radGST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.radGST.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radGST.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.radGST.Location = new System.Drawing.Point(8, 8);
            this.radGST.Margin = new System.Windows.Forms.Padding(5);
            this.radGST.Name = "radGST";
            this.radGST.Size = new System.Drawing.Size(223, 44);
            this.radGST.TabIndex = 13;
            this.radGST.TabStop = true;
            this.radGST.Tag = "GST";
            this.radGST.Text = "GST";
            this.radGST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radGST.UseVisualStyleBackColor = false;
            this.radGST.CheckedChanged += new System.EventHandler(this.radLUT_CheckedChanged);
            // 
            // lineControl1
            // 
            this.lineControl1.Location = new System.Drawing.Point(6, 331);
            this.lineControl1.Margin = new System.Windows.Forms.Padding(6);
            this.lineControl1.Name = "lineControl1";
            this.lineControl1.Size = new System.Drawing.Size(899, 25);
            this.lineControl1.TabIndex = 50;
            this.lineControl1.Title = "Title";
            // 
            // txtCess
            // 
            this.txtCess.BackColor = System.Drawing.Color.White;
            this.txtCess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCess.Location = new System.Drawing.Point(630, 286);
            this.txtCess.Margin = new System.Windows.Forms.Padding(5);
            this.txtCess.Name = "txtCess";
            this.txtCess.Size = new System.Drawing.Size(273, 31);
            this.txtCess.TabIndex = 12;
            this.txtCess.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // lblCessNo
            // 
            this.lblCessNo.AutoSize = true;
            this.lblCessNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCessNo.Location = new System.Drawing.Point(548, 291);
            this.lblCessNo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCessNo.Name = "lblCessNo";
            this.lblCessNo.Size = new System.Drawing.Size(74, 25);
            this.lblCessNo.TabIndex = 48;
            this.lblCessNo.Text = "Cess: ";
            // 
            // txtZipCode
            // 
            this.txtZipCode.BackColor = System.Drawing.Color.White;
            this.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZipCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtZipCode.Location = new System.Drawing.Point(206, 192);
            this.txtZipCode.Margin = new System.Windows.Forms.Padding(5);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(153, 31);
            this.txtZipCode.TabIndex = 6;
            this.txtZipCode.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(96, 198);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 46;
            this.label2.Text = "ZipCode:";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPhone.Location = new System.Drawing.Point(206, 286);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(330, 31);
            this.txtPhone.TabIndex = 11;
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(80, 289);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 44;
            this.label1.Text = "Phone No:";
            // 
            // lblPanNo
            // 
            this.lblPanNo.AutoSize = true;
            this.lblPanNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblPanNo.Location = new System.Drawing.Point(541, 244);
            this.lblPanNo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPanNo.Name = "lblPanNo";
            this.lblPanNo.Size = new System.Drawing.Size(62, 25);
            this.lblPanNo.TabIndex = 43;
            this.lblPanNo.Text = "PAN:";
            // 
            // txtPan
            // 
            this.txtPan.BackColor = System.Drawing.Color.White;
            this.txtPan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPan.Location = new System.Drawing.Point(611, 239);
            this.txtPan.Margin = new System.Windows.Forms.Padding(5);
            this.txtPan.Name = "txtPan";
            this.txtPan.Size = new System.Drawing.Size(293, 31);
            this.txtPan.TabIndex = 10;
            this.txtPan.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // txtGST
            // 
            this.txtGST.BackColor = System.Drawing.Color.White;
            this.txtGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtGST.Location = new System.Drawing.Point(206, 239);
            this.txtGST.Margin = new System.Windows.Forms.Padding(5);
            this.txtGST.Name = "txtGST";
            this.txtGST.Size = new System.Drawing.Size(293, 31);
            this.txtGST.TabIndex = 9;
            this.txtGST.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // lblGST
            // 
            this.lblGST.AutoSize = true;
            this.lblGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblGST.Location = new System.Drawing.Point(138, 244);
            this.lblGST.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblGST.Name = "lblGST";
            this.lblGST.Size = new System.Drawing.Size(61, 25);
            this.lblGST.TabIndex = 40;
            this.lblGST.Text = "GST:";
            // 
            // txtCountry
            // 
            this.txtCountry.BackColor = System.Drawing.Color.White;
            this.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCountry.Location = new System.Drawing.Point(751, 192);
            this.txtCountry.Margin = new System.Windows.Forms.Padding(5);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(153, 31);
            this.txtCountry.TabIndex = 8;
            this.txtCountry.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCountry.Location = new System.Drawing.Point(640, 198);
            this.lblCountry.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(102, 25);
            this.lblCountry.TabIndex = 38;
            this.lblCountry.Text = "Country:";
            // 
            // txtState
            // 
            this.txtState.BackColor = System.Drawing.Color.White;
            this.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtState.Location = new System.Drawing.Point(468, 192);
            this.txtState.Margin = new System.Windows.Forms.Padding(5);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(153, 31);
            this.txtState.TabIndex = 7;
            this.txtState.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblState.Location = new System.Drawing.Point(380, 198);
            this.lblState.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(75, 25);
            this.lblState.TabIndex = 36;
            this.lblState.Text = "State:";
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.White;
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCity.Location = new System.Drawing.Point(728, 147);
            this.txtCity.Margin = new System.Windows.Forms.Padding(5);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(176, 31);
            this.txtCity.TabIndex = 5;
            this.txtCity.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCity.Location = new System.Drawing.Point(658, 152);
            this.lblCity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(61, 25);
            this.lblCity.TabIndex = 34;
            this.lblCity.Text = "City:";
            // 
            // txtAddress3
            // 
            this.txtAddress3.BackColor = System.Drawing.Color.White;
            this.txtAddress3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAddress3.Location = new System.Drawing.Point(206, 147);
            this.txtAddress3.Margin = new System.Windows.Forms.Padding(5);
            this.txtAddress3.Name = "txtAddress3";
            this.txtAddress3.Size = new System.Drawing.Size(436, 31);
            this.txtAddress3.TabIndex = 4;
            this.txtAddress3.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // txtAddress2
            // 
            this.txtAddress2.BackColor = System.Drawing.Color.White;
            this.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAddress2.Location = new System.Drawing.Point(206, 109);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(5);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(698, 31);
            this.txtAddress2.TabIndex = 3;
            this.txtAddress2.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // txtAddress1
            // 
            this.txtAddress1.BackColor = System.Drawing.Color.White;
            this.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAddress1.Location = new System.Drawing.Point(206, 72);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(5);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(698, 31);
            this.txtAddress1.TabIndex = 2;
            this.txtAddress1.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtId.Location = new System.Drawing.Point(830, 27);
            this.txtId.Margin = new System.Windows.Forms.Padding(5);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(74, 31);
            this.txtId.TabIndex = 30;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtId.Visible = false;
            this.txtId.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(783, 33);
            this.lblId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(41, 25);
            this.lblId.TabIndex = 29;
            this.lblId.Text = "Id:";
            this.lblId.Visible = false;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.Color.White;
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCompanyName.Location = new System.Drawing.Point(206, 27);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(5);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(561, 31);
            this.txtCompanyName.TabIndex = 1;
            this.txtCompanyName.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // lblAddress3
            // 
            this.lblAddress3.AutoSize = true;
            this.lblAddress3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblAddress3.Location = new System.Drawing.Point(75, 152);
            this.lblAddress3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddress3.Name = "lblAddress3";
            this.lblAddress3.Size = new System.Drawing.Size(120, 25);
            this.lblAddress3.TabIndex = 27;
            this.lblAddress3.Text = "Address 3:";
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblAddress2.Location = new System.Drawing.Point(75, 116);
            this.lblAddress2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(120, 25);
            this.lblAddress2.TabIndex = 26;
            this.lblAddress2.Text = "Address 2:";
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblAddress1.Location = new System.Drawing.Point(75, 77);
            this.lblAddress1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(120, 25);
            this.lblAddress1.TabIndex = 25;
            this.lblAddress1.Text = "Address 1:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCustomerName.Location = new System.Drawing.Point(16, 31);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(183, 25);
            this.lblCustomerName.TabIndex = 24;
            this.lblCustomerName.Text = "Customer Name:";
            // 
            // btnAddRateInfo
            // 
            this.btnAddRateInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRateInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAddRateInfo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAddRateInfo.FlatAppearance.BorderSize = 2;
            this.btnAddRateInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRateInfo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRateInfo.ForeColor = System.Drawing.Color.White;
            this.btnAddRateInfo.Location = new System.Drawing.Point(14, 8);
            this.btnAddRateInfo.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddRateInfo.Name = "btnAddRateInfo";
            this.btnAddRateInfo.Size = new System.Drawing.Size(263, 48);
            this.btnAddRateInfo.TabIndex = 18;
            this.btnAddRateInfo.Text = "&Set Rate Detail";
            this.btnAddRateInfo.UseVisualStyleBackColor = false;
            this.btnAddRateInfo.Click += new System.EventHandler(this.btnAddRateInfo_Click);
            // 
            // flowPanelErrorMessage
            // 
            this.flowPanelErrorMessage.AutoSize = true;
            this.flowPanelErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPanelErrorMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowPanelErrorMessage.Location = new System.Drawing.Point(3, 55);
            this.flowPanelErrorMessage.Margin = new System.Windows.Forms.Padding(5);
            this.flowPanelErrorMessage.Name = "flowPanelErrorMessage";
            this.flowPanelErrorMessage.Size = new System.Drawing.Size(924, 2);
            this.flowPanelErrorMessage.TabIndex = 7;
            this.flowPanelErrorMessage.Visible = false;
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(930, 633);
            this.Controls.Add(this.flowPanelErrorMessage);
            this.Controls.Add(this.pnlData);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmCustomer";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.pnlTitle, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlData, 0);
            this.Controls.SetChildIndex(this.flowPanelErrorMessage, 0);
            this.pnlTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.pnlInvoiceFomat.ResumeLayout(false);
            this.pnlTaxCategory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblCessNo;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPanNo;
        private System.Windows.Forms.TextBox txtPan;
        private System.Windows.Forms.TextBox txtGST;
        private System.Windows.Forms.Label lblGST;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtAddress3;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblAddress3;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCess;
        private System.Windows.Forms.Panel flowPanelErrorMessage;
        private System.Windows.Forms.Button btnAddRateInfo;
        private CustomControl.LineControl lineControl1;
        private CustomControl.CustomReadioButton radGST;
        private System.Windows.Forms.Panel pnlTaxCategory;
        private CustomControl.CustomReadioButton radLUT;
        private CustomControl.CustomReadioButton radRCM;
        private CustomControl.LineControl lineControl2;
        private System.Windows.Forms.Panel pnlInvoiceFomat;
        private CustomControl.CustomReadioButton radWithoutGST;
        private CustomControl.CustomReadioButton radWithGST;
        //private System.Windows.Forms.Panel flowPanelErrorMessage;
    }
}