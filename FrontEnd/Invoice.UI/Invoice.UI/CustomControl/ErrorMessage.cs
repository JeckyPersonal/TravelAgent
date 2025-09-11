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
    public partial class ErrorMessage : UserControl
    {

        private string _errorMessage = string.Empty;
        public ErrorMessage()
        {
            InitializeComponent();
        }

        public string Message
        {
            get { return _errorMessage; }

            set { 
                this._errorMessage = value;
                label1.Text = value;
            }
        }
    }
}
