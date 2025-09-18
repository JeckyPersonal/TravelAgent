using Invoice.UI.Main.PresenterFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Main
{
    public enum Menu
    {
        Home,
        Company,
        Bank,
    }
    internal interface IMainView
    {
        void LoadView(Menu menu, IOverviewPresenter overviewPresenter, IDataGridFormatter formatter);

        void LoadData(DataTable table);

        void FormatCompanyColumns();

        DataRow GetSelectedItem();

        IOverviewPresenter GetOverviewPresenter();
    }
}
