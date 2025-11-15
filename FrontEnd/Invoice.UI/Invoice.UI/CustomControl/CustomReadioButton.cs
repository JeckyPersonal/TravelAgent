using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.CustomControl
{
    public partial class CustomReadioButton : RadioButton
    {
        private Color CHECKED_BACKGROUND_COLOUR = Color.FromArgb(255, 192, 192);
        private Color UNCHECKED_BACKGROUND_COLOR = Color.FromArgb(255, 248, 241); //Color.Olive;
        private Color CHECKED_FOR_COLOR = Color.FromArgb(110, 44, 0);
        private Color UNCHECKED_FOR_COLOR = Color.FromArgb(110, 44, 0);
        private Color BORDER_COLOR = Color.FromArgb(211, 84, 0);
        private Color MOUSE_HOVER_COLOR = Color.FromArgb(255, 224, 192);

        public CustomReadioButton()
        {
            InitializeComponent();
            this.Appearance = System.Windows.Forms.Appearance.Button;
            this.BackColor = UNCHECKED_BACKGROUND_COLOR;
            //this.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.FlatAppearance.CheckedBackColor = CHECKED_BACKGROUND_COLOUR; //System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.FlatAppearance.BorderColor = BORDER_COLOR;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForeColor = UNCHECKED_FOR_COLOR;
            this.TabIndex = 13;
            this.Text = "Applied GST";
            this.UseVisualStyleBackColor = false;
            this.CheckedChanged += CustomReadioButton_CheckedChanged;
        }

        private void CustomReadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Checked)
            {
                this.BackColor = CHECKED_BACKGROUND_COLOUR;
                this.ForeColor = CHECKED_FOR_COLOR;
            }
            else
            {
                this.BackColor = UNCHECKED_BACKGROUND_COLOR;
                this.ForeColor = UNCHECKED_FOR_COLOR;
            }
        }
    }
}
