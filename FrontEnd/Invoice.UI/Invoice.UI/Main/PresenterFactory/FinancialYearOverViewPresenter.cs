using Invoice.UI.DTO;
using Invoice.UI.FinancialYear;
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

        public FinancialYearOverViewPresenter(FinancialYearRestClient restClient)
        {
            this._restClient = restClient;
            this._table = new DataTable();
        }

        public DataTable BuildTable()
        {
            List<FinancialYearDto> financialYearDtos = this._restClient.GetAll();

            this._table.Columns.Clear();

            this._table.Clear();

            this._table.Columns.Add(FinancialYearGridFormatter.COLUMN_NAME_ID);
            this._table.Columns.Add(FinancialYearGridFormatter.COLUMN_NAME_FROM_DATE);
            this._table.Columns.Add(FinancialYearGridFormatter.COLUMN_NAME_TO_DATE);

            foreach (FinancialYearDto financialYearDto in financialYearDtos)
            {
                DataRow row = this._table.NewRow();

                row[FinancialYearGridFormatter.COLUMN_NAME_ID] = financialYearDto.Id;
                row[FinancialYearGridFormatter.COLUMN_NAME_FROM_DATE] = financialYearDto.FromDate;
                row[FinancialYearGridFormatter.COLUMN_NAME_TO_DATE] = financialYearDto.ToDate;

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

        public IDataGridFormatter GetDataGridFormatter()
        {
            return FinancialYearGridFormatter.Instance;
        }

        public Menu GetMenu()
        {
            return Menu.FinancialYear;
        }
    }
}
