namespace Invoice.UI.CustomControl
{
    partial class SearchControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbFieldName = new System.Windows.Forms.ComboBox();
            this.txtSearchVal = new System.Windows.Forms.TextBox();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.flowPnlSearchCriteria = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 475F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel1.Controls.Add(this.cmbFieldName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchVal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlButton, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2334, 83);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cmbFieldName
            // 
            this.cmbFieldName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFieldName.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.cmbFieldName.FormattingEnabled = true;
            this.cmbFieldName.Location = new System.Drawing.Point(10, 9);
            this.cmbFieldName.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.cmbFieldName.Name = "cmbFieldName";
            this.cmbFieldName.Size = new System.Drawing.Size(455, 55);
            this.cmbFieldName.TabIndex = 0;
            // 
            // txtSearchVal
            // 
            this.txtSearchVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchVal.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.txtSearchVal.Location = new System.Drawing.Point(485, 9);
            this.txtSearchVal.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.txtSearchVal.Name = "txtSearchVal";
            this.txtSearchVal.Size = new System.Drawing.Size(1646, 55);
            this.txtSearchVal.TabIndex = 1;
            this.txtSearchVal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbFillValue_KeyDown);
            this.txtSearchVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFillValue_KeyPress);
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnReset);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButton.Location = new System.Drawing.Point(2141, 0);
            this.pnlButton.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(193, 77);
            this.pnlButton.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(225)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(10, 9);
            this.btnReset.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(174, 63);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // flowPnlSearchCriteria
            // 
            this.flowPnlSearchCriteria.AutoSize = true;
            this.flowPnlSearchCriteria.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowPnlSearchCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPnlSearchCriteria.Location = new System.Drawing.Point(0, 83);
            this.flowPnlSearchCriteria.Margin = new System.Windows.Forms.Padding(0);
            this.flowPnlSearchCriteria.Name = "flowPnlSearchCriteria";
            this.flowPnlSearchCriteria.Size = new System.Drawing.Size(2334, 0);
            this.flowPnlSearchCriteria.TabIndex = 1;
            this.flowPnlSearchCriteria.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flowPnlSearchCriteria_ControlAdded);
            this.flowPnlSearchCriteria.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.flowPnlSearchCriteria_ControlRemoved);
            // 
            // SearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.flowPnlSearchCriteria);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "SearchControl";
            this.Size = new System.Drawing.Size(2334, 83);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbFieldName;
        private System.Windows.Forms.TextBox txtSearchVal;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.FlowLayoutPanel flowPnlSearchCriteria;
    }
}
