using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.UtilsUI.GridSelection
{
    internal interface IGridSelectionView<T>
    {
        DialogResult DialogResult { get; set; }

        void Close();
        List<DataRow> GetSelectedRow();
        void SetGridFormatter(IDataGridFormatter gridFormatter);
        void SetGridSource(DataTable table);
        DialogResult ShowDialog();
    }
}
