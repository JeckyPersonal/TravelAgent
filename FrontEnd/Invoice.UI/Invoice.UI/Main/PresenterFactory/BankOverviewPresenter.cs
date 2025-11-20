using Invoice.UI.Bank;
using Invoice.UI.DTO;
using Invoice.UI.Main;
using Invoice.UI.Main.PresenterFactory;
using System;
using System.Collections.Generic;
using System.Data;

namespace Invoice.UI
{
    internal class BankOverviewPresenter : IOverviewPresenter
    {
        private readonly DataTable _table;
        private readonly BankRestClient _restClient;

        public BankOverviewPresenter(BankRestClient restClient)
        {
            this._table = new DataTable();
            this._restClient = restClient;
        }

        public DataTable BuildTable()
        {
            this._table.Columns.Clear();

            buildTable(); 

            return this._table;
        }

        public BasePresenter CreatePresenter()
        {
            BankPresenter bankPresenter = new BankPresenter(BankRestClient.Instance);
            frmBank bankUI = new frmBank(bankPresenter);
            bankPresenter.SetView(bankUI);

            return bankPresenter;
        }

        public IDataGridFormatter GetDataGridFormatter()
        {
            return BankTableFormatter.Instance;
        }

        public Menu GetMenu()
        {
            return Menu.Bank;
        }

        public void buildTable()
        {
            if (_table != null)
                _table.Rows.Clear();

            _table.Columns.Clear();

            this._table.Columns.Add(new DataColumn(BankTableFormatter.COLUMN_NAME_ID));
            this._table.Columns.Add(new DataColumn(BankTableFormatter.COLUMN_NAME_NAME));

            List<BankDto> banks = this._restClient.GetAll();

            foreach (BankDto bank in banks)
            {
                DataRow row = this._table.NewRow();

                row[BankTableFormatter.COLUMN_NAME_ID] = bank.Id;
                row[BankTableFormatter.COLUMN_NAME_NAME] = bank.BankName;
                this._table.Rows.Add(row);
            }
        }
    }
}
