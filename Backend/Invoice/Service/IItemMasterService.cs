using Invoice.DTO;
using Invoice.Model;

namespace Invoice.Service
{
    public interface IItemMasterService : IService<ItemMaster>
    {
        Task<List<ItemInterval>> GetAllIntervals();

        Task<ItemMaster> GetWithInterval(int id);
    }
}
