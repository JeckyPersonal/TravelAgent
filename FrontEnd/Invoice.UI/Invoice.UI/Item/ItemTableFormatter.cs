using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Item
{
    internal class ItemTableFormatter : IDataGridFormatter, IRowAdder<ItemMasterDto>
    {
        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_NAME = "Name";
        private const string COLUMN_NAME_DESCRIPTION = "Description";
        private const string COLUMN_NAME_CATEGORY = "Category";
        private const string COLUMN_NAME_RATE = "Rate";
        private const string COLUMN_NAME_QUANTITY = "Quantity";
        private const string COLUMN_NAME_UNIT = "Unit";
        private const string COLUMN_NAME_APPLIED_GST = "AppliedGST";
        private const string COLUMN_NAME_FOR_VOUCHER = "For Voucher";
        private const string COLUMN_NAME_FOR_INVOICE = "For Invoice";
        private const string COLUMN_NAME_FOR_SYSTEM = "For System";
        private const string COLUMN_NAME_INTERVAL = "Interval";

        public static ItemTableFormatter Instance => new ItemTableFormatter();

        private ItemTableFormatter()
        {
        }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_NAME].Width = 300;
            dgv.Columns[COLUMN_NAME_DESCRIPTION].Width = 200;
            dgv.Columns[COLUMN_NAME_CATEGORY].Width = 90;
            dgv.Columns[COLUMN_NAME_RATE].Width = 100;
            dgv.Columns[COLUMN_NAME_QUANTITY].Width = 80;
            dgv.Columns[COLUMN_NAME_UNIT].Width = 80;
            dgv.Columns[COLUMN_NAME_APPLIED_GST].Width = 100;
            dgv.Columns[COLUMN_NAME_FOR_VOUCHER].Width = 50;
            dgv.Columns[COLUMN_NAME_FOR_INVOICE].Width = 50;
            dgv.Columns[COLUMN_NAME_FOR_SYSTEM].Width = 50;
            dgv.Columns[COLUMN_NAME_INTERVAL].Width = 100;
        }

        public void AddRow(ItemMasterDto item, DataRow row)
        {
            row[COLUMN_NAME_ID] = item.Id;
            row[COLUMN_NAME_NAME] = item.ItemName;
            row[COLUMN_NAME_DESCRIPTION] = item.ItemDescription;
            row[COLUMN_NAME_CATEGORY] = item.ItemCategory;
            row[COLUMN_NAME_RATE] = item.Rate;
            row[COLUMN_NAME_UNIT] = item.Unit;
            row[COLUMN_NAME_QUANTITY] = item.Quantity;
            row[COLUMN_NAME_APPLIED_GST] = item.AppliedGST;
            row[COLUMN_NAME_INTERVAL] = item.IntervalName;
            row[COLUMN_NAME_FOR_VOUCHER] = item.SourceVoucher;
            row[COLUMN_NAME_FOR_INVOICE] = item.SourceInvoice;
            row[COLUMN_NAME_FOR_SYSTEM] = item.SourceSystem;
        }

        public void AddColumns(DataTable table)
        {
            table.Columns.Add(COLUMN_NAME_ID);
            table.Columns.Add(COLUMN_NAME_NAME);
            table.Columns.Add(COLUMN_NAME_DESCRIPTION);
            table.Columns.Add(COLUMN_NAME_INTERVAL);
            table.Columns.Add(COLUMN_NAME_CATEGORY);
            table.Columns.Add(COLUMN_NAME_FOR_VOUCHER);
            table.Columns.Add(COLUMN_NAME_FOR_INVOICE);
            table.Columns.Add(COLUMN_NAME_FOR_SYSTEM);
            table.Columns.Add(COLUMN_NAME_RATE);
            table.Columns.Add(COLUMN_NAME_QUANTITY);
            table.Columns.Add(COLUMN_NAME_UNIT);
            table.Columns.Add(COLUMN_NAME_APPLIED_GST);
            
        }

        public void BuildTable(EntityLoader<ItemMasterDto> entityLoader, DataTable table)
        {
            table.Clear();

            this.AddColumns(table);

            List<ItemMasterDto> items = entityLoader.GetEntities();

            foreach (ItemMasterDto item in items)
            {
                DataRow row = table.NewRow();

                this.AddRow(item, row);

                table.Rows.Add(row);
            }

        }

        public ItemMasterDto GetObject(DataRow row)
        {
            return new ItemMasterDto()
            {
                Id = Convert.ToInt32(row[COLUMN_NAME_ID]),
                ItemName = Convert.ToString(row[COLUMN_NAME_NAME]),
                ItemDescription = Convert.ToString(row[COLUMN_NAME_DESCRIPTION]),
                ItemCategory =(ItemType)row[COLUMN_NAME_CATEGORY],
                Rate = Convert.ToDouble(row[COLUMN_NAME_RATE]),
                Unit = Convert.ToString(row[COLUMN_NAME_UNIT]),
                Quantity = Convert.ToInt32(row[COLUMN_NAME_QUANTITY]),
                AppliedGST = Convert.ToBoolean(row[COLUMN_NAME_APPLIED_GST]),
                IntervalName = Convert.ToString(row[COLUMN_NAME_INTERVAL]),
                SourceVoucher = Convert.ToBoolean(row[COLUMN_NAME_FOR_VOUCHER]),
                SourceInvoice = Convert.ToBoolean(row[COLUMN_NAME_FOR_INVOICE]),
                SourceSystem = Convert.ToBoolean(row[COLUMN_NAME_FOR_SYSTEM]),

            };
        }

        public void AppendRows(EntityLoader<ItemMasterDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }
    }
}
