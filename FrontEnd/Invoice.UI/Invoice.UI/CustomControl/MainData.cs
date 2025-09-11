using System;
using System.Data;
using System.Windows.Forms;

namespace Invoice.UI.CustomControl
{
    public partial class MainData : UserControl
    {

        public delegate void ButtonClickHandler(object sender, EventArgs e);
        public event ButtonClickHandler OnAddButtonClicked;
        public event ButtonClickHandler OnEditButtonClicked;
        public event ButtonClickHandler OnDeleteButtonClicked;


        private string _heading = "Heading";
        private DataTable _dataSource = new DataTable();

        public MainData()
        {
            InitializeComponent();
        }

        public string Heading
        {
            get
            {
                return Heading;
            } set
            {
                this._heading = value;
                lblHeading.Text = value;
            }
        }

        public DataTable DataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                this.dgvData.DataSource = value;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(OnAddButtonClicked != null)
            {
                OnAddButtonClicked.Invoke(sender, e);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (OnEditButtonClicked != null)
            {
                OnEditButtonClicked.Invoke(sender, e);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (OnDeleteButtonClicked != null)
            {
                OnDeleteButtonClicked.Invoke(sender, e);
            }

        }
    }
}
