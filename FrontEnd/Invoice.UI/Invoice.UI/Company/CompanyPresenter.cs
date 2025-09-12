using Invoice.DTO;
using Invoice.UI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this._companyView.CloseUI();
        }

        public override void SaveAndNew()
        {
            try
            {
                frmCompany companyFrom = (frmCompany)this._companyView;
                this._companyResetClient.AddCompany(companyFrom.DTO);
                this._companyView.ClearUI();
            }
            catch (ValidationException vex)
            {
                this._companyView.ShowError(vex.Errors);
            }
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
