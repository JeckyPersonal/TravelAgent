using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.InvoiceModule
{
    internal class InvoiceDataGridFormatter : IDataGridFormatter, IRowAdder<InvoiceDto>
    {
        public static InvoiceDataGridFormatter Instance = new InvoiceDataGridFormatter();

        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_INVOICE_NO = "Invoice No.";
        private const string COLUMN_NAME_INVOICE_DATE = "Invoice Date";
        private const string COLUMN_NAME_CUSTOMER_ID = "Customer Id";
        private const string COLUMN_NAME_CUSTOMER_NAME = "Customer Name";
        private const string COLUMN_NAME_BANK_ID = "Bank Id";
        private const string COLUMN_NAME_BANK_NAME = "Bank Name";
        private const string COLUMN_NAME_ACCOUNT_ID = "Account Id";
        private const string COLUMN_NAME_ACCOUNT_NO = "Account No";
        private const string COLUMN_NAME_AMOUNT = "Amount";
        private const string COLUMN_NAME_CGST = "C.GST";
        private const string COLUMN_NAME_SGST = "S.GST";
        private const string COLUMN_NAME_IGST = "I.GST";
        private const string COLUMN_NAME_NET_AMOUNT = "Net Amount";


        private InvoiceDataGridFormatter() { }

        public void AddColumns(DataTable table)
        {
            table.Columns.Add(COLUMN_NAME_ID);
            table.Columns.Add(COLUMN_NAME_INVOICE_NO);
            table.Columns.Add(COLUMN_NAME_INVOICE_DATE);
            table.Columns.Add(COLUMN_NAME_CUSTOMER_ID);
            table.Columns.Add(COLUMN_NAME_CUSTOMER_NAME);
            table.Columns.Add(COLUMN_NAME_BANK_ID);
            table.Columns.Add(COLUMN_NAME_BANK_NAME);
            table.Columns.Add(COLUMN_NAME_ACCOUNT_ID);
            table.Columns.Add(COLUMN_NAME_ACCOUNT_NO);
            table.Columns.Add(COLUMN_NAME_AMOUNT);
            table.Columns.Add(COLUMN_NAME_CGST);
            table.Columns.Add(COLUMN_NAME_SGST);
            table.Columns.Add(COLUMN_NAME_IGST);
            table.Columns.Add(COLUMN_NAME_NET_AMOUNT);
        }

        public void AddRow(InvoiceDto entity, DataRow row)
        {
            row[COLUMN_NAME_ID] = entity.Id;
            row[COLUMN_NAME_INVOICE_NO] = entity.InvoiceNo;
            row[COLUMN_NAME_INVOICE_DATE] = entity.InvoiceDate;
            row[COLUMN_NAME_CUSTOMER_ID] = entity.CustomerId;
            row[COLUMN_NAME_CUSTOMER_NAME] = entity.CustomerName;
            row[COLUMN_NAME_BANK_ID] = entity.BankId;
            row[COLUMN_NAME_BANK_NAME] = entity.BankName;
            row[COLUMN_NAME_ACCOUNT_ID] = entity.AccountNumberId;
            row[COLUMN_NAME_ACCOUNT_NO] = entity.AccountNumber;
            row[COLUMN_NAME_AMOUNT] = entity.Total.ToString("F2");
            row[COLUMN_NAME_CGST] = entity.CGST.ToString("F2");
            row[COLUMN_NAME_SGST] = entity.SGST.ToString("F2");
            row[COLUMN_NAME_IGST] = entity.IGST.ToString("F2");
            row[COLUMN_NAME_NET_AMOUNT] = entity.Amount.ToString("F2");
        }

        public void BuildTable(EntityLoader<InvoiceDto> entityLoader, DataTable table)
        {
            table.Rows.Clear();

            List<InvoiceDto> invoices = entityLoader.GetEntities();

            foreach (InvoiceDto invoice in invoices) {
                DataRow row = table.NewRow();

                this.AddRow(invoice, row);

                table.Rows.Add(row);

            }
        }

        public InvoiceDto GetObject(DataRow row)
        {
            InvoiceDto entity = new InvoiceDto();
            entity.Id = Convert.ToInt32(row[COLUMN_NAME_ID]);
            entity.InvoiceNo = Convert.ToString(row[COLUMN_NAME_INVOICE_NO]);
            entity.InvoiceDate = Convert.ToDateTime(row[COLUMN_NAME_INVOICE_DATE]);
            entity.CustomerId = Convert.ToInt32(row[COLUMN_NAME_CUSTOMER_ID]);
            entity.CustomerName = Convert.ToString(row[COLUMN_NAME_CUSTOMER_NAME]);
            entity.BankId = Convert.ToInt32(row[COLUMN_NAME_BANK_ID]);
            entity.BankName = Convert.ToString(row[COLUMN_NAME_BANK_NAME]);
            entity.AccountNumberId = Convert.ToInt32(row[COLUMN_NAME_ACCOUNT_ID]);
            entity.AccountNumber = Convert.ToString(row[COLUMN_NAME_ACCOUNT_NO]);
            entity.Total = Convert.ToDouble(row[COLUMN_NAME_AMOUNT]);
            entity.CGST = Convert.ToDouble(row[COLUMN_NAME_CGST]);
            entity.SGST = Convert.ToDouble(row[COLUMN_NAME_SGST]);
            entity.IGST = Convert.ToDouble(row[COLUMN_NAME_IGST]);
            entity.Amount = Convert.ToDouble(row[COLUMN_NAME_NET_AMOUNT]);
            return entity;
        }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_INVOICE_NO].Width = 150;
            dgv.Columns[COLUMN_NAME_INVOICE_DATE].Width = 150;
            dgv.Columns[COLUMN_NAME_CUSTOMER_ID].Visible = false;
            dgv.Columns[COLUMN_NAME_CUSTOMER_NAME].Width = 300;
            dgv.Columns[COLUMN_NAME_BANK_ID].Visible = false;
            dgv.Columns[COLUMN_NAME_BANK_NAME].Width = 300;
            dgv.Columns[COLUMN_NAME_ACCOUNT_ID].Visible = false;
            dgv.Columns[COLUMN_NAME_ACCOUNT_NO].Width = 300;
            dgv.Columns[COLUMN_NAME_AMOUNT].Width = 120;
            dgv.Columns[COLUMN_NAME_CGST].Width = 120;
            dgv.Columns[COLUMN_NAME_SGST].Width = 120;
            dgv.Columns[COLUMN_NAME_IGST].Width = 120;
            dgv.Columns[COLUMN_NAME_NET_AMOUNT].Width = 120;

            dgv.Columns[COLUMN_NAME_AMOUNT].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_CGST].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_SGST].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_IGST].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_NET_AMOUNT].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
        }

        public void AppendRows(EntityLoader<InvoiceDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }
    }
}
