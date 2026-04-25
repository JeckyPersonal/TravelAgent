namespace Invoice.UI
{
    partial class frmCompany
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
            this.pnlAction = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlData = new System.Windows.Forms.Panel();
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
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.heading1 = new Invoice.UI.CustomControl.Heading();
            this.txtLUTno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlAction.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowPanelErrorMessage
            // 
            this.flowPanelErrorMessage.AutoSize = true;
            this.flowPanelErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPanelErrorMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowPanelErrorMessage.Location = new System.Drawing.Point(2, 34);
            this.flowPanelErrorMessage.Name = "flowPanelErrorMessage";
            this.flowPanelErrorMessage.Size = new System.Drawing.Size(592, 2);
            this.flowPanelErrorMessage.TabIndex = 0;
            this.flowPanelErrorMessage.Visible = false;
            // 
            // pnlAction
            // 
            this.pnlAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.pnlAction.Controls.Add(this.button2);
            this.pnlAction.Controls.Add(this.btnSaveClose);
            this.pnlAction.Controls.Add(this.btnSave);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAction.Location = new System.Drawing.Point(2, 272);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(592, 47);
            this.pnlAction.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(420, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 31);
            this.button2.TabIndex = 13;
            this.button2.Text = "C&lose";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSaveClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveClose.Location = new System.Drawing.Point(255, 7);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(160, 31);
            this.btnSaveClose.TabIndex = 12;
            this.btnSaveClose.Text = "Save && &Close";
            this.btnSaveClose.UseVisualStyleBackColor = false;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(90, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 31);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save && Create New";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlData
            // 
            this.pnlData.AutoSize = true;
            this.pnlData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.pnlData.Controls.Add(this.txtLUTno);
            this.pnlData.Controls.Add(this.label3);
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
            this.pnlData.Controls.Add(this.lblCompanyName);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(2, 36);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(592, 236);
            this.pnlData.TabIndex = 2;
            // 
            // txtZipCode
            // 
            this.txtZipCode.BackColor = System.Drawing.Color.White;
            this.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZipCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtZipCode.Location = new System.Drawing.Point(139, 116);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(95, 31);
            this.txtZipCode.TabIndex = 6;
            this.txtZipCode.Leave += new System.EventHandler(this.txtPan_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(71, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "ZipCode:";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPhone.Location = new System.Drawing.Point(410, 186);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(159, 31);
            this.txtPhone.TabIndex = 11;
            this.txtPhone.Leave += new System.EventHandler(this.txtPan_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(332, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Phone No:";
            // 
            // lblPanNo
            // 
            this.lblPanNo.AutoSize = true;
            this.lblPanNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblPanNo.Location = new System.Drawing.Point(345, 149);
            this.lblPanNo.Name = "lblPanNo";
            this.lblPanNo.Size = new System.Drawing.Size(62, 25);
            this.lblPanNo.TabIndex = 19;
            this.lblPanNo.Text = "PAN:";
            // 
            // txtPan
            // 
            this.txtPan.BackColor = System.Drawing.Color.White;
            this.txtPan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPan.Location = new System.Drawing.Point(388, 146);
            this.txtPan.Name = "txtPan";
            this.txtPan.Size = new System.Drawing.Size(181, 31);
            this.txtPan.TabIndex = 10;
            this.txtPan.Leave += new System.EventHandler(this.txtPan_Leave);
            // 
            // txtGST
            // 
            this.txtGST.BackColor = System.Drawing.Color.White;
            this.txtGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtGST.Location = new System.Drawing.Point(139, 146);
            this.txtGST.Name = "txtGST";
            this.txtGST.Size = new System.Drawing.Size(181, 31);
            this.txtGST.TabIndex = 9;
            this.txtGST.Leave += new System.EventHandler(this.txtPan_Leave);
            // 
            // lblGST
            // 
            this.lblGST.AutoSize = true;
            this.lblGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblGST.Location = new System.Drawing.Point(97, 149);
            this.lblGST.Name = "lblGST";
            this.lblGST.Size = new System.Drawing.Size(61, 25);
            this.lblGST.TabIndex = 16;
            this.lblGST.Text = "GST:";
            // 
            // txtCountry
            // 
            this.txtCountry.BackColor = System.Drawing.Color.White;
            this.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCountry.Location = new System.Drawing.Point(474, 116);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(95, 31);
            this.txtCountry.TabIndex = 8;
            this.txtCountry.Leave += new System.EventHandler(this.txtPan_Leave);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCountry.Location = new System.Drawing.Point(406, 120);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(102, 25);
            this.lblCountry.TabIndex = 14;
            this.lblCountry.Text = "Country:";
            // 
            // txtState
            // 
            this.txtState.BackColor = System.Drawing.Color.White;
            this.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtState.Location = new System.Drawing.Point(300, 116);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(95, 31);
            this.txtState.TabIndex = 7;
            this.txtState.Leave += new System.EventHandler(this.txtPan_Leave);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblState.Location = new System.Drawing.Point(246, 120);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(75, 25);
            this.lblState.TabIndex = 12;
            this.lblState.Text = "State:";
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.White;
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCity.Location = new System.Drawing.Point(460, 87);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(109, 31);
            this.txtCity.TabIndex = 5;
            this.txtCity.Leave += new System.EventHandler(this.txtPan_Leave);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCity.Location = new System.Drawing.Point(417, 90);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(61, 25);
            this.lblCity.TabIndex = 10;
            this.lblCity.Text = "City:";
            // 
            // txtAddress3
            // 
            this.txtAddress3.BackColor = System.Drawing.Color.White;
            this.txtAddress3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAddress3.Location = new System.Drawing.Point(139, 87);
            this.txtAddress3.Name = "txtAddress3";
            this.txtAddress3.Size = new System.Drawing.Size(269, 31);
            this.txtAddress3.TabIndex = 4;
            this.txtAddress3.Leave += new System.EventHandler(this.txtPan_Leave);
            // 
            // txtAddress2
            // 
            this.txtAddress2.BackColor = System.Drawing.Color.White;
            this.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAddress2.Location = new System.Drawing.Point(139, 63);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(430, 31);
            this.txtAddress2.TabIndex = 3;
            this.txtAddress2.Leave += new System.EventHandler(this.txtPan_Leave);
            // 
            // txtAddress1
            // 
            this.txtAddress1.BackColor = System.Drawing.Color.White;
            this.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAddress1.Location = new System.Drawing.Point(139, 39);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(430, 31);
            this.txtAddress1.TabIndex = 2;
            this.txtAddress1.Leave += new System.EventHandler(this.txtPan_Leave);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtId.Location = new System.Drawing.Point(523, 10);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(46, 31);
            this.txtId.TabIndex = 6;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtId.Visible = false;
            this.txtId.Leave += new System.EventHandler(this.txtPan_Leave);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(494, 14);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(41, 25);
            this.lblId.TabIndex = 5;
            this.lblId.Text = "Id:";
            this.lblId.Visible = false;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.Color.White;
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCompanyName.Location = new System.Drawing.Point(139, 10);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(346, 31);
            this.txtCompanyName.TabIndex = 1;
            this.txtCompanyName.Leave += new System.EventHandler(this.txtPan_Leave);
            // 
            // lblAddress3
            // 
            this.lblAddress3.AutoSize = true;
            this.lblAddress3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblAddress3.Location = new System.Drawing.Point(58, 90);
            this.lblAddress3.Name = "lblAddress3";
            this.lblAddress3.Size = new System.Drawing.Size(120, 25);
            this.lblAddress3.TabIndex = 3;
            this.lblAddress3.Text = "Address 3:";
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblAddress2.Location = new System.Drawing.Point(58, 67);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(120, 25);
            this.lblAddress2.TabIndex = 2;
            this.lblAddress2.Text = "Address 2:";
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblAddress1.Location = new System.Drawing.Point(58, 42);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(120, 25);
            this.lblAddress1.TabIndex = 1;
            this.lblAddress1.Text = "Address 1:";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCompanyName.Location = new System.Drawing.Point(22, 13);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(180, 25);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "Company Name:";
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.heading1);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(2, 2);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(592, 32);
            this.pnlTitle.TabIndex = 3;
            // 
            // heading1
            // 
            this.heading1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.heading1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heading1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heading1.ForeColor = System.Drawing.Color.Black;
            this.heading1.Location = new System.Drawing.Point(0, 0);
            this.heading1.Margin = new System.Windows.Forms.Padding(4);
            this.heading1.Name = "heading1";
            this.heading1.Size = new System.Drawing.Size(592, 32);
            this.heading1.TabIndex = 0;
            this.heading1.Title = "Company";
            this.heading1.Click += new System.EventHandler(this.heading1_Click);
            this.heading1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.heading1_MouseDown);
            // 
            // txtLUTno
            // 
            this.txtLUTno.BackColor = System.Drawing.Color.White;
            this.txtLUTno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLUTno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtLUTno.Location = new System.Drawing.Point(140, 185);
            this.txtLUTno.Name = "txtLUTno";
            this.txtLUTno.Size = new System.Drawing.Size(181, 31);
            this.txtLUTno.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(98, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 38);
            this.label3.TabIndex = 24;
            this.label3.Text = "LUT:";
            // 
            // frmCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(596, 321);
            this.ControlBox = false;
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlAction);
            this.Controls.Add(this.flowPanelErrorMessage);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCompany";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmCompany_Load);
            this.pnlAction.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.Label lblCompanyName;
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
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPanNo;
        private System.Windows.Forms.TextBox txtPan;
        private System.Windows.Forms.TextBox txtGST;
        private System.Windows.Forms.Panel flowPanelErrorMessage;
        private CustomControl.Heading heading1;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLUTno;
        private System.Windows.Forms.Label label3;
    }
}

