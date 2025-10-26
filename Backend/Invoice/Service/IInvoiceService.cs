namespace Invoice.Service
{
    public interface IInvoiceService : IService<Model.Invoice>
    {
        Task<Model.Invoice> GetInvoiceForPrint(int invoiceId);
        string GetInvoiceNo();
    }
}
