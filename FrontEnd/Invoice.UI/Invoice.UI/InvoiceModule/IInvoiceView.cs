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
        void SetBankDetailDataSource(List<BankDetailDto> bankDetail);
        void SetBankSource(List<BankDto> banks);
        void SetCustomerSource(List<CustomerDto> customers);
        void SetInvoiceDetailGridFormatter(IDataGridFormatter invoiceDetailGridFormatter);
        void SetInvoiceDetailSource(DataTable detailTable);
        void SetSummary(double totalAmount, double totalCGST, double totalSGST, double totalIGST, double netAmount);
        void SetVoucherIds(List<int> voucherIds);
    }
}
