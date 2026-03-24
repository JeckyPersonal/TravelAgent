using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Invoice.UI.Customer.TenderConfiguration
{
    internal class FuelDataGridFormatter : IDataGridFormatter, IRowAdder<TenderFuelRateDto>
    {
        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_FROM_DATE = "From Date";
        private const string COLUMN_TO_DATE = "To Date";
        private const string COLUMN_RATE = "Rate";

        public static FuelDataGridFormatter Instance => new FuelDataGridFormatter();


        public FuelDataGridFormatter() { }

        public void AddColumns(DataTable table)
        {
            table.Columns.Clear();

            table.Columns.Add(new DataColumn(COLUMN_NAME_ID));
            table.Columns.Add(new DataColumn(COLUMN_FROM_DATE));
            table.Columns.Add(new DataColumn(COLUMN_TO_DATE));
            table.Columns.Add(new DataColumn(COLUMN_RATE));
        }

        public void AddRow(TenderFuelRateDto tenderFuelRate, DataRow row)
        {
            row[COLUMN_NAME_ID] = tenderFuelRate.Id;
            row[COLUMN_FROM_DATE] = tenderFuelRate.FromDate.ToString(Settings.DateFormat);
            row[COLUMN_TO_DATE] = tenderFuelRate.ToDate.ToString(Settings.DateFormat);
            row[COLUMN_RATE] = tenderFuelRate.FuelCost;
        }

        public void AppendRows(EntityLoader<TenderFuelRateDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }

        public void BuildTable(EntityLoader<TenderFuelRateDto> entityLoader, DataTable table)
        {
            if (table != null) {
                table.Rows.Clear();
            }
            table.Columns.Clear();

            this.AddColumns(table);
            List<TenderFuelRateDto> tenderFuelRates = entityLoader.GetEntities();

            foreach (var tenderFuelRate in tenderFuelRates)
            {
                DataRow row = table.NewRow();
                this.AddRow(tenderFuelRate, row);
                table.Rows.Add(row);
            }
        }

        public TenderFuelRateDto GetObject(DataRow row)
        {
            TenderFuelRateDto fuelRates = new TenderFuelRateDto();
            fuelRates.Id = Convert.ToInt32(row[COLUMN_NAME_ID]);
            fuelRates.FromDate = DateTime.ParseExact(row[COLUMN_FROM_DATE].ToString(), Settings.DateFormat, CultureInfo.InvariantCulture); //Convert.ToDateTime(row[COLUMN_FROM_DATE]
            fuelRates.ToDate = DateTime.ParseExact(row[COLUMN_TO_DATE].ToString(), Settings.DateFormat, CultureInfo.InvariantCulture); //Convert.ToDateTime(row[COLUMN_TO_DATE]);
            fuelRates.FuelCost = Convert.ToDouble(row[COLUMN_RATE]);

            return fuelRates;
        }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_FROM_DATE].Width = 100;
            dgv.Columns[COLUMN_TO_DATE].Width = 100;
            dgv.Columns[COLUMN_RATE].Width = 100;
        }
    }
}
