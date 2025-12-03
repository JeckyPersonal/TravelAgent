using Invoice.UI.Bank;
using Invoice.UI.DTO;
using Invoice.UI.Main;
using Invoice.UI.Main.PresenterFactory;
using Invoice.UI.Rental;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;

namespace Invoice.UI
{
    internal class BankOverviewPresenter : IOverviewPresenter
    {
        private readonly DataTable _table;
        private readonly BankRestClient _restClient;
        private readonly IDataGridFormatter _formatter;
        private readonly IRowAdder<BankDto> _rowAdder; 

        public BankOverviewPresenter(BankRestClient restClient)
        {
            this._table = new DataTable();
            this._restClient = restClient;
            this._formatter = BankTableFormatter.Instance;
            this._rowAdder = this._formatter as IRowAdder<BankDto>;
        }

        public DataTable BuildTable()
        {
            this._table.Columns.Clear();

            this.buildTable();

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
            return this._formatter;
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

            this._rowAdder.AddColumns(this._table);

            List<BankDto> banks = this._restClient.GetAll();

            foreach (BankDto bank in banks)
            {
                DataRow row = this._table.NewRow();

                this._rowAdder.AddRow(bank, row);

                this._table.Rows.Add(row);
            }
        }

        public bool DeleteRecord(DataRow selectedRow)
        {
            BankDto bankDto = this._rowAdder.GetObject(selectedRow);

            this._restClient.Delete(bankDto);

            return true;
        }
    }
}
