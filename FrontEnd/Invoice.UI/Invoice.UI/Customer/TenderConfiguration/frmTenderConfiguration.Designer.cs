namespace Invoice.UI.Customer.TenderConfiguration
{
    partial class frmTenderConfiguration
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlData = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlFrmData = new System.Windows.Forms.Panel();
            this.txtFuelRateID = new System.Windows.Forms.TextBox();
            this.btnSaveFuelRate = new System.Windows.Forms.Button();
            this.txtFuelRate = new System.Windows.Forms.TextBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.txtAdjustmentPercentage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContractFuelRate = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbContractType = new System.Windows.Forms.ComboBox();
            this.lblPickup = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlFrmData.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Location = new System.Drawing.Point(6, 5);
            this.pnlTitle.Size = new System.Drawing.Size(668, 33);
            // 
            // heading1
            // 
            this.heading1.Size = new System.Drawing.Size(668, 33);
            this.heading1.Title = "Tender";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(6, 486);
            this.panel1.Size = new System.Drawing.Size(668, 69);
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.pnlData.Controls.Add(this.dgvData);
            this.pnlData.Controls.Add(this.pnlFrmData);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(6, 38);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(668, 448);
            this.pnlData.TabIndex = 6;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgvData.Location = new System.Drawing.Point(0, 266);
            this.dgvData.Margin = new System.Windows.Forms.Padding(5);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 62;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(668, 182);
            this.dgvData.TabIndex = 1;
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvData_KeyDown);
            // 
            // pnlFrmData
            // 
            this.pnlFrmData.Controls.Add(this.txtFuelRateID);
            this.pnlFrmData.Controls.Add(this.btnSaveFuelRate);
            this.pnlFrmData.Controls.Add(this.txtFuelRate);
            this.pnlFrmData.Controls.Add(this.dtpFromDate);
            this.pnlFrmData.Controls.Add(this.dtpToDate);
            this.pnlFrmData.Controls.Add(this.txtAdjustmentPercentage);
            this.pnlFrmData.Controls.Add(this.label1);
            this.pnlFrmData.Controls.Add(this.txtContractFuelRate);
            this.pnlFrmData.Controls.Add(this.lblCustomer);
            this.pnlFrmData.Controls.Add(this.cmbContractType);
            this.pnlFrmData.Controls.Add(this.lblPickup);
            this.pnlFrmData.Controls.Add(this.lblFromDate);
            this.pnlFrmData.Controls.Add(this.lblToDate);
            this.pnlFrmData.Controls.Add(this.label2);
            this.pnlFrmData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFrmData.Location = new System.Drawing.Point(0, 0);
            this.pnlFrmData.Name = "pnlFrmData";
            this.pnlFrmData.Size = new System.Drawing.Size(668, 266);
            this.pnlFrmData.TabIndex = 0;
            // 
            // txtFuelRateID
            // 
            this.txtFuelRateID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFuelRateID.Location = new System.Drawing.Point(581, 152);
            this.txtFuelRateID.Margin = new System.Windows.Forms.Padding(5);
            this.txtFuelRateID.Name = "txtFuelRateID";
            this.txtFuelRateID.Size = new System.Drawing.Size(72, 31);
            this.txtFuelRateID.TabIndex = 45;
            this.txtFuelRateID.Visible = false;
            // 
            // btnSaveFuelRate
            // 
            this.btnSaveFuelRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFuelRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSaveFuelRate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSaveFuelRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFuelRate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveFuelRate.Location = new System.Drawing.Point(562, 208);
            this.btnSaveFuelRate.Margin = new System.Windows.Forms.Padding(5);
            this.btnSaveFuelRate.Name = "btnSaveFuelRate";
            this.btnSaveFuelRate.Size = new System.Drawing.Size(91, 36);
            this.btnSaveFuelRate.TabIndex = 44;
            this.btnSaveFuelRate.Text = "&Save";
            this.btnSaveFuelRate.UseVisualStyleBackColor = false;
            this.btnSaveFuelRate.Click += new System.EventHandler(this.btnSaveFuelRate_Click);
            // 
            // txtFuelRate
            // 
            this.txtFuelRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFuelRate.Location = new System.Drawing.Point(394, 208);
            this.txtFuelRate.Margin = new System.Windows.Forms.Padding(5);
            this.txtFuelRate.Name = "txtFuelRate";
            this.txtFuelRate.Size = new System.Drawing.Size(158, 31);
            this.txtFuelRate.TabIndex = 42;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(14, 208);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(5);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(180, 31);
            this.dtpFromDate.TabIndex = 38;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(202, 208);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(5);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(182, 31);
            this.dtpToDate.TabIndex = 39;
            // 
            // txtAdjustmentPercentage
            // 
            this.txtAdjustmentPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdjustmentPercentage.Location = new System.Drawing.Point(199, 68);
            this.txtAdjustmentPercentage.Margin = new System.Windows.Forms.Padding(5);
            this.txtAdjustmentPercentage.Name = "txtAdjustmentPercentage";
            this.txtAdjustmentPercentage.Size = new System.Drawing.Size(246, 31);
            this.txtAdjustmentPercentage.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 25);
            this.label1.TabIndex = 37;
            this.label1.Text = "Adjustment (%):";
            // 
            // txtContractFuelRate
            // 
            this.txtContractFuelRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContractFuelRate.Location = new System.Drawing.Point(199, 116);
            this.txtContractFuelRate.Margin = new System.Windows.Forms.Padding(5);
            this.txtContractFuelRate.Name = "txtContractFuelRate";
            this.txtContractFuelRate.Size = new System.Drawing.Size(246, 31);
            this.txtContractFuelRate.TabIndex = 34;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblCustomer.Location = new System.Drawing.Point(12, 24);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(160, 25);
            this.lblCustomer.TabIndex = 33;
            this.lblCustomer.Text = "Contract Type:";
            // 
            // cmbContractType
            // 
            this.cmbContractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContractType.FormattingEnabled = true;
            this.cmbContractType.Location = new System.Drawing.Point(199, 24);
            this.cmbContractType.Margin = new System.Windows.Forms.Padding(5);
            this.cmbContractType.Name = "cmbContractType";
            this.cmbContractType.Size = new System.Drawing.Size(248, 33);
            this.cmbContractType.TabIndex = 32;
            this.cmbContractType.SelectedIndexChanged += new System.EventHandler(this.cmbContractType_SelectedIndexChanged);
            // 
            // lblPickup
            // 
            this.lblPickup.AutoSize = true;
            this.lblPickup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblPickup.Location = new System.Drawing.Point(12, 116);
            this.lblPickup.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPickup.Name = "lblPickup";
            this.lblPickup.Size = new System.Drawing.Size(117, 25);
            this.lblPickup.TabIndex = 35;
            this.lblPickup.Text = "Fuel Rate:";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblFromDate.Location = new System.Drawing.Point(9, 178);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(118, 25);
            this.lblFromDate.TabIndex = 40;
            this.lblFromDate.Text = "From Date";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.lblToDate.Location = new System.Drawing.Point(197, 178);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(88, 25);
            this.lblToDate.TabIndex = 41;
            this.lblToDate.Text = "To Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(389, 175);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Fuel Rate";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(741, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 8);
            this.panel2.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(468, 10);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(195, 48);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "C&lose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(265, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(195, 48);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmTenderConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 560);
            this.Controls.Add(this.pnlData);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmTenderConfiguration";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.pnlTitle, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlData, 0);
            this.pnlTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlFrmData.ResumeLayout(false);
            this.pnlFrmData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlFrmData;
        private System.Windows.Forms.TextBox txtFuelRate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.TextBox txtAdjustmentPercentage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContractFuelRate;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbContractType;
        private System.Windows.Forms.Label lblPickup;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveFuelRate;
        private System.Windows.Forms.TextBox txtFuelRateID;
    }
}