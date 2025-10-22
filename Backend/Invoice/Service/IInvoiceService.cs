namespace Invoice.Service
{
    public interface IInvoiceService : IService<Model.Invoice>
    {
        string GetInvoiceNo();
    }
}
