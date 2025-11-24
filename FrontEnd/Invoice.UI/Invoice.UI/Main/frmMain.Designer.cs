namespace Invoice.UI.Main
{
    partial class frmMain
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
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.heading = new Invoice.UI.CustomControl.Heading();
            this.tblButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnRantal = new System.Windows.Forms.Button();
            this.btnVehicle = new System.Windows.Forms.Button();
            this.btnDriver = new System.Windows.Forms.Button();
            this.btnItem = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnBank = new System.Windows.Forms.Button();
            this.btnFinancialYear = new System.Windows.Forms.Button();
            this.btnCompany = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnPayment = new System.Windows.Forms.Button();
            this.pnlTitle.SuspendLayout();
            this.tblButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.heading);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(2, 2);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1344, 39);
            this.pnlTitle.TabIndex = 4;
            // 
            // heading
            // 
            this.heading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.heading.Dock = System.Windows.Forms.DockStyle.Top;
            this.heading.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heading.ForeColor = System.Drawing.Color.Black;
            this.heading.Location = new System.Drawing.Point(0, 0);
            this.heading.Margin = new System.Windows.Forms.Padding(4);
            this.heading.Name = "heading";
            this.heading.Size = new System.Drawing.Size(1344, 34);
            this.heading.TabIndex = 0;
            this.heading.Title = "Invoice";
            // 
            // tblButton
            // 
            this.tblButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.tblButton.ColumnCount = 10;
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblButton.Controls.Add(this.btnPayment, 9, 0);
            this.tblButton.Controls.Add(this.btnInvoice, 8, 0);
            this.tblButton.Controls.Add(this.btnRantal, 7, 0);
            this.tblButton.Controls.Add(this.btnVehicle, 6, 0);
            this.tblButton.Controls.Add(this.btnDriver, 5, 0);
            this.tblButton.Controls.Add(this.btnItem, 4, 0);
            this.tblButton.Controls.Add(this.btnCustomer, 3, 0);
            this.tblButton.Controls.Add(this.btnBank, 2, 0);
            this.tblButton.Controls.Add(this.btnFinancialYear, 1, 0);
            this.tblButton.Controls.Add(this.btnCompany, 0, 0);
            this.tblButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblButton.Location = new System.Drawing.Point(2, 41);
            this.tblButton.Margin = new System.Windows.Forms.Padding(4);
            this.tblButton.Name = "tblButton";
            this.tblButton.RowCount = 1;
            this.tblButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButton.Size = new System.Drawing.Size(1344, 66);
            this.tblButton.TabIndex = 5;
            // 
            // btnInvoice
            // 
            this.btnInvoice.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.btnInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInvoice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnInvoice.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.btnInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoice.Location = new System.Drawing.Point(1075, 3);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(128, 60);
            this.btnInvoice.TabIndex = 8;
            this.btnInvoice.Text = "&Invoice";
            this.btnInvoice.UseVisualStyleBackColor = false;
            this.btnInvoice.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnRantal
            // 
            this.btnRantal.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.btnRantal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnRantal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRantal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnRantal.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.btnRantal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRantal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRantal.Location = new System.Drawing.Point(941, 3);
            this.btnRantal.Name = "btnRantal";
            this.btnRantal.Size = new System.Drawing.Size(128, 60);
            this.btnRantal.TabIndex = 7;
            this.btnRantal.Text = "&Rental";
            this.btnRantal.UseVisualStyleBackColor = false;
            this.btnRantal.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnVehicle
            // 
            this.btnVehicle.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.btnVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVehicle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnVehicle.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.btnVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVehicle.Location = new System.Drawing.Point(807, 3);
            this.btnVehicle.Name = "btnVehicle";
            this.btnVehicle.Size = new System.Drawing.Size(128, 60);
            this.btnVehicle.TabIndex = 6;
            this.btnVehicle.Text = "&Vehicle";
            this.btnVehicle.UseVisualStyleBackColor = false;
            this.btnVehicle.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnDriver
            // 
            this.btnDriver.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.btnDriver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnDriver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDriver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnDriver.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.btnDriver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDriver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDriver.Location = new System.Drawing.Point(673, 3);
            this.btnDriver.Name = "btnDriver";
            this.btnDriver.Size = new System.Drawing.Size(128, 60);
            this.btnDriver.TabIndex = 5;
            this.btnDriver.Text = "&Driver";
            this.btnDriver.UseVisualStyleBackColor = false;
            this.btnDriver.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnItem
            // 
            this.btnItem.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.btnItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnItem.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.btnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItem.Location = new System.Drawing.Point(539, 3);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(128, 60);
            this.btnItem.TabIndex = 4;
            this.btnItem.Text = "&Item";
            this.btnItem.UseVisualStyleBackColor = false;
            this.btnItem.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.btnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCustomer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnCustomer.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.Location = new System.Drawing.Point(405, 3);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(128, 60);
            this.btnCustomer.TabIndex = 3;
            this.btnCustomer.Text = "&Customer";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnBank
            // 
            this.btnBank.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.btnBank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBank.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnBank.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.btnBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBank.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBank.Location = new System.Drawing.Point(271, 3);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(128, 60);
            this.btnBank.TabIndex = 2;
            this.btnBank.Text = "&Bank";
            this.btnBank.UseVisualStyleBackColor = false;
            this.btnBank.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnFinancialYear
            // 
            this.btnFinancialYear.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.btnFinancialYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnFinancialYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinancialYear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnFinancialYear.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.btnFinancialYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinancialYear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinancialYear.Location = new System.Drawing.Point(137, 3);
            this.btnFinancialYear.Name = "btnFinancialYear";
            this.btnFinancialYear.Size = new System.Drawing.Size(128, 60);
            this.btnFinancialYear.TabIndex = 1;
            this.btnFinancialYear.Text = "&Financial Year";
            this.btnFinancialYear.UseVisualStyleBackColor = false;
            this.btnFinancialYear.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnCompany
            // 
            this.btnCompany.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.btnCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCompany.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnCompany.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.btnCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompany.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(44)))), ((int)(((byte)(25)))));
            this.btnCompany.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompany.Location = new System.Drawing.Point(3, 3);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(128, 60);
            this.btnCompany.TabIndex = 0;
            this.btnCompany.Text = "&Company";
            this.btnCompany.UseVisualStyleBackColor = false;
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(2, 107);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1344, 846);
            this.pnlMain.TabIndex = 6;
            // 
            // btnPayment
            // 
            this.btnPayment.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.btnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPayment.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnPayment.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayment.Location = new System.Drawing.Point(1209, 3);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(132, 60);
            this.btnPayment.TabIndex = 9;
            this.btnPayment.Text = "&Payment";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1348, 955);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tblButton);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTitle.ResumeLayout(false);
            this.tblButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.TableLayoutPanel tblButton;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnBank;
        private System.Windows.Forms.Button btnFinancialYear;
        private System.Windows.Forms.Button btnCompany;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnRantal;
        private System.Windows.Forms.Button btnVehicle;
        private System.Windows.Forms.Button btnDriver;
        private System.Windows.Forms.Button btnItem;
        private CustomControl.Heading heading;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnPayment;
    }
}