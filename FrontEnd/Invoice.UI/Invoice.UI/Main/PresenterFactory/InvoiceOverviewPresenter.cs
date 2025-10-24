using Invoice.UI.Bank;
using Invoice.UI.Bank.BankDetail;
using Invoice.UI.DTO;
using Invoice.UI.InvoiceModule;
using Invoice.UI.Rental;
using Invoice.UI.UtilsUI.GridSelection;
using Invoice.UI.Vehicle.RateConfiguration;
using System.Data;

namespace Invoice.UI.Main.PresenterFactory
{
    internal class InvoiceOverviewPresenter : IOverviewPresenter
    {
        private readonly InvoiceModule.InvoiceRestClient _invoiceRestClient;
        private readonly InvoiceModule.InvoiceDetailRestClient _invoiceDetailRestClient;
        private readonly BankRestClient _bankRestClient;
        private readonly BankDetailRestClient _bankDetailRestClient;
        private readonly IDataGridFormatter _gridFormatter;
        private readonly IRowAdder<InvoiceDto> _invoiceRowAdder;
        private readonly VoucherRestClient _voucherRestClient; 
        private readonly CustomerRestClient _customerRestClient;
        private readonly DataTable _table;

        public InvoiceOverviewPresenter(InvoiceModule.InvoiceRestClient invoiceRestClient, InvoiceModule.InvoiceDetailRestClient invoiceDetailRestClient, VoucherRestClient voucherRestClient, CustomerRestClient customerRestClient, BankRestClient bankRestClient, BankDetailRestClient bankDetailRestClient, IDataGridFormatter gridFormatter)
        {
            this._invoiceRestClient = invoiceRestClient;
            this._invoiceDetailRestClient = invoiceDetailRestClient;
            this._voucherRestClient = voucherRestClient;
            this._customerRestClient = customerRestClient;
            this._bankRestClient = bankRestClient;
            this._bankDetailRestClient = bankDetailRestClient;
            this._gridFormatter = gridFormatter;
            this._invoiceRowAdder = gridFormatter as IRowAdder<InvoiceDto>;
            this._table = new DataTable();
        }

        public DataTable BuildTable()
        {
            this._invoiceRowAdder.AddColumns(this._table);

            this._invoiceRowAdder.BuildTable(new InvoiceLoader(this._invoiceRestClient), this._table);

            return this._table;
        }

        public BasePresenter CreatePresenter()
        {
            IDataGridFormatter gridFormatter = new VoucherDataGridFormatter();
            IRowAdder<VoucherMasterDto> gridOperation = gridFormatter as IRowAdder<VoucherMasterDto>;
            GridSelectionPresenter<VoucherMasterDto> gridSelectionPresenter = new GridSelectionPresenter<VoucherMasterDto>(gridFormatter, gridOperation);
            InvoicePresenter presenter = new InvoicePresenter(this._invoiceRestClient, this._invoiceDetailRestClient, this._customerRestClient, this._voucherRestClient, this._bankRestClient, this._bankDetailRestClient, new InvoiceDetailGridFormatter());
            frmInvoice invoice = new frmInvoice(presenter, gridSelectionPresenter);
            return presenter;
        }

        public IDataGridFormatter GetDataGridFormatter()
        {
            return InvoiceDataGridFormatter.Instance;
        }

        public Menu GetMenu()
        {
            return Menu.Invoice;
        }
    }
}
