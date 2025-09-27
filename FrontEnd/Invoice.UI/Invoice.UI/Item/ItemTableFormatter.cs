using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Item
{
    public class ItemTableFormatter : IDataGridFormatter
    {
        public const string COLUMN_NAME_ID = "Id";
        public const string COLUMN_NAME_NAME = "Name";
        public const string COLUMN_NAME_RATE = "Rate";
        public const string COLUMN_NAME_APPLIED_GST = "AppliedGST";

        public static ItemTableFormatter Instance => new ItemTableFormatter();

        private ItemTableFormatter()
        {
        }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_NAME].Width = 500;
            dgv.Columns[COLUMN_NAME_RATE].Width = 200;
            dgv.Columns[COLUMN_NAME_APPLIED_GST].Width = 100;
        }
    }
}
