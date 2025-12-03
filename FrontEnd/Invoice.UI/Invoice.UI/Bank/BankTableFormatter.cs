using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Invoice.UI.Bank
{
    internal class BankTableFormatter : IDataGridFormatter, IRowAdder<BankDto>
    {
        private const string COLUMN_NAME_ID = "Id";
        private const string COLUMN_NAME_NAME = "BankName";

        public static BankTableFormatter Instance => new BankTableFormatter();

        private BankTableFormatter()
        {

        }

        public void ResizeColumn(DataGridView dgv)
        {
            dgv.Columns[COLUMN_NAME_ID].Width = 50;
            dgv.Columns[COLUMN_NAME_NAME].Width = 200;
        }

        public void AddRow(BankDto bank, DataRow row)
        {
            row[COLUMN_NAME_ID] = bank.Id;
            row[COLUMN_NAME_NAME] = bank.BankName;
        }

        public void AddColumns(DataTable table)
        {
            table.Columns.Clear();

            table.Columns.Add(new DataColumn(COLUMN_NAME_ID));
            table.Columns.Add(new DataColumn(COLUMN_NAME_NAME));
        }

        public void BuildTable(EntityLoader<BankDto> entityLoader, DataTable table)
        {
            if (table != null)
                table.Rows.Clear();

            table.Columns.Clear();

            this.AddColumns(table);

            List<BankDto> banks = entityLoader.GetEntities();

            foreach (BankDto bank in banks)
            {
                DataRow row = table.NewRow();

                this.AddRow(bank, row);

                table.Rows.Add(row);
            }
        }

        public void AppendRows(EntityLoader<BankDto> entityLoader, DataTable table)
        {
            throw new NotImplementedException();
        }

        public BankDto GetObject(DataRow row)
        {
            BankDto bank = new BankDto();

            bank.Id = Convert.ToInt32(row[COLUMN_NAME_ID]);
            bank.BankName = Convert.ToString(row[COLUMN_NAME_NAME]);

            return bank;
        }
    }
}
