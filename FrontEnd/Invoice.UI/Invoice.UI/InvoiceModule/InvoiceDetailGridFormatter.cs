using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Invoice.UI.InvoiceModule
{
    internal class InvoiceDetailGridFormatter : IDataGridFormatter, IRowAdder<InvoiceDetailDto>
    {

        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_ITEM_ID = "Item Id";
        private const string COLUMN_NAME_ITEM_NAME = "Item Name";
        private const string COLUMN_NAME_ITEM_CATEGORY = "Item Category";
        private const string COLUMN_NAME_RATE = "Rate";
        private const string COLUMN_NAME_QUANTITY = "Quantity";
        private const string COLUMN_NAME_UNIT = "Unit";
        private const string COLUMN_NAME_AMOUNT = "Amount";
        private const string COLUMN_NAME_CGST = "CGST";
        private const string COLUMN_NAME_SGST = "SGST";
        private const string COLUMN_NAME_IGST = "IGST";
        private const string COLUMN_NAME_NET_AMOUNT = "Net Amount";
        private const string COLUMN_NAME_ITEM_DESCRIPTION = "Description";
        private const string COLUMN_NAME_VOUCHER_NO = "VoucherNo";
        private const string COLUMN_NAME_ACTION = "Action";
        private const string COLUMN_NAME_VOUCHER_DETAIL_ID = "Invoice Detail Id";


        public void AddColumns(DataTable table)
        {
            table.Columns.Add(COLUMN_NAME_ID);
            table.Columns.Add(COLUMN_NAME_VOUCHER_NO);
            table.Columns.Add(COLUMN_NAME_ITEM_ID);
            table.Columns.Add(COLUMN_NAME_ITEM_NAME);
            table.Columns.Add(COLUMN_NAME_ITEM_CATEGORY);
            table.Columns.Add(COLUMN_NAME_ITEM_DESCRIPTION);
            table.Columns.Add(COLUMN_NAME_RATE);
            table.Columns.Add(COLUMN_NAME_QUANTITY);
            table.Columns.Add(COLUMN_NAME_UNIT);
            table.Columns.Add(COLUMN_NAME_AMOUNT);
            table.Columns.Add(COLUMN_NAME_CGST);
            table.Columns.Add(COLUMN_NAME_SGST);
            table.Columns.Add(COLUMN_NAME_IGST);
            table.Columns.Add(COLUMN_NAME_NET_AMOUNT);
            table.Columns.Add(COLUMN_NAME_ACTION);
            table.Columns.Add(COLUMN_NAME_VOUCHER_DETAIL_ID);
        }

        public void AddRow(InvoiceDetailDto entity, DataRow row)
        {
            row[COLUMN_NAME_ID] = entity.Id;
            row[COLUMN_NAME_VOUCHER_NO] = entity.VoucherNo;
            row[COLUMN_NAME_ITEM_ID] = entity.ItemId;
            row[COLUMN_NAME_ITEM_NAME] = entity.ItemName;
            row[COLUMN_NAME_ITEM_CATEGORY] = entity.ItemCategory;
            row[COLUMN_NAME_ITEM_DESCRIPTION] = entity.Description;
            row[COLUMN_NAME_RATE] = entity.Rate.ToString("F2");
            row[COLUMN_NAME_QUANTITY] = entity.Quantity;
            row[COLUMN_NAME_UNIT] = entity.Unit;
            row[COLUMN_NAME_AMOUNT] = entity.AmountBeforeGST.ToString("F2");
            row[COLUMN_NAME_CGST] = entity.CGST.ToString("F2");
            row[COLUMN_NAME_SGST] = entity.SGST.ToString("F2");
            row[COLUMN_NAME_IGST] = entity.IGST.ToString("F2");
            row[COLUMN_NAME_NET_AMOUNT] = entity.Amount.ToString("F2");
            row[COLUMN_NAME_ACTION] = ActionMode.New;
            row[COLUMN_NAME_VOUCHER_DETAIL_ID] = entity.VoucherDetailId.ToString();
        }

        public void AppendRows(EntityLoader<InvoiceDetailDto> entityLoader, DataTable table)
        {
            List<InvoiceDetailDto> invoiceDetailDtos = entityLoader.GetEntities();

            foreach (InvoiceDetailDto invoiceDetail in invoiceDetailDtos)
            {
                DataRow newRow = table.NewRow();
                if (invoiceDetail.ItemCategory.Equals(ItemType.COST.ToString()))
                {
                    invoiceDetail.Rate = -invoiceDetail.Rate;
                    invoiceDetail.Amount = -invoiceDetail.Amount;
                    invoiceDetail.AmountBeforeGST = -invoiceDetail.AmountBeforeGST;
                }
                this.AddRow(invoiceDetail, newRow);

                table.Rows.Add(newRow);
            }
        }

        public void BuildTable(EntityLoader<InvoiceDetailDto> entityLoader, DataTable table)
        {
            table.Rows.Clear();

            if (table.Columns.Count == 0)
                this.AddColumns(table);

            List<InvoiceDetailDto> invoiceDetailDtos = entityLoader.GetEntities();

            foreach (InvoiceDetailDto invoiceDetail in invoiceDetailDtos)
            {
                DataRow newRow = table.NewRow();
                if (invoiceDetail.ItemCategory.Equals(ItemType.COST.ToString())) {
                    invoiceDetail.Rate = -invoiceDetail.Rate;
                    invoiceDetail.Amount = -invoiceDetail.Amount;
                    invoiceDetail.AmountBeforeGST = -invoiceDetail.AmountBeforeGST;
                }

                this.AddRow(invoiceDetail, newRow);

                table.Rows.Add(newRow);
            }
        }

        public InvoiceDetailDto GetObject(DataRow row)
        {
            InvoiceDetailDto invoiceDetailDto = new InvoiceDetailDto();

            invoiceDetailDto.Id = Convert.ToInt32(row[COLUMN_NAME_ID]);
            invoiceDetailDto.VoucherNo = Convert.ToString(row[COLUMN_NAME_VOUCHER_NO]);
            invoiceDetailDto.ItemId = Convert.ToInt32(row[COLUMN_NAME_ITEM_ID]);
            invoiceDetailDto.ItemName = Convert.ToString(row[COLUMN_NAME_ITEM_NAME]);
            invoiceDetailDto.ItemCategory = Convert.ToString(row[COLUMN_NAME_ITEM_CATEGORY]);
            invoiceDetailDto.Description = Convert.ToString(row[COLUMN_NAME_ITEM_DESCRIPTION]);
            invoiceDetailDto.Rate = Convert.ToDouble(row[COLUMN_NAME_RATE]);
            invoiceDetailDto.Quantity = Convert.ToInt32(row[COLUMN_NAME_QUANTITY]);
            invoiceDetailDto.Unit = Convert.ToString(row[COLUMN_NAME_UNIT]);
            invoiceDetailDto.AmountBeforeGST = Convert.ToDouble(row[COLUMN_NAME_AMOUNT]);
            invoiceDetailDto.CGST = Convert.ToDouble(row[COLUMN_NAME_CGST]);
            invoiceDetailDto.SGST = Convert.ToDouble(row[COLUMN_NAME_SGST]);
            invoiceDetailDto.IGST = Convert.ToDouble(row[COLUMN_NAME_IGST]);
            invoiceDetailDto.Amount = Convert.ToDouble(row[COLUMN_NAME_NET_AMOUNT]);
            invoiceDetailDto.ActionMode = (ActionMode)Enum.Parse(typeof(ActionMode), Convert.ToString(row[COLUMN_NAME_ACTION]));

            if(row[COLUMN_NAME_VOUCHER_DETAIL_ID]!="")
                invoiceDetailDto.VoucherDetailId = Convert.ToInt32(row[COLUMN_NAME_VOUCHER_DETAIL_ID]);

            return invoiceDetailDto;
        }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_ITEM_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_ITEM_ID].Visible = false;
            dgv.Columns[COLUMN_NAME_ITEM_NAME].Width = 200;
            dgv.Columns[COLUMN_NAME_ITEM_CATEGORY].Width = 75;
            dgv.Columns[COLUMN_NAME_RATE].Width = 75;
            dgv.Columns[COLUMN_NAME_QUANTITY].Width = 75;
            dgv.Columns[COLUMN_NAME_UNIT].Width = 75;
            dgv.Columns[COLUMN_NAME_AMOUNT].Width = 100;
            dgv.Columns[COLUMN_NAME_CGST].Width = 75;
            dgv.Columns[COLUMN_NAME_SGST].Width = 75;
            dgv.Columns[COLUMN_NAME_IGST].Width = 75;
            dgv.Columns[COLUMN_NAME_NET_AMOUNT].Width = 100;
            dgv.Columns[COLUMN_NAME_VOUCHER_NO].Width = 150;
            dgv.Columns[COLUMN_NAME_ITEM_DESCRIPTION].Width = 200;
            dgv.Columns[COLUMN_NAME_ACTION].Visible = false;
            dgv.Columns[COLUMN_NAME_VOUCHER_DETAIL_ID].Visible = false;

            dgv.Columns[COLUMN_NAME_QUANTITY].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_RATE].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_AMOUNT].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_CGST].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_SGST].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_IGST].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_NET_AMOUNT].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
        }
    }
}
