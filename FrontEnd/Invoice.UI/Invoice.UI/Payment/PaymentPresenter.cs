using Invoice.UI.DTO;
using Invoice.UI.InvoiceModule;
using Invoice.UI.Main.PresenterFactory;
using Invoice.UI.Rental;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly DataTable _invoiceDetailTable;

        private readonly IDataGridFormatter _invoiceDetailGridFormatter;
        private readonly IRowAdder<InvoiceDto> _invoiceDetailRowAdder;

        public PaymentPresenter(PaymentRestClient paymentRestClient, CustomerRestClient customerRestClient, InvoiceRestClient invoiceRestClient)
        {
            _paymentRestClient = paymentRestClient;
            _customerRestClient = customerRestClient;
            _invoiceRestClient = invoiceRestClient;
            _invoiceDetailTable = new DataTable();
            _invoiceDetailGridFormatter = new InvoiceGridFormatterForPayment();
            _invoiceDetailRowAdder = _invoiceDetailGridFormatter as IRowAdder<InvoiceDto>;
        }

        public override void Close()
        {
            this._view.CloseUI();
        }

        public override void SaveAndClose()
        {
            this.savePayment();
            this._view.CloseUI();
        }

        public override void SaveAndNew()
        {
            PaymentDto payment = this.savePayment();

            foreach (DataRow row in this._invoiceDetailTable.Rows)
            {
                InvoiceDto invoiceDto = this._invoiceDetailRowAdder.GetObject(row);

                int invoiceId = invoiceDto.Id;
                int paymentId = payment.Id;

                this._paymentRestClient.AddInvoice(invoiceId, paymentId);
            }

            this._view.ClearUI();
        }


        public void LoadAllCustomer()
        {
            List<CustomerDto> customers = this._customerRestClient.GetAll();

            this._view.SetCustomerSource(customers);
        }

        private PaymentDto savePayment()
        {
            PaymentDto paymentDto = this._view.GetDto() as PaymentDto;

            if (this._view.GetMode() == ActionMode.New)
                return this._paymentRestClient.Add(paymentDto);
            else
                return this._paymentRestClient.Update(paymentDto);
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

        internal void AddInvoices(List<InvoiceDto> invoices)
        {
            _invoiceDetailRowAdder.BuildTable(new DummyInvoiceLoader(invoices), this._invoiceDetailTable);

            this._view.SetPaymentDetailSource(this._invoiceDetailTable, _invoiceDetailGridFormatter);

            this._view.SetInvoiceAmount(this.calculateTotalAmount());
        }

        private double calculateTotalAmount()
        {
            if (this._invoiceDetailTable.Rows.Count == 0) return 0.00;

            double totalAmount = 0.00;

            foreach (DataRow row in this._invoiceDetailTable.Rows)
            {
                InvoiceDto invoiceOfRow = _invoiceDetailRowAdder.GetObject(row);

                totalAmount += invoiceOfRow.Amount;
            }

            return totalAmount;
        }

        internal void LoadDetail(int paymentId)
        {
            _invoiceDetailRowAdder.BuildTable(new PaymentDetailLoader(this._invoiceRestClient, paymentId), this._invoiceDetailTable);

            this._view.SetPaymentDetailSource(this._invoiceDetailTable, _invoiceDetailGridFormatter);
        }
    }
}
