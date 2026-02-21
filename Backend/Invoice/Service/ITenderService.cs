using Invoice.Model;

namespace Invoice.Service
{
    public interface ITenderService : IService<TenderMaster>
    {
        Task<TenderMaster> GetByCustomerId(int companyId);
    }
}
