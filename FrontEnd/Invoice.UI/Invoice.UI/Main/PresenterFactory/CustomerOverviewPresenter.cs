using Invoice.UI.Customer;
using Invoice.UI.DTO;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace Invoice.UI.Main.PresenterFactory
{
    public class CustomerOverviewPresenter : IOverviewPresenter
    {

        private readonly CustomerRestClient _restClient;
        private DataTable _table;
        public CustomerOverviewPresenter(CustomerRestClient restClient)
        {
            this._restClient = restClient;
            this._table = new DataTable();
        }

        public DataTable BuildTable()
        {
            this._table.Columns.Clear();

            List<CustomerDto> customers = this._restClient.GetAll();

            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_ID);
            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_NAME);
            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_ADDRESS1);
            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_ADDRESS2);
            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_ADDRESS3);
            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_CITY);
            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_STATE);
            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_COUNTRY);
            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_PHONE);
            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_ZIP);
            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_PAN);
            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_GST);
            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_CESS);
            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_TAX_CATEGORY);
            this._table.Columns.Add(CustomerTableFormatter.COLUMN_NAME_INVOICE_FORMAT);

            this._table.Clear();

            foreach(CustomerDto customer in  customers)
            {
                DataRow row = this._table.NewRow();

                row[CustomerTableFormatter.COLUMN_NAME_ID] = customer.Id;
                row[CustomerTableFormatter.COLUMN_NAME_NAME] = customer.Name;
                row[CustomerTableFormatter.COLUMN_NAME_ADDRESS1] = customer.Address1;
                row[CustomerTableFormatter.COLUMN_NAME_ADDRESS2] = customer.Address2;
                row[CustomerTableFormatter.COLUMN_NAME_ADDRESS3] = customer.Address3;
                row[CustomerTableFormatter.COLUMN_NAME_CITY] = customer.City;
                row[CustomerTableFormatter.COLUMN_NAME_STATE] = customer.State;
                row[CustomerTableFormatter.COLUMN_NAME_COUNTRY] = customer.Country;
                row[CustomerTableFormatter.COLUMN_NAME_PHONE] = customer.PhoneNumber;
                row[CustomerTableFormatter.COLUMN_NAME_ZIP] = customer.Zip;
                row[CustomerTableFormatter.COLUMN_NAME_PAN] = customer.PANNo;
                row[CustomerTableFormatter.COLUMN_NAME_GST] = customer.GSTNo;
                row[CustomerTableFormatter.COLUMN_NAME_CESS] = customer.CessNo;
                row[CustomerTableFormatter.COLUMN_NAME_TAX_CATEGORY] = customer.TaxCategory;
                row[CustomerTableFormatter.COLUMN_NAME_INVOICE_FORMAT] = customer.InvoiceFormat;

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

        public IDataGridFormatter GetDataGridFormatter()
        {
            return new CustomerTableFormatter();
        }

        public Menu GetMenu()
        {
            return Menu.Customer;
        }
    }
}