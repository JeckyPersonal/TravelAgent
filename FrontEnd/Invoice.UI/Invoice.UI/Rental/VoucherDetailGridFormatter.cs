
using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Invoice.UI.Rental
{
    internal class VoucherDetailGridFormatter : IDataGridFormatter, IRowAdder<VoucherDetailDto>
    {
        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_ITEM_ID = "ItemId";
        private const string COLUMN_NAME_ITEM_NAME = "Item Name";
        private const string COLUMN_NAME_ITEM_QTY = "Qty";
        private const string COLUMN_NAME_ITEM_UNIT = "Unit";
        private const string COLUMN_NAME_ITEM_RATE = "Rate";
        private const string COLUMN_NAME_DETAIL_ACTION = "Action";
        private const string COLUMN_NAME_ITEM_AMOUNT = "Amount";
        private const string COLUMN_NAME_INTERVAL_ID = "Interval Id";
        private const string COLUMN_NAME_INTERVAL_Name = "Interval Name";

        public void AddColumns(DataTable table)
        {
            table.Columns.Add(COLUMN_NAME_ID);
            table.Columns.Add(COLUMN_NAME_ITEM_ID);
            table.Columns.Add(COLUMN_NAME_ITEM_NAME);
            table.Columns.Add(COLUMN_NAME_ITEM_QTY);
            table.Columns.Add(COLUMN_NAME_INTERVAL_ID);
            table.Columns.Add(COLUMN_NAME_INTERVAL_Name);
            table.Columns.Add(COLUMN_NAME_ITEM_UNIT);
            table.Columns.Add(COLUMN_NAME_ITEM_RATE);
            table.Columns.Add(COLUMN_NAME_ITEM_AMOUNT);
            table.Columns.Add(COLUMN_NAME_DETAIL_ACTION);
        }

        public void AddRow(VoucherDetailDto entity, DataRow row)
        {
            row[COLUMN_NAME_ID] = entity.Id;
            row[COLUMN_NAME_ITEM_ID] = entity.ItemId;
            row[COLUMN_NAME_ITEM_NAME] = entity.ItemName;
            row[COLUMN_NAME_ITEM_QTY] = entity.Quantity;
            row[COLUMN_NAME_INTERVAL_ID] = entity.Interval;
            row[COLUMN_NAME_INTERVAL_Name] = entity.IntervalName;
            row[COLUMN_NAME_ITEM_UNIT] = entity.Unit;
            row[COLUMN_NAME_ITEM_RATE] = entity.Rate;
            row[COLUMN_NAME_ITEM_AMOUNT] = entity.Amount;
            row[COLUMN_NAME_DETAIL_ACTION] = entity.Action;
        }

        //public void AddRow(CustomerRateDto entity, DataRow row)
        //{
        //    row[COLUMN_NAME_ID] = entity.Id;
        //    row[COLUMN_NAME_ITEM_ID] = entity.ItemId;
        //    row[COLUMN_NAME_ITEM_NAME] = entity.ItemName;
        //    row[COLUMN_NAME_ITEM_QTY] = entity.Quantity;
        //    row[COLUMN_NAME_ITEM_UNIT] = entity.Unit;
        //    row[COLUMN_NAME_ITEM_RATE] = entity.Rate;
        //    row[COLUMN_NAME_ITEM_AMOUNT] = 0.0;
        //    row[COLUMN_NAME_DETAIL_ACTION] = ActionMode.New;
        //}

        public void BuildTable(EntityLoader<VoucherDetailDto> entityLoader, DataTable table)
        {
            table.Rows.Clear();

            List<VoucherDetailDto> voucherDetails = entityLoader.GetEntities();

            foreach(var voucherDetail in voucherDetails)
            {
                DataRow newRow = table.NewRow();

                this.AddRow(voucherDetail, newRow);

                table.Rows.Add(newRow);
            }
        }

        public VoucherDetailDto GetObject(DataRow row)
        {
            VoucherDetailDto rateDto = new VoucherDetailDto();

            rateDto.Id = Convert.ToInt32(row[COLUMN_NAME_ID]);
            rateDto.ItemId = Convert.ToInt32(row[COLUMN_NAME_ITEM_ID]);
            rateDto.ItemName = Convert.ToString(row[COLUMN_NAME_ITEM_NAME]);
            rateDto.Quantity = Convert.ToInt32(row[COLUMN_NAME_ITEM_QTY]);
            rateDto.Unit = Convert.ToString(row[COLUMN_NAME_ITEM_UNIT]);
            rateDto.Rate = Convert.ToDouble(row[COLUMN_NAME_ITEM_RATE]);
            rateDto.Amount= Convert.ToDouble(row[COLUMN_NAME_ITEM_AMOUNT]);
            rateDto.Interval = Convert.ToInt32(row[COLUMN_NAME_INTERVAL_ID]);
            rateDto.IntervalName = Convert.ToString(row[COLUMN_NAME_INTERVAL_Name]);
            rateDto.Action = (ActionMode)Enum.Parse(typeof(ActionMode), Convert.ToString(row[COLUMN_NAME_DETAIL_ACTION])); 

            return rateDto;
        }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Visible = false;
            dgv.Columns[COLUMN_NAME_ITEM_ID].Visible = false;
            dgv.Columns[COLUMN_NAME_DETAIL_ACTION].Visible = false;
            dgv.Columns[COLUMN_NAME_ITEM_NAME].Width = 200;
            dgv.Columns[COLUMN_NAME_ITEM_QTY].Width = 75;
            dgv.Columns[COLUMN_NAME_ITEM_RATE].Width = 100;
            dgv.Columns[COLUMN_NAME_ITEM_AMOUNT].Width = 100;
            dgv.Columns[COLUMN_NAME_ITEM_UNIT].Width = 100;
            dgv.Columns[COLUMN_NAME_INTERVAL_ID].Visible = false;
            dgv.Columns[COLUMN_NAME_INTERVAL_Name].Width = 100;

            dgv.Columns[COLUMN_NAME_ITEM_QTY].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_ITEM_RATE].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_ITEM_AMOUNT].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
        }
    }
}
