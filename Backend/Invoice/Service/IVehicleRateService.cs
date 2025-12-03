using Invoice.Model;

namespace Invoice.Service
{
    public interface IVehicleRateService : IService<VehicleRateConfiguration>
    {
        Task<List<VehicleRateConfiguration>> GetAllRates(int vehicleId, ConfigurationType type);

        Task<List<VehicleRateConfiguration>> GetAllCustomerRates(int vehicleId, int customerId, ConfigurationType type);

        Task<VehicleRateConfiguration> GetRateInfo(int vehicleId, int itemId);
        Task<VehicleRateConfiguration> GetCustomerRateForItem(int customerId, int vehicleId, int itemId, ConfigurationType customer);

        Task<VehicleRateConfiguration> DeleteRate(int id);
        Task<bool> DeleteAll(List<VehicleRateConfiguration> rateConfigurationByVehicle);
        Task<List<VehicleRateConfiguration>> GetAllCustomerRates(int customerId);
    }
}
