using AutoMapper;
using Invoice.DTO;
using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Service;

namespace Invoice.Handler.Delete
{
    public class DeleteCustomer
    {
        private readonly IVoucherService _voucherService;
        private readonly ICustomerService _customerService;
        private readonly IVehicleRateService _vehicleRateService;
        private readonly InvoiceDBContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteCustomer(IVoucherService voucherService, ICustomerService customerService, IVehicleRateService vehicleRateService, InvoiceDBContext dbContext, IMapper mapper)
        {
            _voucherService = voucherService;
            _customerService = customerService;
            _vehicleRateService = vehicleRateService;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Delete(int customerId)
        {
            Model.VoucherMaster voucherByCustomer = await this._voucherService.GetVoucherByCustomer(customerId);

            if (voucherByCustomer != null)
                throw new DeleteConflictException("This customer cannot be deleted because it is linked to records in other modules. Please delete or update the related records before attempting to delete the customer.");

            using (var trasaction = await this._dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    List<VehicleRateConfiguration> allRatesForCustomer = await this._vehicleRateService.GetAllCustomerRates(customerId);

                    await this._vehicleRateService.DeleteAll(allRatesForCustomer);

                    Customer deletedCustomer = await this._customerService.Delete(customerId);

                    await trasaction.CommitAsync();

                    return _mapper.Map<CustomerDto>(deletedCustomer);
                }
                catch (Exception ex)
                {
                    await trasaction.RollbackAsync();
                    throw ex;
                }
            }
        }
    }
}
