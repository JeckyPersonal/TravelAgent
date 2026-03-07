using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.InvoiceModule
{
    internal interface IInvoiceView : IBaseView
    {
        void ClearDetail();
        void ClearDetailUI();
        BankDto GetSelectedBank();
        void SelectCustomer(CustomerDto customerById);
        DataRow SelectedDetailRow();
        void SetBankDetailDataSource(List<BankDetailDto> bankDetail);
        void SetBankSource(List<BankDto> banks);
        void SetCustomerSource(List<CustomerDto> customers);
        void SetInvoiceDetailDto(InvoiceDetailDto detailDto);
        void SetInvoiceDetailGridFormatter(IDataGridFormatter invoiceDetailGridFormatter);
        void SetInvoiceDetailSource(DataTable detailTable);
        void SetItemInfo(ItemMasterDto itemById);
        void SetItemSource(List<string> itemsString);
        void SetSummary(double totalAmount, double totalCGST, double totalSGST, double totalIGST, double netAmount);
        void SetVoucherIds(List<int> voucherIds);
        void ApplyTenderChanges(bool applyChanges,TenderDto tenderDetail);
    }
}
