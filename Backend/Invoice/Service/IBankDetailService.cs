using Invoice.DTO;
using Invoice.Model;

namespace Invoice.Service
{
    public interface IBankDetailService : IService<BankDetail>
    {
        Task<List<BankDetail>> GetByBankId(int bankId);
    }
}
