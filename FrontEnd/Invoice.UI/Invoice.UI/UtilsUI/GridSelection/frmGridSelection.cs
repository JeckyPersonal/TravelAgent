using Invoice.UI.DTO;
using Invoice.UI.Rental;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Invoice.UI.UtilsUI.GridSelection
{
    internal partial class frmGridSelection<T> : TitledForm, IGridSelectionView<T>
    {
        private readonly GridSelectionPresenter<T> _presenter;
        private IDataGridFormatter _formatter;
        public frmGridSelection(string title, GridSelectionPresenter<T> presenter)
        {
            InitializeComponent();
            this._presenter = presenter;
            this._presenter.SetView(this);
            this.heading1.Title = title;
        }
        public void SetGridFormatter(IDataGridFormatter gridFormatter)
        {
            this._formatter = gridFormatter;
        }

        public void SetGridSource(DataTable table)
        {
            this.dgvData.DataSource = table;
            this._formatter.ResizeColumn(this.dgvData);
        }

        private void frmGridSelection_Load(object sender, EventArgs e)
        {
            this._presenter.LoadData();
            this._formatter.ResizeColumn(this.dgvData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._presenter.CloseUI();
        }

        public List<DataRow> GetSelectedRow()
        {
            List<DataRow> rows = new List<DataRow>();

            if (this.dgvData.Rows.Count == 0) return rows;

            for(int index =0; index < this.dgvData.SelectedRows.Count;index++)
            {
                DataRowView rowView = this.dgvData.SelectedRows[index].DataBoundItem as DataRowView;
                rows.Add(rowView.Row);
            }

            return rows;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
