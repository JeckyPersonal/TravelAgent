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
            this.button6 = new System.Windows.Forms.Button();
            this.btnDriver = new System.Windows.Forms.Button();
            this.btnItem = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnBank = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCompany = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTitle.SuspendLayout();
            this.tblButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.heading);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(3, 3);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1342, 39);
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
            this.heading.Size = new System.Drawing.Size(1342, 34);
            this.heading.TabIndex = 0;
            this.heading.Title = "Invoice";
            // 
            // tblButton
            // 
            this.tblButton.ColumnCount = 9;
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblButton.Controls.Add(this.btnInvoice, 8, 0);
            this.tblButton.Controls.Add(this.btnRantal, 7, 0);
            this.tblButton.Controls.Add(this.button6, 6, 0);
            this.tblButton.Controls.Add(this.btnDriver, 5, 0);
            this.tblButton.Controls.Add(this.btnItem, 4, 0);
            this.tblButton.Controls.Add(this.btnCustomer, 3, 0);
            this.tblButton.Controls.Add(this.btnBank, 2, 0);
            this.tblButton.Controls.Add(this.button1, 1, 0);
            this.tblButton.Controls.Add(this.btnCompany, 0, 0);
            this.tblButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblButton.Location = new System.Drawing.Point(3, 42);
            this.tblButton.Margin = new System.Windows.Forms.Padding(4);
            this.tblButton.Name = "tblButton";
            this.tblButton.RowCount = 1;
            this.tblButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButton.Size = new System.Drawing.Size(1342, 66);
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
            this.btnInvoice.Location = new System.Drawing.Point(1195, 3);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(144, 60);
            this.btnInvoice.TabIndex = 8;
            this.btnInvoice.Text = "&Invoice";
            this.btnInvoice.UseVisualStyleBackColor = false;
            // 
            // btnRantal
            // 
            this.btnRantal.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.btnRantal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnRantal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRantal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnRantal.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.btnRantal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRantal.Location = new System.Drawing.Point(1046, 3);
            this.btnRantal.Name = "btnRantal";
            this.btnRantal.Size = new System.Drawing.Size(143, 60);
            this.btnRantal.TabIndex = 7;
            this.btnRantal.Text = "&Rental";
            this.btnRantal.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.button6.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(897, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(143, 60);
            this.button6.TabIndex = 6;
            this.button6.Text = "&Vehicle";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // btnDriver
            // 
            this.btnDriver.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.btnDriver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnDriver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDriver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.btnDriver.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.btnDriver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDriver.Location = new System.Drawing.Point(748, 3);
            this.btnDriver.Name = "btnDriver";
            this.btnDriver.Size = new System.Drawing.Size(143, 60);
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
            this.btnItem.Location = new System.Drawing.Point(599, 3);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(143, 60);
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
            this.btnCustomer.Location = new System.Drawing.Point(450, 3);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(143, 60);
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
            this.btnBank.Location = new System.Drawing.Point(301, 3);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(143, 60);
            this.btnBank.TabIndex = 2;
            this.btnBank.Text = "&Bank";
            this.btnBank.UseVisualStyleBackColor = false;
            this.btnBank.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(65)))));
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(152, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 60);
            this.button1.TabIndex = 1;
            this.button1.Text = "&Financial Year";
            this.button1.UseVisualStyleBackColor = false;
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
            this.btnCompany.Location = new System.Drawing.Point(3, 3);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(143, 60);
            this.btnCompany.TabIndex = 0;
            this.btnCompany.Text = "&Company";
            this.btnCompany.UseVisualStyleBackColor = false;
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 108);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1342, 844);
            this.pnlMain.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1348, 955);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tblButton);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(3);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCompany;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnRantal;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnDriver;
        private System.Windows.Forms.Button btnItem;
        private CustomControl.Heading heading;
        private System.Windows.Forms.Button btnInvoice;
    }
}