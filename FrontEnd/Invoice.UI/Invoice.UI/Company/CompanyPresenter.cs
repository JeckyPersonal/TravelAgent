using Invoice.DTO;
using Invoice.UI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Company
{
    public class CompanyPresenter : BasePresenter
    {
        private ICompanyView _companyView;
        private CompanyRestClient _companyResetClient;

        public CompanyPresenter(CompanyRestClient companyResetClient) : base()
        {
            _companyResetClient = companyResetClient;
        }

        public void LoadUI()
        {
            //this._companyView.SetDto(new CompanyDto());
        }

        public override void Close()
        {
            this._companyView.CloseUI();
        }

        public override void SaveAndClose()
        {
            this.saveCompany();
            this._companyView.CloseUI();
        }

        public override void SaveAndNew()
        {
            try
            {
                this.saveCompany();
                this._companyView.ShowMessage();
                this._companyView.ClearUI();
            }
            catch (ValidationException vex)
            {
                this._companyView.ShowError(vex.Errors);
            }
        }

        private void saveCompany()
        {
            frmCompany companyFrom = (frmCompany)this._companyView;
            CompanyDto savedCompany = companyFrom.DTO;

            if (this._companyView.GetMode() == ActionMode.New)

                this._companyResetClient.AddCompany(companyFrom.DTO);
            else
                this._companyResetClient.UpdateCompany(companyFrom.DTO);
        }

        public void SetView(ICompanyView view)
        {
            this._companyView = view;
            base.SetView(view);
        }

        protected override object BuildDto()
        {
            return new CompanyDto();
        }

        protected override object BuidDtoForEdit(int id)
        {
            return this._companyResetClient.GetById(id);

        }
    }
}
