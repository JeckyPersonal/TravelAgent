using Invoice.DTO;
using Invoice.UI.Company;
using Invoice.UI.DTO;
using Invoice.UI.FinancialYear;
using Invoice.UI.Main;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.CompanySelector
{
    internal class CompanySelectorPresenter 
    {

        private readonly CompanyRestClient _companyRestClient;
        private readonly FinancialYearRestClient _financialYearRest;
        private ICompanySelectorView _selectorView;

        public CompanySelectorPresenter(CompanyRestClient companyRestClient, FinancialYearRestClient financialYearRestClient)
        {
            this._companyRestClient = companyRestClient;
            this._financialYearRest = financialYearRestClient;
        }

        public void ListDownCompany()
        {
            List<CompanyDto> companies = this._companyRestClient.GetAllCompany();
            this._selectorView.BindDataSource(companies);

        }
        public void SelectCompany()
        {
            CompanyDto selectedItem = this._selectorView.GetSelectedItem();
            FinancialYearDto financialYearDto = this._selectorView.GetFinancialYear();
            Settings.CompanyId = selectedItem.Id;
            Settings.FinancialYearId = financialYearDto.Id;
            this._selectorView.CloseUI();
        }

        public void ShowUI()
        {
            this._selectorView.ShowDialog();
        }

        public void SetView(ICompanySelectorView selectorView)
        {
            this._selectorView = selectorView;
        }

        public ICompanySelectorView GetView()
        {
            return this._selectorView;
        }

        public Form GetNextView()
        {
            return new frmMain();
        }

        internal void ShowFinancialYear()
        {
            CompanyDto companyDto = this._selectorView.GetSelectedItem();
            List<FinancialYearDto> financialYears = this._financialYearRest.GetAll(companyDto.Id);

            this._selectorView.BindFinancialYear(financialYears);
        }
    }
}
