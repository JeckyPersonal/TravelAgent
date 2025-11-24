using Invoice.Model;

namespace Invoice.Service
{
    public interface IPaymentService : IService<PaymentReceived>
    {
        //Task<double> GetTotalPaymentOfInvoice(int invoiceId);
    }
}
