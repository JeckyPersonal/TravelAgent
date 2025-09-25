using Invoice.Controllers;
using Invoice.Model;

namespace Invoice.Service
{
    public interface IVehicleDetailService : IService<VehicleDetail>
    {
        Task<List<VehicleDetail>> GetByVehicleId(int vehicleId);
    }
}
