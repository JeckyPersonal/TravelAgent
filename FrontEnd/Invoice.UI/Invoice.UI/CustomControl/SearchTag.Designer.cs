namespace Invoice.UI.CustomControl
{
    partial class SearchTag
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
            this.lblFieldName = new System.Windows.Forms.Label();
            this.lblOperator = new System.Windows.Forms.Label();
            this.lblFieldValue = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.pnlTag = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTag.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFieldName
            // 
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.ForeColor = System.Drawing.Color.White;
            this.lblFieldName.Location = new System.Drawing.Point(3, 0);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblFieldName.Size = new System.Drawing.Size(73, 19);
            this.lblFieldName.TabIndex = 0;
            this.lblFieldName.Text = "FieldName";
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperator.ForeColor = System.Drawing.Color.White;
            this.lblOperator.Location = new System.Drawing.Point(82, 0);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblOperator.Size = new System.Drawing.Size(72, 19);
            this.lblOperator.TabIndex = 1;
            this.lblOperator.Text = "Operator";
            // 
            // lblFieldValue
            // 
            this.lblFieldValue.AutoSize = true;
            this.lblFieldValue.ForeColor = System.Drawing.Color.White;
            this.lblFieldValue.Location = new System.Drawing.Point(160, 0);
            this.lblFieldValue.Name = "lblFieldValue";
            this.lblFieldValue.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblFieldValue.Size = new System.Drawing.Size(72, 19);
            this.lblFieldValue.TabIndex = 2;
            this.lblFieldValue.Text = "FieldValue";
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(235, 0);
            this.lblClose.Margin = new System.Windows.Forms.Padding(0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Padding = new System.Windows.Forms.Padding(3);
            this.lblClose.Size = new System.Drawing.Size(23, 22);
            this.lblClose.TabIndex = 3;
            this.lblClose.Text = "X";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // pnlTag
            // 
            this.pnlTag.AutoSize = true;
            this.pnlTag.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlTag.BackColor = System.Drawing.Color.Navy;
            this.pnlTag.Controls.Add(this.lblFieldName);
            this.pnlTag.Controls.Add(this.lblOperator);
            this.pnlTag.Controls.Add(this.lblFieldValue);
            this.pnlTag.Controls.Add(this.lblClose);
            this.pnlTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTag.Location = new System.Drawing.Point(2, 2);
            this.pnlTag.Name = "pnlTag";
            this.pnlTag.Size = new System.Drawing.Size(264, 34);
            this.pnlTag.TabIndex = 4;
            // 
            // SearchTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Navy;
            this.Controls.Add(this.pnlTag);
            this.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchTag";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(268, 38);
            this.pnlTag.ResumeLayout(false);
            this.pnlTag.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label lblFieldValue;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.FlowLayoutPanel pnlTag;
    }
}
