using Invoice.UI.DTO;
using Invoice.UI.Main;
using Invoice.UI.Main.PresenterFactory;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Customer
{
    internal class CustomerTableFormatter : IDataGridFormatter, IRowAdder<CustomerDto>
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
        private const string COLUMN_NAME_CESS = "Cess";
        private const string COLUMN_NAME_TAX_CATEGORY = "Tax Category";
        private const string COLUMN_NAME_INVOICE_FORMAT = "Invoice Format";

        public void AddColumns(DataTable table)
        {
            if (table.Columns.Count > 0) return;

            table.Columns.Add(COLUMN_NAME_ID);
            table.Columns.Add(COLUMN_NAME_NAME);
            table.Columns.Add(COLUMN_NAME_ADDRESS1);
            table.Columns.Add(COLUMN_NAME_ADDRESS2);
            table.Columns.Add(COLUMN_NAME_ADDRESS3);
            table.Columns.Add(COLUMN_NAME_CITY);
            table.Columns.Add(COLUMN_NAME_STATE);
            table.Columns.Add(COLUMN_NAME_COUNTRY);
            table.Columns.Add(COLUMN_NAME_PHONE);
            table.Columns.Add(COLUMN_NAME_ZIP);
            table.Columns.Add(COLUMN_NAME_PAN);
            table.Columns.Add(COLUMN_NAME_GST);
            table.Columns.Add(COLUMN_NAME_CESS);
            table.Columns.Add(COLUMN_NAME_TAX_CATEGORY);
            table.Columns.Add(COLUMN_NAME_INVOICE_FORMAT);
        }

        public void AddRow(CustomerDto customer, DataRow row)
        {
            row[COLUMN_NAME_ID] = customer.Id;
            row[COLUMN_NAME_NAME] = customer.Name;
            row[COLUMN_NAME_ADDRESS1] = customer.Address1;
            row[COLUMN_NAME_ADDRESS2] = customer.Address2;
            row[COLUMN_NAME_ADDRESS3] = customer.Address3;
            row[COLUMN_NAME_CITY] = customer.City;
            row[COLUMN_NAME_STATE] = customer.State;
            row[COLUMN_NAME_COUNTRY] = customer.Country;
            row[COLUMN_NAME_PHONE] = customer.PhoneNumber;
            row[COLUMN_NAME_ZIP] = customer.Zip;
            row[COLUMN_NAME_PAN] = customer.PANNo;
            row[COLUMN_NAME_GST] = customer.GSTNo;
            row[COLUMN_NAME_CESS] = customer.CessNo;
            row[COLUMN_NAME_TAX_CATEGORY] = customer.TaxCategory;
            row[COLUMN_NAME_INVOICE_FORMAT] = customer.InvoiceFormat;
        }

        public void AppendRows(EntityLoader<CustomerDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }

        public void BuildTable(EntityLoader<CustomerDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }

        public CustomerDto GetObject(DataRow row)
        {
            CustomerDto customer = new CustomerDto();

            customer.Id = Convert.ToInt32(row[COLUMN_NAME_ID]);
            customer.Name = Convert.ToString(row[COLUMN_NAME_NAME]);
            customer.Address1 = Convert.ToString(row[COLUMN_NAME_ADDRESS1]);
            customer.Address2 = Convert.ToString(row[COLUMN_NAME_ADDRESS2]);
            customer.Address3 = Convert.ToString(row[COLUMN_NAME_ADDRESS3]);
            customer.City = Convert.ToString(row[COLUMN_NAME_CITY]);
            customer.State = Convert.ToString(row[COLUMN_NAME_STATE]);
            customer.Country = Convert.ToString(row[COLUMN_NAME_COUNTRY]);
            customer.PhoneNumber = Convert.ToString(row[COLUMN_NAME_PHONE]);
            customer.Zip = Convert.ToString(row[COLUMN_NAME_ZIP]);
            customer.PANNo = Convert.ToString(row[COLUMN_NAME_PAN]);
            customer.GSTNo = Convert.ToString(row[COLUMN_NAME_GST]);
            customer.CessNo = Convert.ToString(row[COLUMN_NAME_CESS]);
            customer.TaxCategory = (TaxCategory)Enum.Parse(typeof(TaxCategory), Convert.ToString(row[COLUMN_NAME_TAX_CATEGORY]));
            customer.InvoiceFormat = (InvoiceFormat)Enum.Parse(typeof(InvoiceFormat), Convert.ToString(row[COLUMN_NAME_INVOICE_FORMAT]));

            return customer;
        }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_NAME].Width = 200;
            dgv.Columns[COLUMN_NAME_ADDRESS1].Width = 250;
            dgv.Columns[COLUMN_NAME_ADDRESS2].Width = 250;
            dgv.Columns[COLUMN_NAME_ADDRESS3].Width = 250;
            dgv.Columns[COLUMN_NAME_CITY].Width = 150;
            dgv.Columns[COLUMN_NAME_STATE].Width = 150;
            dgv.Columns[COLUMN_NAME_COUNTRY].Width = 100;
            dgv.Columns[COLUMN_NAME_GST].Width = 150;
            dgv.Columns[COLUMN_NAME_PAN].Width = 150;
            dgv.Columns[COLUMN_NAME_PHONE].Width = 150;
            dgv.Columns[COLUMN_NAME_CESS].Width = 150;
            dgv.Columns[COLUMN_NAME_TAX_CATEGORY].Width = 100;
            dgv.Columns[COLUMN_NAME_INVOICE_FORMAT].Width = 100;
            dgv.Columns[COLUMN_NAME_ZIP].Width = 100;

        }
    }
}
