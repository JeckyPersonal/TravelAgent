using Invoice.UI.DTO;
using Invoice.UI.Item;
using System.Collections.Generic;
using System.Data;

namespace Invoice.UI.Main.PresenterFactory
{
    internal class ItemOverviewPresenter : IOverviewPresenter
    {

        private readonly DataTable _table;
        private readonly ItemRestClient _restClient;

        public ItemOverviewPresenter(ItemRestClient restClient)
        {
            this._table = new DataTable();
            this._restClient = restClient;
        }

        public DataTable BuildTable()
        {
            List<ItemMasterDto> items = this._restClient.GetAll();

            this._table.Clear();

            this._table.Columns.Add(ItemTableFormatter.COLUMN_NAME_ID);
            this._table.Columns.Add(ItemTableFormatter.COLUMN_NAME_NAME);
            this._table.Columns.Add(ItemTableFormatter.COLUMN_NAME_RATE);
            this._table.Columns.Add(ItemTableFormatter.COLUMN_NAME_APPLIED_GST);

            foreach (ItemMasterDto item in items)
            {
                DataRow row = this._table.NewRow();

                row[ItemTableFormatter.COLUMN_NAME_ID] = item.Id;
                row[ItemTableFormatter.COLUMN_NAME_NAME] = item.ItemName;
                row[ItemTableFormatter.COLUMN_NAME_RATE] = item.Rate;
                row[ItemTableFormatter.COLUMN_NAME_APPLIED_GST] = item.AppliedGST;
            }

            return this._table;

        }

        public BasePresenter CreatePresenter()
        {
            ItemPresenter presenter = new ItemPresenter(ItemRestClient.Instance);
            frmItem itemMaster = new frmItem(presenter);
            presenter.SetView(itemMaster);

            return presenter;
        }

        public IDataGridFormatter GetDataGridFormatter()
        {
            return ItemTableFormatter.Instance;
        }

        public Menu GetMenu()
        {
            return Menu.Item;
        }
    }
}
