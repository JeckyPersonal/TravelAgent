using Invoice.Model;

namespace Invoice.Service
{
    public interface ITenderFuelService : IService<FuelRate>
    {
        Task<List<FuelRate>> GetByTenderId(int tenderId);
    }
}
