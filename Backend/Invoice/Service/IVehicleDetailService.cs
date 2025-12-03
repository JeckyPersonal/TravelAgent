using Invoice.Controllers;
using Invoice.Model;

namespace Invoice.Service
{
    public interface IVehicleDetailService : IService<VehicleDetail>
    {
        Task<bool> DeleteAll(List<VehicleDetail> vehicleDetailByVechilceId);
        Task<List<VehicleDetail>> GetByVehicleId(int vehicleId);
    }
}
