using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Data;
using System.Windows.Forms;

namespace Invoice.UI.Vehicle
{
    internal class VehicleTableFormatter : IDataGridFormatter, IRowAdder<VehicleDto>
    {
        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_TYPE = "Vehicle Type";

        public static VehicleTableFormatter Instance => new VehicleTableFormatter();

        private VehicleTableFormatter() { }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_TYPE].Width = 500;
        }

        public void AddRow(VehicleDto entity, DataRow row)
        {
            row[COLUMN_NAME_ID] = entity.Id;
            row[COLUMN_NAME_TYPE] = entity.VehicleType;
        }

        public void AddColumns(DataTable table)
        {
            if (table.Columns.Count > 0) return;

            table.Columns.Add(COLUMN_NAME_ID);
            table.Columns.Add(COLUMN_NAME_TYPE);
        }

        public void BuildTable(EntityLoader<VehicleDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }

        public void AppendRows(EntityLoader<VehicleDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }

        public VehicleDto GetObject(DataRow row)
        {
            return new VehicleDto()
            {
                Id = Convert.ToInt32(row[COLUMN_NAME_ID]),
                VehicleType = Convert.ToString(row[COLUMN_NAME_TYPE])
            };
            throw new NotImplementedException();
        }
    }
}
