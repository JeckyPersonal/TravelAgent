using Invoice.DTO;
using Invoice.Model;

namespace Invoice.Service
{
    public interface IItemMasterService : IService<ItemMaster>
    {
         Task<List<ItemInterval>> GetAllIntervals();
    }
}
