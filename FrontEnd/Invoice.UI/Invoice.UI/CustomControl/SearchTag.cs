using System;
using System.Windows.Forms;

namespace Invoice.UI.CustomControl
{
    public partial class SearchTag : UserControl
    {
        private string _fieldName;
        private string _operator;
        private string _value;

        public string FieldName
        {
            get { return _fieldName; }
            set
            {
                _fieldName = value;
                lblFieldName.Text = _fieldName;
            }
        }

        public string Operator
        {
            get { return _operator; }
            set
            {
                _operator = value;
                lblOperator.Text = _operator;
            }
        }

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                lblFieldValue.Text = _value;
            }
        }

        public SearchTag()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Label lblClose = sender as Label;

            this.Parent.Controls.Remove(this);
        }
    }
}
