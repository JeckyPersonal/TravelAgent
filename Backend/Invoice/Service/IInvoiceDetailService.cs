using Invoice.Model;

namespace Invoice.Service
{
    public interface IInvoiceDetailService : IService<InvoiceDetail>
    {
        Task<List<Invoice.Model.InvoiceDetail>> GetAll(int invoiceId);
    }
}
