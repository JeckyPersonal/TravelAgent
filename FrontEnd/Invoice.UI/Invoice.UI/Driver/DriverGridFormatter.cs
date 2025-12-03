using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Driver
{
    internal class DriverGridFormatter : IDataGridFormatter, IRowAdder<DriverDto>
    {
        public static DriverGridFormatter Instance => new DriverGridFormatter();

        private DriverGridFormatter() { }

        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_NAME = "Name";
        private const string COLUMN_NAME_MOBILE_NO = "Mobile No";
        private const string COLUMN_NAME_LICENSE_NO = "License";

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_NAME].Width = 300;
            dgv.Columns[COLUMN_NAME_MOBILE_NO].Width = 200;
            dgv.Columns[COLUMN_NAME_LICENSE_NO].Width = 200;
        }

        public void AddRow(DriverDto driver, DataRow row)
        {
            row[COLUMN_NAME_ID] = driver.Id;
            row[COLUMN_NAME_NAME] = driver.DriverName;
            row[COLUMN_NAME_MOBILE_NO] = driver.DriverMobile;
            row[COLUMN_NAME_LICENSE_NO] = driver.LicenseNo;
        }

        public void AddColumns(DataTable table)
        {
            table.Columns.Clear();
            table.Columns.Add(COLUMN_NAME_ID);
            table.Columns.Add(COLUMN_NAME_NAME);
            table.Columns.Add(COLUMN_NAME_MOBILE_NO);
            table.Columns.Add(COLUMN_NAME_LICENSE_NO);
        }

        public void BuildTable(EntityLoader<DriverDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }

        public void AppendRows(EntityLoader<DriverDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }

        public DriverDto GetObject(DataRow row)
        {
            DriverDto driver = new DriverDto();

            driver.Id= Convert.ToInt32(row[COLUMN_NAME_ID]);
            driver.DriverName = Convert.ToString(row[COLUMN_NAME_NAME]);
            driver.DriverMobile = Convert.ToString(row[COLUMN_NAME_MOBILE_NO]);
            driver.LicenseNo = Convert.ToString(row[COLUMN_NAME_LICENSE_NO]);

            return driver;
        }
    }
}
