using Invoice.UI.DTO;
using Invoice.UI.Item;
using Invoice.UI.Vehicle.RateConfiguration;
using System.Collections.Generic;
using System.Data;

namespace Invoice.UI.Main.PresenterFactory
{
    internal class ItemOverviewPresenter : IOverviewPresenter
    {

        private readonly DataTable _table;
        private readonly ItemRestClient _restClient;
        private readonly IDataGridFormatter _tableFormatter;
        private readonly IRowAdder<ItemMasterDto> _rowAdder;

        public ItemOverviewPresenter(ItemRestClient restClient, IDataGridFormatter dataGridFromatter)
        {
            this._table = new DataTable();
            this._restClient = restClient;
            this._tableFormatter = dataGridFromatter;
            this._rowAdder = dataGridFromatter as IRowAdder<ItemMasterDto>;
        }

        public DataTable BuildTable()
        {
            this._table.Columns.Clear();

            this._rowAdder.BuildTable(new ItemEntityLoader(this._restClient), this._table);

            return this._table;
        }

        public BasePresenter CreatePresenter()
        {
            ItemPresenter presenter = new ItemPresenter(ItemRestClient.Instance);
            frmItem itemMaster = new frmItem(presenter);
            presenter.SetView(itemMaster);

            return presenter;
        }

        public bool DeleteRecord(DataRow selectedRow)
        {
            ItemMasterDto companyDto = this._rowAdder.GetObject(selectedRow);

            this._restClient.Delete(companyDto);

            return true;
        }

        public IDataGridFormatter GetDataGridFormatter()
        {
            return _tableFormatter; 
        }

        public Menu GetMenu()
        {
            return Menu.Item;
        }
    }
}
