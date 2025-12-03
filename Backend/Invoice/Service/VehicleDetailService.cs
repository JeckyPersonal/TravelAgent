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

            this._assertService.AssertDuplicationEntity(x => x.RegistrationNumber.Equals(entity.RegistrationNumber), x => x.Id != entity.Id, nameof(VehicleDetail));

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<VehicleDetail> Delete(int id)
        {
            VehicleDetail vehicleDetail = await this.Get(id);

            return await this._invoiceRepository.Delete(vehicleDetail);
        }

        public async Task<bool> DeleteAll(List<VehicleDetail> vehicleDetailByVechilceId)
        {
            if (vehicleDetailByVechilceId == null || vehicleDetailByVechilceId.Count == 0) return false;

            await this._invoiceRepository.DeleteAll(vehicleDetailByVechilceId);

            return true;
        }

        public async Task<VehicleDetail> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(VehicleDetail));

            return await this._assertService.AssertEntityExist(x=> x.Id.Equals(id), nameof(VehicleDetail));
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

            this._assertService.AssertDuplicationEntity(x => x.RegistrationNumber.Equals(entity.RegistrationNumber), x => x.Id != entity.Id, nameof(VehicleDetail));

            VehicleDetail newDetail = await this._invoiceRepository.Get(x=> x.Id.Equals(entity.Id), true);

            newDetail.RegistrationNumber = entity.RegistrationNumber;

            return await this._invoiceRepository.Update(newDetail);
        }
    }
}
