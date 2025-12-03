using AutoMapper;
using Invoice.DTO;
using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Service;

namespace Invoice.Handler.Delete
{
    public class DeleteVehicle
    {

        private readonly IVoucherService _voucherService;
        private readonly IService<Vehicle> _vehicleService;
        private readonly IVehicleDetailService _vehicleDetailService;
        private readonly IVehicleRateService _vehicleRateService;
        private readonly InvoiceDBContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteVehicle(IVoucherService voucherService, IService<Vehicle> vehicleService, IVehicleDetailService vehicleDetailService, IVehicleRateService vehicleRateService, InvoiceDBContext dbContext, IMapper mapper)
        {
            _voucherService = voucherService;
            _vehicleService = vehicleService;
            _vehicleDetailService = vehicleDetailService;
            _vehicleRateService = vehicleRateService;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<VehicleDto> Delete(int vehicleId)
        {
            VoucherMaster voucherByVehicle = await this._voucherService.GetVoucherByVehicleId(vehicleId);
            if (voucherByVehicle != null)
                throw new DeleteConflictException("This vehicle cannot be deleted because it is linked to records in other modules. Please delete or update the related records before attempting to delete the vehicle.");

            using (var transaction = await this._dbContext.Database.BeginTransactionAsync())
            {
                try
                {

                    await this.deleteVehicleDetail(vehicleId);

                    await this.deleteVehicleRateConfiguration(vehicleId);

                    Vehicle deletedVehicle = await this._vehicleService.Delete(vehicleId);

                    transaction.CommitAsync();

                    return this._mapper.Map<VehicleDto>(deletedVehicle);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }

        }

        public async Task<VehicleDetailDto> DeleteVehicleDetail(int vehicleDetailId)
        {
            VoucherMaster voucherByVehicleNo = await this._voucherService.GetByVehilceNo(vehicleDetailId);
            if (voucherByVehicleNo != null)
                throw new DeleteConflictException("This registration cannot be deleted because it is linked to records in other modules. Please delete or update the related records before attempting to delete the registration.");

            using (var transaction = await this._dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    VehicleDetail vehicleDetail = await this._vehicleDetailService.Delete(vehicleDetailId);

                    await transaction.CommitAsync();

                    return _mapper.Map<VehicleDetailDto>(vehicleDetail);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }

        private async Task deleteVehicleRateConfiguration(int vehicleId)
        {
            List<VehicleRateConfiguration> rateConfigurationByVehicle = await this._vehicleRateService.GetAllRates(vehicleId, ConfigurationType.Vehicle);

            if (rateConfigurationByVehicle == null || rateConfigurationByVehicle.Count == 0) return;

            await this._vehicleRateService.DeleteAll(rateConfigurationByVehicle);
        }

        private async Task deleteVehicleDetail(int vehicleId)
        {
            List<VehicleDetail> vehicleDetailByVechilceId = await this._vehicleDetailService.GetByVehicleId(vehicleId);

            if (vehicleDetailByVechilceId == null || vehicleDetailByVechilceId.Count == 0) return;

            this._vehicleDetailService.DeleteAll(vehicleDetailByVechilceId);
        }
    }
}
