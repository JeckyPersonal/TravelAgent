using Invoice.UI.Main;
using Invoice.UI.Main.PresenterFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Customer
{
    internal class CustomerTableFormatter : IDataGridFormatter
    {

        public const string COLUMN_NAME_ID = "Id";
        public const string COLUMN_NAME_NAME = "Name";
        public const string COLUMN_NAME_ADDRESS1 = "Address1";
        public const string COLUMN_NAME_ADDRESS2 = "Address2";
        public const string COLUMN_NAME_ADDRESS3 = "Address3";
        public const string COLUMN_NAME_CITY = "City";
        public const string COLUMN_NAME_STATE = "State";
        public const string COLUMN_NAME_ZIP = "Zip";
        public const string COLUMN_NAME_COUNTRY = "Country";
        public const string COLUMN_NAME_GST = "GST";
        public const string COLUMN_NAME_PAN = "PAN";
        public const string COLUMN_NAME_PHONE = "Phone";
        public const string COLUMN_NAME_CESS = "Cess";
        public const string COLUMN_NAME_TAX_CATEGORY = "Tax Category";
        public const string COLUMN_NAME_INVOICE_FORMAT = "Invoice Format";

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

        }
    }
}
