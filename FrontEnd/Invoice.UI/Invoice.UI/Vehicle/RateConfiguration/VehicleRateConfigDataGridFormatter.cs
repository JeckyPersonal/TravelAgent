using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Vehicle.RateConfiguration
{
    internal interface IRowAdder<T>
    {
        void AddRow(T entity, DataRow row);

        void AddColumns(DataTable table);

        void BuildTable(EntityLoader<T> entityLoader, DataTable table);

        T GetObject(DataRow row);
    }

    internal interface EntityLoader<T>
    {
        List<T> GetEntities();
    }

    internal class VehicleRateConfigDataGridFormatter : IDataGridFormatter, IRowAdder<VehicleRateDto>
    {

        public static VehicleRateConfigDataGridFormatter Instance = new VehicleRateConfigDataGridFormatter();

        private VehicleRateConfigDataGridFormatter() { }

        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_ITEM_ID = "ItemId";
        private const string COLUMN_NAME_ITEM_NAME = "Item Name";
        private const string COLUMN_NAME_ITEM_QTY = "Qty";
        private const string COLUMN_NAME_ITEM_UNIT = "Unit";
        private const string COLUMN_NAME_ITEM_RATE = "Rate";

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_ITEM_ID].Visible = false;
            dgv.Columns[COLUMN_NAME_ITEM_NAME].Width = 200;
            dgv.Columns[COLUMN_NAME_ITEM_QTY].Width = 75;
            dgv.Columns[COLUMN_NAME_ITEM_RATE].Width = 125;
            dgv.Columns[COLUMN_NAME_ITEM_UNIT].Width = 125;

            dgv.Columns[COLUMN_NAME_ITEM_QTY].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
            dgv.Columns[COLUMN_NAME_ITEM_RATE].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight };
        }

        public void AddColumns(DataTable table)
        {
            table.Columns.Add(COLUMN_NAME_ID);
            table.Columns.Add(COLUMN_NAME_ITEM_ID);
            table.Columns.Add(COLUMN_NAME_ITEM_NAME);
            table.Columns.Add(COLUMN_NAME_ITEM_QTY);
            table.Columns.Add(COLUMN_NAME_ITEM_UNIT);
            table.Columns.Add(COLUMN_NAME_ITEM_RATE);
        }

        public void AddRow(VehicleRateDto entity, DataRow row)
        {
            row[COLUMN_NAME_ID] = entity.Id;
            row[COLUMN_NAME_ITEM_ID] = entity.ItemId;
            row[COLUMN_NAME_ITEM_NAME] = entity.ItemName;
            row[COLUMN_NAME_ITEM_QTY] = entity.Quantity;
            row[COLUMN_NAME_ITEM_UNIT] = entity.Unit;
            row[COLUMN_NAME_ITEM_RATE] = entity.Rate;
        }

        public VehicleRateDto GetObject(DataRow row)
        {
            VehicleRateDto rateDto = new VehicleRateDto();

            rateDto.Id = Convert.ToInt32(row[COLUMN_NAME_ID]);
            rateDto.ItemId = Convert.ToInt32 (row[COLUMN_NAME_ITEM_ID]);
            rateDto.ItemName = Convert.ToString(row[COLUMN_NAME_ITEM_NAME]);
            rateDto.Quantity = Convert.ToInt32( row[COLUMN_NAME_ITEM_QTY] );
            rateDto.Unit = Convert.ToString(row[COLUMN_NAME_ITEM_UNIT]);
            rateDto.Rate = Convert.ToDouble(row[COLUMN_NAME_ITEM_RATE]);

            return rateDto;
        }

        public void BuildTable(EntityLoader<VehicleRateDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }
    }
}
