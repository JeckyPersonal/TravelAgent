using Invoice.Test.Model.Company;
using Invoice.UI.Bank;
using Invoice.UI.Bank.BankDetail;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Invoice.UI.Item;
using Invoice.UI.Main.PresenterFactory;
using Invoice.UI.Rental;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Invoice.UI.InvoiceModule
{
    internal class InvoicePresenter : BasePresenter
    {
        private IInvoiceView _invoiceView;
        private readonly DataTable _detailTable;
        private readonly InvoiceRestClient _invoiceRestClient;
        private readonly CustomerRestClient _custerRestClient;
        private readonly VoucherRestClient _voucherRestClient;
        private readonly InvoiceDetailRestClient _invoiceDetailRestClient;
        private readonly BankRestClient _bankRestClient;
        private readonly BankDetailRestClient _bankDetailRestClient;
        private readonly IDataGridFormatter _invoiceDetailGridFormatter;
        private readonly ItemRestClient _itemRestClient;
        private readonly IRowAdder<InvoiceDetailDto> _rowAdder;

        public InvoicePresenter(InvoiceRestClient invoiceRestClient, InvoiceDetailRestClient invoiceDetailRestClient, CustomerRestClient custerRestClient, VoucherRestClient voucherRestClient, BankRestClient bankRestClient, BankDetailRestClient bankDetailRestClient, ItemRestClient itemRestClient, IDataGridFormatter invoiceDetailGridFormatter)
        {
            _detailTable = new DataTable();
            _invoiceRestClient = invoiceRestClient;
            _invoiceDetailRestClient = invoiceDetailRestClient;
            _custerRestClient = custerRestClient;
            _voucherRestClient = voucherRestClient;
            _invoiceDetailGridFormatter = invoiceDetailGridFormatter;
            _bankRestClient = bankRestClient;
            _bankDetailRestClient = bankDetailRestClient;
            _itemRestClient = itemRestClient;
            _rowAdder = invoiceDetailGridFormatter as IRowAdder<InvoiceDetailDto>;
        }

        public override void Close()
        {
            this._invoiceView.CloseUI();
        }

        public void LoadCustomer()
        {
            if (this._invoiceView.GetMode() == ActionMode.Edit) return;

            List<CustomerDto> customers = this._custerRestClient.GetAllCustomerWithPendingVoucher();
            this._invoiceView.SetCustomerSource(customers);
        }

        public override void SaveAndClose()
        {
            this.saveInvoice();
            this._invoiceView.CloseUI();
        }

        private void saveInvoice()
        {
            try
            {
                InvoiceDto invoiceDto = this._invoiceView.GetDto() as InvoiceDto;
                InvoiceDto savedDto = null;
                if (this._invoiceView.GetMode() == ActionMode.New)
                {
                    savedDto = this._invoiceRestClient.Add(invoiceDto);
                }
                else
                {
                    savedDto = this._invoiceRestClient.Update(invoiceDto);
                }

                foreach (DataRow row in this._detailTable.Rows)
                {
                    InvoiceDetailDto invoiceDetailDto = this._rowAdder.GetObject(row);

                    if (invoiceDetailDto.ActionMode == ActionMode.None) continue;

                    if (invoiceDetailDto.ActionMode == ActionMode.New)
                    {
                        this._invoiceDetailRestClient.Add(savedDto.Id, invoiceDetailDto);
                    }
                    else if (invoiceDetailDto.ActionMode == ActionMode.Edit)
                    {
                        this._invoiceDetailRestClient.Update(invoiceDetailDto);
                    }
                    else if (invoiceDetailDto.ActionMode == ActionMode.Delete)
                    {
                        this._invoiceDetailRestClient.Delete(invoiceDetailDto.Id);
                    }
                }
            }
            catch (ValidationException ex) {
                this._invoiceView.ShowError(ex.Errors);
            }

        }

        public override void SaveAndNew()
        {
            this.saveInvoice();
            this._invoiceView.ShowMessage();
            this._invoiceView.ClearUI();
            this._detailTable.Rows.Clear();
        }

        protected override object BuidDtoForEdit(int id)
        {
            InvoiceDto invoiceById = this._invoiceRestClient.Get(id);

            this._invoiceView.SetVoucherIds(invoiceById.Vouchers);

            return invoiceById;
        }

        protected override object BuildDto()
        {
            return new InvoiceDto();
        }

        public void SetView(IInvoiceView view)
        {
            this._invoiceView = view;
            this._invoiceView.SetInvoiceDetailGridFormatter(this._invoiceDetailGridFormatter);
            base.SetView(view);
        }

        internal void ProcessVoucher(List<VoucherMasterDto> vouchers)
        {
            List<int> voucherIds = vouchers.Select(x => x.Id).ToList();

            VoucherProcessDto processDto = new VoucherProcessDto()
            {
                VoucherIds = voucherIds,
                ExcludedDetailId = this.GetAddedVoucherDetailId()
            };

            EntityLoader<InvoiceDetailDto> entitLoader = new ProcessedInvoiceDetailLoader(processDto, this._voucherRestClient);

            if (this._detailTable.Rows.Count == 0)
                this._rowAdder.BuildTable(entitLoader, this._detailTable);
            else
                this._rowAdder.AppendRows(entitLoader, this._detailTable);

            this.processSummary();

            this._invoiceView.SetVoucherIds(voucherIds);
            this._invoiceView.SetInvoiceDetailSource(this._detailTable);

        }

        internal List<int> GetAddedVoucherDetailId()
        {
            List<int> addedVoucherDetails = new List<int>();

            if (this._detailTable.Rows.Count == 0) return addedVoucherDetails;

            foreach (DataRow row in this._detailTable.Rows)
            {
                int? voucherDetailId = this._rowAdder.GetObject(row).VoucherDetailId;
                if (voucherDetailId != null)
                    addedVoucherDetails.Add(voucherDetailId.Value);
            }

            return addedVoucherDetails;
        }

        internal void SetInvoiceDetail(int invoiceId)
        {
            this._rowAdder.BuildTable(new InvoiceDetailLoader(this._invoiceDetailRestClient, invoiceId), this._detailTable);

            this._invoiceView.SetInvoiceDetailSource(this._detailTable);
        }

        private void processSummary()
        {
            double totalAmount = 0;
            double totalCGST = 0;
            double totalSGST = 0;
            double totalIGST = 0;
            double netAmount = 0;

            foreach (DataRow row in this._detailTable.Rows)
            {
                InvoiceDetailDto invoiceDetail = this._rowAdder.GetObject(row);

                totalAmount += invoiceDetail.AmountBeforeGST;
                totalCGST += invoiceDetail.CGST;
                totalSGST += invoiceDetail.SGST;
                totalIGST += invoiceDetail.IGST;
                netAmount += invoiceDetail.Amount;
            }

            this._invoiceView.SetSummary(totalAmount, totalCGST, totalSGST, totalIGST, netAmount);
        }

        internal void LoadBank()
        {
            List<BankDto> banks = this._bankRestClient.GetAll();

            this._invoiceView.SetBankSource(banks);
        }

        internal void LoadAccountNumber()
        {
            BankDto selectedBank = this._invoiceView.GetSelectedBank();

            if (selectedBank == null) return;

            List<BankDetailDto> bankDetail = this._bankDetailRestClient.GetByBank(selectedBank.Id);
            this._invoiceView.SetBankDetailDataSource(bankDetail);
        }

        internal void LoadItems()
        {
            List<ItemMasterDto> items = this._itemRestClient.GetAll();

            List<string> itemsString = items.Select(x => $"{x.ItemName} ({x.Id})").ToList();

            this._invoiceView.SetItemSource(itemsString);
        }

        internal void SetItemRates(int itemId)
        {
            try
            {
                ItemMasterDto itemById = this._itemRestClient.Get(itemId);

                this._invoiceView.SetItemInfo(itemById);
            }
            catch (ValidationException ex) {
                this._invoiceView.ShowError(ex.Errors);
            }
        }

        internal void SetCustomerDetail(int customerId)
        {
            CustomerDto customerById = this._custerRestClient.Get(customerId);
            this._invoiceView.SelectCustomer(customerById);
        }

        internal void AddInvoiceDetailDto(InvoiceDetailDto invoiceDetailDto)
        {
            DataRow row = this._detailTable.NewRow();
            this._rowAdder.AddRow(invoiceDetailDto, row);
            this._detailTable.Rows.Add(row);
            this._invoiceView.ClearDetail();
        }

        internal void UpdateInvoiceDetailDto(InvoiceDetailDto invoicecDetaildto)
        {
            DataRow selectedRow = this._invoiceView.SelectedDetailRow();
            this._rowAdder.AddRow(invoicecDetaildto, selectedRow);
        }

        internal void EditDetailDto()
        {
            DataRow selectedRow = this._invoiceView.SelectedDetailRow();
            InvoiceDetailDto detailDto = this._rowAdder.GetObject(selectedRow);
            this._invoiceView.SetInvoiceDetailDto(detailDto);
        }

        internal void PrintInvoice(int invoiceId)
        {
            this._invoiceRestClient.Print(invoiceId);
        }
    }
}
