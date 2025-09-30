using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Driver
{
    public class DriverGridFormatter : IDataGridFormatter
    {
        public static DriverGridFormatter Instance => new DriverGridFormatter();

        private DriverGridFormatter() { }

        public const string COLUMN_NAME_ID = "Id";
        public const string COLUMN_NAME_NAME = "Name";
        public const string COLUMN_NAME_MOBILE_NO = "Mobile No";
        public const string COLUMN_NAME_LICENSE_NO = "License";

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_NAME].Width = 300;
            dgv.Columns[COLUMN_NAME_MOBILE_NO].Width = 200;
            dgv.Columns[COLUMN_NAME_LICENSE_NO].Width = 200;
        }
    }
}
