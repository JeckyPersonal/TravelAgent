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
        private IDataGridFormatter _gridFormatter;

        public MainData(IDataGridFormatter gridFormatter)
        {
            InitializeComponent();
            this._gridFormatter = gridFormatter;
        }

        public string Heading
        {
            get
            {
                return _heading;
            }
            set
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

        public object SelectedItem
        {
            get
            {
                if(this.dgvData.SelectedRows.Count == 0)
                    return null;

                return this.dgvData.SelectedRows[0].DataBoundItem;
            }
        }

        public void FormatTable()
        {
            this._gridFormatter.ResizeColumn(this.dgvData);
        }

        public void Refresh()
        {
            base.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (OnAddButtonClicked != null)
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

        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0) 
            {
                if (OnEditButtonClicked != null)
                {
                    OnEditButtonClicked.Invoke(sender, e);
                }
            }
        }
    }
}
