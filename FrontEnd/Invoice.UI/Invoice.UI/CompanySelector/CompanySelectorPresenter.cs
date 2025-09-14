using Invoice.DTO;
using Invoice.UI.Company;
using Invoice.UI.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.CompanySelector
{
    internal class CompanySelectorPresenter 
    {

        private readonly CompanyRestClient _companyRestClient;
        private ICompanySelectorView _selectorView;

        public CompanySelectorPresenter(CompanyRestClient companyRestClient)
        {
            _companyRestClient = companyRestClient;
        }

        public void ListDownCompany()
        {
            List<CompanyDto> companies = this._companyRestClient.GetAllCompany();
            this._selectorView.BindDataSource(companies);

        }
        public void SelectCompany()
        {
            CompanyDto selectedItem = this._selectorView.GetSelectedItem();
            Settings.CompanyId = selectedItem.Id;
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
    }
}
