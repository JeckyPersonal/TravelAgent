using Invoice.Model;

namespace Invoice.Service
{
    public interface IVehicleRateService : IService<VehicleRateConfiguration>
    {
        Task<List<VehicleRateConfiguration>> GetAllRates(int vehicleId);
    }
}
