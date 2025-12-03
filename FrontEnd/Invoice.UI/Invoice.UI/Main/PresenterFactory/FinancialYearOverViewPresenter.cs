using Invoice.DTO;
using Invoice.UI.DTO;
using Invoice.UI.FinancialYear;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Main.PresenterFactory
{
    internal class FinancialYearOverViewPresenter : IOverviewPresenter
    {

        private readonly FinancialYearRestClient _restClient;
        private readonly DataTable _table;
        private readonly IDataGridFormatter _formatter;
        private readonly IRowAdder<FinancialYearDto> _rowAdder;

        public FinancialYearOverViewPresenter(FinancialYearRestClient restClient)
        {
            this._restClient = restClient;
            this._formatter = FinancialYearGridFormatter.Instance;
            this._rowAdder = this._formatter as IRowAdder<FinancialYearDto>;
            this._table = new DataTable();
        }

        public DataTable BuildTable()
        {
            List<FinancialYearDto> financialYearDtos = this._restClient.GetAll();

            this._table.Clear();

            this._rowAdder.AddColumns(this._table);

            foreach (FinancialYearDto financialYearDto in financialYearDtos)
            {
                DataRow row = this._table.NewRow();

                this._rowAdder.AddRow(financialYearDto, row);

                this._table.Rows.Add(row);
            }

            return this._table;
        }

        public BasePresenter CreatePresenter()
        {
            FinancialYearPresenter presenter = new FinancialYearPresenter(this._restClient);
            frmFinancialYear financialYear = new frmFinancialYear(presenter);
            return presenter;
        }

        public bool DeleteRecord(DataRow selectedRow)
        {
            FinancialYearDto companyDto = this._rowAdder.GetObject(selectedRow);

            this._restClient.Delete(companyDto);

            return true;
        }

        public IDataGridFormatter GetDataGridFormatter()
        {
            return this._formatter;
        }

        public Menu GetMenu()
        {
            return Menu.FinancialYear;
        }
    }
}
