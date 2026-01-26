using Invoice.UI.CustomControl.EventArguments;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Invoice.UI.CustomControl
{
    public partial class MainData : UserControl
    {

        public delegate void ButtonClickHandler(object sender, EventArgs e);
        public event ButtonClickHandler OnAddButtonClicked;
        public event ButtonClickHandler OnEditButtonClicked;
        public event ButtonClickHandler OnDeleteButtonClicked;
        public event SearchCriteriaHandler OnSearchCriteriaUpdated;


        private string _heading = "Heading";
        private DataTable _dataSource = new DataTable();
        private IDataGridFormatter _gridFormatter;
        private readonly List<SearchCriteriaEventArgs> _filterAttributes;

        public MainData(IDataGridFormatter gridFormatter)
        {
            InitializeComponent();
            this._gridFormatter = gridFormatter;
            this._filterAttributes = new List<SearchCriteriaEventArgs>();
            this.dgvData.DataSourceChanged += DgvData_DataSourceChanged;
            this.searchControl1.OnSearchCriteriaAdded += SearchControl1_OnSearchCriteriaAdded;
            this.searchControl1.OnSearchCriteriaRemoved += SearchControl1_OnSearchCriteriaRemoved;
        }

        public List<SearchCriteriaEventArgs> FilterAttributes { get { return _filterAttributes; } }

        private void SearchControl1_OnSearchCriteriaRemoved(object sender, SearchCriteriaEventArgs e)
        {

           var attributeByName = this._filterAttributes.FirstOrDefault(x => x.FieldName.Equals(e.FieldName));

            this._filterAttributes.Remove(attributeByName);

            if (OnSearchCriteriaUpdated != null)
                this.OnSearchCriteriaUpdated.Invoke(sender, e);
        }

        private void SearchControl1_OnSearchCriteriaAdded(object sender, SearchCriteriaEventArgs e)
        {
            this._filterAttributes.Add(e);

            if (OnSearchCriteriaUpdated != null)
                this.OnSearchCriteriaUpdated.Invoke(sender, e);
        }

        private void DgvData_DataSourceChanged(object sender, EventArgs e)
        {
            DataTable sourceTable = this.dgvData.DataSource as DataTable;

            if (sourceTable == null) return;

            List<string> fieldSource = new List<string>();

            for (int index = 0; index < sourceTable.Columns.Count; index++)
            {
                fieldSource.Add(this.dgvData.Columns[index].Name);
            }

            this.searchControl1.FieldSource = fieldSource;

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

        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left) && dgvData.SelectedRows.Count > 0)
            {
                if (OnEditButtonClicked != null)
                {
                    OnEditButtonClicked.Invoke(sender, e);
                }
            }
        }

        private void searchControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
