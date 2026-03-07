using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.Model
{
    public class FinancialYear : ICompanyOwnedEntity
    {
        public int Id { get;set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<PaymentReceived> Payments { get; set; }
        public List<VoucherMaster> Vouchers { get; set; }
        public List<TenderMaster> Tenders { get; set; }
    }
}
