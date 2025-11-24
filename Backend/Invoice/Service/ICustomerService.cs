using Invoice.Model;

namespace Invoice.Service
{
    public interface ICustomerService : IService<Customer>
    {
        Task<List<Customer>> GetAllCustomerWithPendingVoucher();

        Task<List<Customer>> GetAllWithPendingInvoice();
    }
}
