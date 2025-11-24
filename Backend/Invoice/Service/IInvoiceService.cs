using Invoice.Model;

namespace Invoice.Service
{
    public interface IInvoiceService : IService<Model.Invoice>
    {
        Task<Model.Invoice> GetInvoiceForPrint(int invoiceId);
        string GetInvoiceNo();
        Task<Model.Invoice> UpdateStatus(int id, VoucherStatus invoice_Printed);

        Task<List<Model.Invoice>> GetAllPendingInvoiceOfCustomer(int customerId);
    }
}
