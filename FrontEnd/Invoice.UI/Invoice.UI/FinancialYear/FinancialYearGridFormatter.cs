using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.FinancialYear
{
    internal class FinancialYearGridFormatter : IDataGridFormatter, IRowAdder<FinancialYearDto>
    {
        public static FinancialYearGridFormatter Instance => new FinancialYearGridFormatter();
        private FinancialYearGridFormatter() { }

        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_FROM_DATE = "From Date";
        private const string COLUMN_NAME_TO_DATE = "To Date";


        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_FROM_DATE].Width = 150;
            dgv.Columns[COLUMN_NAME_TO_DATE].Width = 150;
        }

        public void AddRow(FinancialYearDto financialYearDto, DataRow row)
        {
            row[COLUMN_NAME_ID] = financialYearDto.Id;
            row[COLUMN_NAME_FROM_DATE] = financialYearDto.FromDate;
            row[COLUMN_NAME_TO_DATE] = financialYearDto.ToDate;
        }

        public void AddColumns(DataTable table)
        {
            if (table.Columns.Count == 0)
            {
                table.Columns.Add(COLUMN_NAME_ID);
                table.Columns.Add(COLUMN_NAME_FROM_DATE);
                table.Columns.Add(COLUMN_NAME_TO_DATE);
            }   
        }

        public void BuildTable(EntityLoader<FinancialYearDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }

        public void AppendRows(EntityLoader<FinancialYearDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }

        public FinancialYearDto GetObject(DataRow row)
        {
            FinancialYearDto financialYearDto = new FinancialYearDto();

            financialYearDto.Id = Convert.ToInt32(row[FinancialYearGridFormatter.COLUMN_NAME_ID]);
            financialYearDto.FromDate = Convert.ToDateTime(row[FinancialYearGridFormatter.COLUMN_NAME_FROM_DATE]);
            financialYearDto.ToDate = Convert.ToDateTime(row[FinancialYearGridFormatter.COLUMN_NAME_TO_DATE]);

            return financialYearDto;    
        }
    }
}
