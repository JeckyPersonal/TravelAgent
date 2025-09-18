using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Bank
{
    internal class BankTableFormatter : IDataGridFormatter
    {
        public const string COLUMN_NAME_ID = "Id";
        public const string COLUMN_NAME_NAME = "BankName";

        public static BankTableFormatter Instance => new BankTableFormatter();

        private BankTableFormatter()
        {

        }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_NAME].Width = 200;
        }
    }
}
