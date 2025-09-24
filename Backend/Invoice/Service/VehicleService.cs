using Invoice.Model;
using Invoice.Repository;

namespace Invoice.Service
{
    public class VehicleService : IService<Vehicle>
    {

        private readonly IInvoiceRepository<Vehicle> _invoiceRepository;
        private readonly AssertService<Vehicle> _assertService;

        public VehicleService(IInvoiceRepository<Vehicle> invoiceRepository)
        {
            this._invoiceRepository = invoiceRepository;
            this._assertService = new AssertService<Vehicle>(invoiceRepository);
        }

        public async Task<Vehicle> Add(Vehicle entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(entity));

            Vehicle existingVehicle = await this._assertService.AssertDuplicationEntity(x=> x.VehicleType.Equals(entity.VehicleType), x => x.Id != entity.Id, nameof(Vehicle));

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<Vehicle> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(Vehicle));

            return await this._invoiceRepository.Get(x => x.Id.Equals(id), true);
        }

        public async Task<List<Vehicle>> GetAll()
        {
            return await this._invoiceRepository.GetAll();
        }

        public async Task<Vehicle> Update(Vehicle entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(entity));

            Vehicle existingVehicle = await this._assertService.AssertDuplicationEntity(x => x.VehicleType.Equals(entity.VehicleType), x => x.Id != entity.Id, nameof(Vehicle));

            existingVehicle.VehicleType = entity.VehicleType;

            return await this._invoiceRepository.Update(entity);
        }
    }
}
