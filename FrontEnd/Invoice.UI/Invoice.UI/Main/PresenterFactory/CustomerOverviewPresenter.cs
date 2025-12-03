using Invoice.UI.Customer;
using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System.Collections.Generic;
using System.Data;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;

namespace Invoice.UI.Main.PresenterFactory
{
    public class CustomerOverviewPresenter : IOverviewPresenter
    {

        private readonly CustomerRestClient _restClient;
        private DataTable _table;
        private readonly IDataGridFormatter _gridFormatter;
        private readonly IRowAdder<CustomerDto> _rowAdder;
        public CustomerOverviewPresenter(CustomerRestClient restClient)
        {
            this._restClient = restClient;
            this._table = new DataTable();
            this._gridFormatter = new CustomerTableFormatter();
            this._rowAdder = this._gridFormatter as IRowAdder<CustomerDto>;
        }

        public DataTable BuildTable()
        {
            this._table.Columns.Clear();

            List<CustomerDto> customers = this._restClient.GetAll();

            this._rowAdder.AddColumns(this._table);

            this._table.Clear();

            foreach(CustomerDto customer in  customers)
            {
                DataRow row = this._table.NewRow();

                this._rowAdder.AddRow(customer, row);

                this._table.Rows.Add(row);
            }

            return this._table;
        }

        public BasePresenter CreatePresenter()
        {
            CustomerPresenter customerPresenter = new CustomerPresenter(this._restClient);
            frmCustomer customerView = new frmCustomer(customerPresenter);

            return customerPresenter;
        }

        public bool DeleteRecord(DataRow selectedRow)
        {
            CustomerDto customerDto = this._rowAdder.GetObject(selectedRow);

            this._restClient.Delete(customerDto);

            return true;
        }

        public IDataGridFormatter GetDataGridFormatter()
        {
            return this._gridFormatter;
        }

        public Menu GetMenu()
        {
            return Menu.Customer;
        }
    }
}