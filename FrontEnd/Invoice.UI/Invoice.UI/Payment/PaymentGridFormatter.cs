using Invoice.UI.FinancialYear;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Payment
{
    internal class PaymentGridFormatter : IDataGridFormatter, IRowAdder<PaymentDto>
    {

        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_RECEIVE_DATE = "Receive Date";
        private const string COLUMN_NAME_REFERENCE_NO = "Reference No";
        private const string COLUMN_NAME_PAYMENT_AMOUNT = "Payment Amount";
        private const string COLUMN_NAME_TDS = "TDS";
        private const string COLUMN_NAME_CGST = "CGST";
        private const string COLUMN_NAME_SGSG = "SGST";
        private const string COLUMN_NAME_IGST = "ICGST";
        private const string COLUMN_NAME_RECEIVE_AMOUNT = "Receive Amount";


        public static PaymentGridFormatter Instance => new PaymentGridFormatter();
        private PaymentGridFormatter()
        {
            
        }

        public void AddColumns(DataTable table)
        {
            table.Columns.Add(COLUMN_NAME_ID);
            table.Columns.Add(COLUMN_NAME_RECEIVE_DATE);
            table.Columns.Add(COLUMN_NAME_REFERENCE_NO);
            table.Columns.Add(COLUMN_NAME_PAYMENT_AMOUNT);
            table.Columns.Add(COLUMN_NAME_TDS);
            table.Columns.Add(COLUMN_NAME_CGST);
            table.Columns.Add(COLUMN_NAME_SGSG);
            table.Columns.Add(COLUMN_NAME_IGST);
            table.Columns.Add(COLUMN_NAME_RECEIVE_AMOUNT);
        }

        public void AddRow(PaymentDto entity, DataRow row)
        {
            row[COLUMN_NAME_ID] = entity.Id;
            row[COLUMN_NAME_RECEIVE_DATE] = entity.ReveivedDate.ToString(Settings.DateFormat);
            row[COLUMN_NAME_REFERENCE_NO] = entity.ReferenceNumber;
            row[COLUMN_NAME_PAYMENT_AMOUNT] = entity.PaymentAmount.ToString("F2");
            row[COLUMN_NAME_TDS] = entity.TDS.ToString("F2");
            row[COLUMN_NAME_CGST] = entity.CGST.ToString("F2");
            row[COLUMN_NAME_SGSG] = entity.SGST.ToString("F2");
            row[COLUMN_NAME_IGST] = entity.IGST.ToString("F2");
            row[COLUMN_NAME_RECEIVE_AMOUNT] = entity.ReceivedAmount.ToString("F2");
        }

        public void AppendRows(EntityLoader<PaymentDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }

        public void BuildTable(EntityLoader<PaymentDto> entityLoader, DataTable table)
        {
            table.Rows.Clear();

            if(table.Columns.Count == 0) 
                this.AddColumns(table);

            List<PaymentDto> payments = entityLoader.GetEntities();

            foreach (PaymentDto payment in payments)
            {
                DataRow row = table.NewRow();

                this.AddRow(payment, row);

                table.Rows.Add(row);
            }
        }

        public PaymentDto GetObject(DataRow row)
        {
            PaymentDto entity = new PaymentDto();

            entity.Id = Convert.ToInt32(row[COLUMN_NAME_ID]);
            entity.ReveivedDate = DateTime.ParseExact(row[COLUMN_NAME_RECEIVE_DATE].ToString(), Settings.DateFormat, CultureInfo.InvariantCulture);
            entity.ReferenceNumber = Convert.ToString(row[COLUMN_NAME_REFERENCE_NO]);
            entity.PaymentAmount = Convert.ToDouble(row[COLUMN_NAME_PAYMENT_AMOUNT]);
            entity.TDS = Convert.ToDouble( row[COLUMN_NAME_TDS]);
            entity.CGST = Convert.ToDouble(row[COLUMN_NAME_CGST]);
            entity.SGST = Convert.ToDouble(row[COLUMN_NAME_SGSG]);
            entity.IGST = Convert.ToDouble(row[COLUMN_NAME_IGST]);
            entity.ReceivedAmount = Convert.ToDouble(row[COLUMN_NAME_RECEIVE_AMOUNT]);

            return entity;

        }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_RECEIVE_DATE].Width = 150;
            dgv.Columns[COLUMN_NAME_REFERENCE_NO].Width = 150;
            dgv.Columns[COLUMN_NAME_PAYMENT_AMOUNT].Width = 120;
            dgv.Columns[COLUMN_NAME_TDS].Width = 120;
            dgv.Columns[COLUMN_NAME_CGST].Width = 120;
            dgv.Columns[COLUMN_NAME_SGSG].Width = 120;
            dgv.Columns[COLUMN_NAME_IGST].Width = 120;
            dgv.Columns[COLUMN_NAME_RECEIVE_AMOUNT].Width = 120;


            dgv.Columns[COLUMN_NAME_RECEIVE_DATE].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter };
            dgv.Columns[COLUMN_NAME_PAYMENT_AMOUNT].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_TDS].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_CGST].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_SGSG].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_IGST].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_RECEIVE_AMOUNT].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
        }
    }
}
