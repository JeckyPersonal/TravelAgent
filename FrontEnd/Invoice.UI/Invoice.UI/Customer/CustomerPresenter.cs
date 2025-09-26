using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Invoice.UI.Main.PresenterFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Customer
{
    public class CustomerPresenter : BasePresenter
    {
        private readonly CustomerRestClient _restClient;
        private ICustomerView _view;


        public CustomerPresenter(CustomerRestClient restClient)
        {
            this._restClient = restClient;
        }

        public override void Close()
        {
            this._view.CloseUI();
        }

        public override void SaveAndClose()
        {
            this._view.CloseUI();
        }

        public override void SaveAndNew()
        {
            try
            {
                saveDto();
                this._view.ClearUI();
            }
            catch (ValidationException ver)
            {
                this._view.ShowError(ver.Errors);
            }
        }

        private CustomerDto saveDto()
        {
            CustomerDto customerDto = this._view.GetDto() as CustomerDto;

            if (this._view.GetMode() == ActionMode.New)
            {
                return this._restClient.Add(customerDto);
            }
            else
            {
                return this._restClient.Update(customerDto);
            }
        }

        public void SetView(ICustomerView view)
        {
            this._view = view;
            base.SetView(view);
        }

        protected override object BuidDtoForEdit(int id)
        {
            return this._restClient.Get(id);
        }

        protected override object BuildDto()
        {
            return new CustomerDto();
        }
    }
}
