namespace Invoice.UI.Vehicle
{
    partial class frmVehicle
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
            this.btnAddRateInfo = new System.Windows.Forms.Button();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtVehicleType = new System.Windows.Forms.TextBox();
            this.btnVehicleDetail = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Location = new System.Drawing.Point(2, 2);
            this.pnlTitle.Size = new System.Drawing.Size(569, 33);
            // 
            // heading1
            // 
            this.heading1.Size = new System.Drawing.Size(569, 33);
            this.heading1.Title = "Vehicle";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(2, 115);
            this.panel1.Size = new System.Drawing.Size(569, 45);
            // 
            // flowPanelErrorMessage
            // 
            this.flowPanelErrorMessage.AutoSize = true;
            this.flowPanelErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPanelErrorMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowPanelErrorMessage.Location = new System.Drawing.Point(2, 35);
            this.flowPanelErrorMessage.Name = "flowPanelErrorMessage";
            this.flowPanelErrorMessage.Size = new System.Drawing.Size(569, 2);
            this.flowPanelErrorMessage.TabIndex = 13;
            this.flowPanelErrorMessage.Visible = false;
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.pnlData.Controls.Add(this.btnAddRateInfo);
            this.pnlData.Controls.Add(this.lblCompanyName);
            this.pnlData.Controls.Add(this.lblId);
            this.pnlData.Controls.Add(this.txtId);
            this.pnlData.Controls.Add(this.txtVehicleType);
            this.pnlData.Controls.Add(this.btnVehicleDetail);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(2, 37);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(569, 78);
            this.pnlData.TabIndex = 14;
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
            this.btnAddRateInfo.Location = new System.Drawing.Point(231, 42);
            this.btnAddRateInfo.Name = "btnAddRateInfo";
            this.btnAddRateInfo.Size = new System.Drawing.Size(162, 31);
            this.btnAddRateInfo.TabIndex = 51;
            this.btnAddRateInfo.Text = "&Set Rate Detail";
            this.btnAddRateInfo.UseVisualStyleBackColor = false;
            this.btnAddRateInfo.Click += new System.EventHandler(this.btnAddRateInfo_Click);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCompanyName.Location = new System.Drawing.Point(108, 17);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(96, 16);
            this.lblCompanyName.TabIndex = 13;
            this.lblCompanyName.Text = "Vehicle Type:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblId.Location = new System.Drawing.Point(14, 17);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(26, 16);
            this.lblId.TabIndex = 15;
            this.lblId.Text = "Id:";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtId.Location = new System.Drawing.Point(43, 14);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(46, 23);
            this.txtId.TabIndex = 16;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtId.Leave += new System.EventHandler(this.txtVehicleType_Leave);
            // 
            // txtVehicleType
            // 
            this.txtVehicleType.BackColor = System.Drawing.Color.White;
            this.txtVehicleType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVehicleType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtVehicleType.Location = new System.Drawing.Point(210, 14);
            this.txtVehicleType.Name = "txtVehicleType";
            this.txtVehicleType.Size = new System.Drawing.Size(351, 23);
            this.txtVehicleType.TabIndex = 14;
            this.txtVehicleType.Leave += new System.EventHandler(this.txtVehicleType_Leave);
            // 
            // btnVehicleDetail
            // 
            this.btnVehicleDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVehicleDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnVehicleDetail.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnVehicleDetail.FlatAppearance.BorderSize = 2;
            this.btnVehicleDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehicleDetail.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicleDetail.ForeColor = System.Drawing.Color.White;
            this.btnVehicleDetail.Location = new System.Drawing.Point(399, 42);
            this.btnVehicleDetail.Name = "btnVehicleDetail";
            this.btnVehicleDetail.Size = new System.Drawing.Size(162, 31);
            this.btnVehicleDetail.TabIndex = 12;
            this.btnVehicleDetail.Text = "&Add Vehicle Detail";
            this.btnVehicleDetail.UseVisualStyleBackColor = false;
            this.btnVehicleDetail.Click += new System.EventHandler(this.btnVehicleDetail_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(444, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 31);
            this.button2.TabIndex = 5;
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
            this.button1.Location = new System.Drawing.Point(318, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(573, 162);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.flowPanelErrorMessage);
            this.Name = "frmVehicle";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.pnlTitle, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.flowPanelErrorMessage, 0);
            this.Controls.SetChildIndex(this.pnlData, 0);
            this.pnlTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel flowPanelErrorMessage;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Button btnVehicleDetail;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtVehicleType;
        private System.Windows.Forms.Button btnAddRateInfo;
    }
}