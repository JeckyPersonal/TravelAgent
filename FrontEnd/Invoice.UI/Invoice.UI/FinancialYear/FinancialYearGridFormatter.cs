using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.FinancialYear
{
    internal class FinancialYearGridFormatter : IDataGridFormatter
    {
        public static FinancialYearGridFormatter Instance => new FinancialYearGridFormatter();
        private FinancialYearGridFormatter() { }

        public const string COLUMN_NAME_ID = "Id";
        public const string COLUMN_NAME_FROM_DATE = "From Date";
        public const string COLUMN_NAME_TO_DATE = "To Date";


        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_FROM_DATE].Width = 150;
            dgv.Columns[COLUMN_NAME_TO_DATE].Width = 150;
        }
    }
}
