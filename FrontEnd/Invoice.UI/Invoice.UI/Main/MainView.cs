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
    }
    internal interface IMainView
    {
        void LoadView(Menu menu, BasePresenter basePresenter, IDataGridFormatter formatter);

        void LoadData(DataTable table);

        void FormatCompanyColumns();
    }
}
