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
        private const string COLUMN_NAME_RATE = "Rate";
        private const string COLUMN_NAME_QUANTITY = "Quantity";
        private const string COLUMN_NAME_UNIT = "Unit";
        private const string COLUMN_NAME_APPLIED_GST = "AppliedGST";
        private const string COLUMN_NAME_INTERVAL = "Interval";

        public static ItemTableFormatter Instance => new ItemTableFormatter();

        private ItemTableFormatter()
        {
        }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_NAME].Width = 500;
            dgv.Columns[COLUMN_NAME_RATE].Width = 200;
            dgv.Columns[COLUMN_NAME_QUANTITY].Width = 200;
            dgv.Columns[COLUMN_NAME_UNIT].Width = 200;
            dgv.Columns[COLUMN_NAME_APPLIED_GST].Width = 100;
            dgv.Columns[COLUMN_NAME_INTERVAL].Width = 100;
        }

        public void AddRow(ItemMasterDto item, DataRow row)
        {
            row[COLUMN_NAME_ID] = item.Id;
            row[COLUMN_NAME_NAME] = item.ItemName;
            row[COLUMN_NAME_RATE] = item.Rate;
            row[COLUMN_NAME_UNIT] = item.Unit;
            row[COLUMN_NAME_QUANTITY] = item.Quantity;
            row[COLUMN_NAME_APPLIED_GST] = item.AppliedGST;
            row[COLUMN_NAME_INTERVAL] = item.IntervalName;
        }

        public void AddColumns(DataTable table)
        {
            table.Columns.Add(COLUMN_NAME_ID);
            table.Columns.Add(COLUMN_NAME_NAME);
            table.Columns.Add(COLUMN_NAME_RATE);
            table.Columns.Add(COLUMN_NAME_QUANTITY);
            table.Columns.Add(COLUMN_NAME_UNIT);
            table.Columns.Add(COLUMN_NAME_APPLIED_GST);
            table.Columns.Add(COLUMN_NAME_INTERVAL);
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
            throw new NotImplementedException();
        }

        public void AppendRows(EntityLoader<ItemMasterDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }
    }
}
