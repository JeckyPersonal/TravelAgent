using Invoice.UI.DTO;
using Invoice.UI.InvoiceModule;
using Invoice.UI.Payment;
using Invoice.UI.Rental;
using Invoice.UI.UtilsUI.GridSelection;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Main.PresenterFactory
{
    internal class PaymentOverviewPresenter : IOverviewPresenter
    {
        private readonly DataTable _table;
        private readonly PaymentRestClient _paymentRestClient;
        private readonly CustomerRestClient _customerRestClient;
        private readonly InvoiceRestClient _invoiceRestClient;

        public PaymentOverviewPresenter(PaymentRestClient paymentRestClient, CustomerRestClient customerRestClient, InvoiceRestClient invoiceRestClient)
        {
            _table = new DataTable();
            _paymentRestClient = paymentRestClient;
            _customerRestClient = customerRestClient;
            _invoiceRestClient = invoiceRestClient;
        }

        public DataTable BuildTable()
        {
            PaymentGridFormatter.Instance.BuildTable(new PaymentEntityLoader(this._paymentRestClient), this._table);
            return this._table;
        }

        public BasePresenter CreatePresenter()
        {
            IDataGridFormatter gridFormatter = InvoiceGridFormatterForPayment.Instance;
            IRowAdder<InvoiceDto> gridOperation = gridFormatter as IRowAdder<InvoiceDto>;
            GridSelectionPresenter<InvoiceDto> gridSelectionPresenter = new GridSelectionPresenter<InvoiceDto>(gridFormatter, gridOperation);

            PaymentPresenter presenter = new PaymentPresenter(this._paymentRestClient, this._customerRestClient, this._invoiceRestClient);
            frmPayment paymentView = new frmPayment(presenter, gridSelectionPresenter);
            return presenter;
        }

        public IDataGridFormatter GetDataGridFormatter()
        {
            return PaymentGridFormatter.Instance;
        }

        public Menu GetMenu()
        {
            return Menu.Payment;
        }
    }
}
