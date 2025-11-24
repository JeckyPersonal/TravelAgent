using Invoice.UI.DTO;
using Invoice.UI.InvoiceModule;
using Invoice.UI.Main.PresenterFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Payment
{
    internal class PaymentPresenter : BasePresenter
    {
        private readonly PaymentRestClient _paymentRestClient;
        private readonly CustomerRestClient _customerRestClient;
        private readonly InvoiceRestClient _invoiceRestClient;
        private IPaymentView _view;

        public PaymentPresenter(PaymentRestClient paymentRestClient, CustomerRestClient customerRestClient, InvoiceRestClient invoiceRestClient)
        {
            _paymentRestClient = paymentRestClient;
            _customerRestClient = customerRestClient;
            _invoiceRestClient = invoiceRestClient;
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void SaveAndClose()
        {
            this.savePayment();
            this._view.CloseUI();
        }

        public override void SaveAndNew()
        {
            this.savePayment();
            this._view.ClearUI();
        }


        public void LoadAllCustomer()
        {
            List<CustomerDto> customers = this._customerRestClient.GetAll();

            this._view.SetCustomerSource(customers);
        }

        private void savePayment()
        {
            PaymentDto paymentDto = this._view.GetDto() as PaymentDto;

            if (this._view.GetMode() == ActionMode.New)
                this._paymentRestClient.Add(paymentDto);
            else
                this._paymentRestClient.Update(paymentDto);
        }

        protected override object BuidDtoForEdit(int id)
        {
            return this._paymentRestClient.Get(id);
        }

        public void SetView(IPaymentView view)
        {
            this._view = view;
            base.SetView(view);
        }

        protected override object BuildDto()
        {
            return new PaymentDto()
            {
                ReveivedDate = DateTime.Now,
            };
        }

        internal void ShowInvoiceOfCustomer()
        {
            CustomerDto selectedCustomer = this._view.GetSelectedCustomer();

            if (selectedCustomer == null) return;

            List<InvoiceDto> invoices = this._invoiceRestClient.GetAllPendingInvoice(selectedCustomer.Id, new List<int>());
        }
    }
}
