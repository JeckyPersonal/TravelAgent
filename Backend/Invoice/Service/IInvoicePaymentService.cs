using Invoice.Model;

namespace Invoice.Service
{
    public interface IInvoicePaymentService : IService<InvoicePayment>
    {
        Task<List<InvoicePayment>> GetAllByPaymentId(int paymentId);
    }
}
