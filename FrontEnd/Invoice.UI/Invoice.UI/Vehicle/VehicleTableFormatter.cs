using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Vehicle
{
    internal class VehicleTableFormatter : IDataGridFormatter
    {
        public const string COLUMN_NAME_ID = "Id";
        public const string COLUMN_NAME_TYPE = "Vehicle Type";

        public static VehicleTableFormatter Instance => new VehicleTableFormatter();

        private VehicleTableFormatter() { }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_TYPE].Width = 500;
        }
    }
}
