using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Main.PresenterFactory
{
    public interface IOverviewPresenter
    {
        BasePresenter CreatePresenter();

        DataTable BuildTable();

        IDataGridFormatter GetDataGridFormatter();

        Menu GetMenu();
        bool DeleteRecord(DataRow selectedRow);
    }
}
