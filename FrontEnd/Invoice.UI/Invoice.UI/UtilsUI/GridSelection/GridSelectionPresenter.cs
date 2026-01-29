using Invoice.UI.DTO;
using Invoice.UI.Rental;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Invoice.UI.UtilsUI.GridSelection
{
    internal class GridSelectionPresenter<T>
    {
        private IGridSelectionView<T> _view;
        private readonly IDataGridFormatter _gridFormatter;
        private readonly DataTable _table;
        private readonly IRowAdder<T> _tableOperations;
        private readonly List<T> _datas;
        private EntityLoader<T> _entityLoader;

        public GridSelectionPresenter(IDataGridFormatter gridFormatter, IRowAdder<T> tableOperations)
        {
            _gridFormatter = gridFormatter;
            _table = new DataTable();
            _tableOperations = tableOperations;
        }

        internal void LoadData()
        {
            _table.Clear();

            if (_table.Columns.Count == 0) {
                this._tableOperations.AddColumns(_table);
            }
            this._tableOperations.BuildTable(_entityLoader, _table);
            this._view.SetGridSource(this._table);
        }

        internal List<T> OpenUI()
        {
            this._view.ShowDialog();
            if (this._view.DialogResult == DialogResult.OK)
            {
                List<DataRow> row = this._view.GetSelectedRow();

                this._view.Close();

                return row.Select(x => this._tableOperations.GetObject(x)).ToList();
            } 
            else
            {
                return null;
            }
        }

        internal void SetView(IGridSelectionView<T> view)
        {
            this._view = view;
            this._view.SetGridFormatter(this._gridFormatter);
        }

        internal bool IsSuccess()
        {
            return this._view.DialogResult == DialogResult.OK;
        }

        internal void SetEntityLoader(EntityLoader<T> entityLoader)
        {
            this._entityLoader = entityLoader;
        }

        internal void CloseUI()
        {
            this._view.Close();
        }
    }
}