using Invoice.DTO;
using Invoice.UI.Company;
using System.Collections.Generic;
using System.Data;

namespace Invoice.UI.Main.PresenterFactory
{
    internal class CompanyOverviewPresenter : IOverviewPresenter
    {
        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_NAME = "Name";
        private const string COLUMN_NAME_ADDRESS1 = "Address1";
        private const string COLUMN_NAME_ADDRESS2 = "Address2";
        private const string COLUMN_NAME_ADDRESS3 = "Address3";
        private const string COLUMN_NAME_CITY = "City";
        private const string COLUMN_NAME_STATE = "State";
        private const string COLUMN_NAME_ZIP = "Zip";
        private const string COLUMN_NAME_COUNTRY = "Country";
        private const string COLUMN_NAME_GST = "GST";
        private const string COLUMN_NAME_PAN = "PAN";
        private const string COLUMN_NAME_PHONE = "Phone";

        private readonly CompanyRestClient _restClient;
        DataTable _table;

        public CompanyOverviewPresenter(CompanyRestClient restClient)
        {
            this._restClient = restClient;
            this._table = new DataTable();
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
            List<CompanyDto> companies = CompanyRestClient.Instance.GetAllCompany();

            buildTable(companies);

            return this._table;
        }

        private void buildTable(List<CompanyDto> companies)
        {
            if (_table != null)
                _table.Rows.Clear();

            _table = new DataTable();

            _table.Columns.Add(new DataColumn(COLUMN_NAME_ID));
            _table.Columns.Add(new DataColumn(COLUMN_NAME_NAME));
            _table.Columns.Add(new DataColumn(COLUMN_NAME_ADDRESS1));
            _table.Columns.Add(new DataColumn(COLUMN_NAME_ADDRESS2));
            _table.Columns.Add(new DataColumn(COLUMN_NAME_ADDRESS3));
            _table.Columns.Add(new DataColumn(COLUMN_NAME_CITY));
            _table.Columns.Add(new DataColumn(COLUMN_NAME_STATE));
            _table.Columns.Add(new DataColumn(COLUMN_NAME_ZIP));
            _table.Columns.Add(new DataColumn(COLUMN_NAME_COUNTRY));
            _table.Columns.Add(new DataColumn(COLUMN_NAME_PHONE));
            _table.Columns.Add(new DataColumn(COLUMN_NAME_GST));
            _table.Columns.Add(new DataColumn(COLUMN_NAME_PAN));

            foreach (CompanyDto companyDto in companies)
            {
                DataRow row = _table.NewRow();
                row[COLUMN_NAME_ID] = companyDto.Id;
                row[COLUMN_NAME_NAME] = companyDto.Name;
                row[COLUMN_NAME_ADDRESS1] = companyDto.Address1;
                row[COLUMN_NAME_ADDRESS2] = companyDto.Address2;
                row[COLUMN_NAME_ADDRESS3] = companyDto.Address3;
                row[COLUMN_NAME_CITY] = companyDto.City;
                row[COLUMN_NAME_STATE] = companyDto.State;
                row[COLUMN_NAME_ZIP] = companyDto.Zip;
                row[COLUMN_NAME_COUNTRY] = companyDto.Country;
                row[COLUMN_NAME_PHONE] = companyDto.PhoneNumber;
                row[COLUMN_NAME_GST] = companyDto.GSTNo;
                row[COLUMN_NAME_PAN] = companyDto.PANNo;

                _table.Rows.Add(row);
            }
        }
    }
}
