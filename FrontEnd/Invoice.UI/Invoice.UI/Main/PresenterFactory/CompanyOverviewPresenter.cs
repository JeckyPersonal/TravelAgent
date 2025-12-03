using Invoice.DTO;
using Invoice.UI.Company;
using Invoice.UI.Exceptions;
using Invoice.UI.Payment;
using Invoice.UI.Vehicle.RateConfiguration;
using System.Collections.Generic;
using System.Data;

namespace Invoice.UI.Main.PresenterFactory
{
    internal class CompanyOverviewPresenter : IOverviewPresenter
    {
        private readonly CompanyRestClient _restClient;
        DataTable _table;
        private readonly IDataGridFormatter _formatter;
        private readonly IRowAdder<CompanyDto> _rowAdder;

        public CompanyOverviewPresenter(CompanyRestClient restClient)
        {
            this._restClient = restClient;
            this._table = new DataTable();
            this._formatter = new CompanyTableFormatter();
            this._rowAdder = this._formatter as IRowAdder<CompanyDto>;
        }

        public BasePresenter CreatePresenter()
        {
            CompanyPresenter presenter = new CompanyPresenter(CompanyRestClient.Instance);
            frmCompany company = new frmCompany(presenter);
            presenter.SetView(company);

            return presenter;
        }

        public IDataGridFormatter GetDataGridFormatter()
        {
            return new CompanyTableFormatter();
        }

        public Menu GetMenu()
        {
            return Menu.Company;
        }

        public DataTable BuildTable()
        {
            _rowAdder.BuildTable(new CompanyEntityLoader(this._restClient), this._table);
            return this._table;
        }

        public bool DeleteRecord(DataRow selectedRow)
        {
            try
            {
                CompanyDto companyDto = this._rowAdder.GetObject(selectedRow);

                this._restClient.Delete(companyDto);

                return true;
            }
            catch (ValidationException vex)
            {
                return false;
            }
        }
    }
}
