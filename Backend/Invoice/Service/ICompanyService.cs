using Invoice.Model;

namespace Invoice.Service
{
    public interface ICompanyService : IService<Company>
    {
        Task<Company> GetWithSingleRelatedEntity(int companyId);
    }
}
