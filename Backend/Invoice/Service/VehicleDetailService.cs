using Invoice.Model;
using Invoice.Repository;
using System.Dynamic;

namespace Invoice.Service
{
    public class VehicleDetailService : IVehicleDetailService
    {
        private readonly IInvoiceRepository<VehicleDetail> _invoiceRepository;
        private readonly AssertService<VehicleDetail> _assertService;

        public VehicleDetailService(IInvoiceRepository<VehicleDetail> invoiceRepository)
        {
            this._invoiceRepository = invoiceRepository;
            this._assertService = new AssertService<VehicleDetail>(this._invoiceRepository);
        }

        public async Task<VehicleDetail> Add(VehicleDetail entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(VehicleDetail));

            VehicleDetail existingDetail = await this._assertService.AssertDuplicationEntity(x => x.RegistrationNumber.Equals(entity.RegistrationNumber), x => x.Id != entity.Id, nameof(VehicleDetail));

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<VehicleDetail> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(VehicleDetail));

            return await this._invoiceRepository.Get(x => x.Id == id, true);
        }

        public async Task<List<VehicleDetail>> GetAll()
        {
            return await this._invoiceRepository.GetAll();
        }

        public async Task<List<VehicleDetail>> GetByVehicleId(int vehicleId)
        {
            this._assertService.AssertNonZeroId(vehicleId, nameof(VehicleDetail));

            return await this._invoiceRepository.GetMultiple(x=> x.VehicleId.Equals(vehicleId), true);
        }

        public async Task<VehicleDetail> Update(VehicleDetail entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, nameof(VehicleDetail));

            VehicleDetail existingDetail = await this._assertService.AssertDuplicationEntity(x => x.RegistrationNumber.Equals(entity.RegistrationNumber), x => x.Id != entity.Id, nameof(VehicleDetail));

            existingDetail.RegistrationNumber = entity.RegistrationNumber;

            return await this._invoiceRepository.Update(entity);
        }
    }
}
