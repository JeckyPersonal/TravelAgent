using Invoice.DTO;
using Invoice.UI.Company;
using Invoice.UI.Main.PresenterFactory;
using System;
using System.Collections.Generic;
using System.Data;

namespace Invoice.UI.Main
{
    internal class MainWindowPresenter
    {
        private IMainView _mainView;
        private readonly OverviewFactory _overviewFactory;

        public MainWindowPresenter(IMainView mainView)
        {
            this._mainView = mainView;
            this._overviewFactory = new OverviewFactory();
        }

        public void LoadCompanies(Menu menu)
        {
            IOverviewPresenter overviewPresenter = this._overviewFactory.GetOverviewPresenter(menu);
            this._mainView.LoadView(menu, overviewPresenter, overviewPresenter.GetDataGridFormatter());
            this._mainView.LoadData(overviewPresenter.BuildTable());
            this._mainView.FormatCompanyColumns();
        }

        public void OpenNewUI()
        {
            IOverviewPresenter overviewPresenter = this._mainView.GetOverviewPresenter();
            overviewPresenter.CreatePresenter().OpenNewUI();
            this._mainView.LoadData(overviewPresenter.BuildTable());
            this._mainView.FormatCompanyColumns();
        }

        public void OpenEditUI()
        {
            IOverviewPresenter overviewPresenter = this._mainView.GetOverviewPresenter();
            DataRow selectedRow = this._mainView.GetSelectedItem();
            overviewPresenter.CreatePresenter().OpenEditUI(Convert.ToInt32(selectedRow["Id"]));
            this._mainView.LoadData(overviewPresenter.BuildTable());
            this._mainView.FormatCompanyColumns();
        }

        
    }
}
