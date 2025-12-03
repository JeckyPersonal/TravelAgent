using Invoice.Model;

namespace Invoice.Service
{
    public interface IInvoicePaymentService : IService<InvoicePayment>
    {
        Task<List<InvoicePayment>> GetAllByPaymentId(int paymentId);
        Task<List<InvoicePayment>> DeleteByPaymentId(int paymentId);
        Task<List<InvoicePayment>> GetAllByInvoiceId(int invoiceId);
    }
}
