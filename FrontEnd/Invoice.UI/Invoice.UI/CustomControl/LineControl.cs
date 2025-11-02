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
    public partial class LineControl : UserControl
    {
        private string _title;
        public LineControl()
        {
            InitializeComponent();
            this._title = "Title";
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                this.lblHeading.Text = value;
            }

        }
    }
}
