using Invoice.DTO;
using Invoice.Model;
using Invoice.Service;
using System.Threading.Tasks;

namespace Invoice.Handler
{
    public class RateInfoHandler
    {

        private readonly IService<ItemMaster> _itemMasterService;
        private readonly IVehicleRateService _vehicleRateService;

        public RateInfoHandler(IService<ItemMaster> itemMasterService, IVehicleRateService vehicleRateService)
        {
            _itemMasterService = itemMasterService;
            _vehicleRateService = vehicleRateService;
        }

        public async Task<RateInfoDto> GetRateInfo(int itemId, int? customerId, int? vehicleId)
        {
            if (customerId != null && vehicleId != null)
            {
                return await getCustomerRate(itemId, vehicleId.Value, customerId.Value);
            }
            else if (vehicleId != null)
            {
                return await getVehicleRate(itemId, vehicleId.Value);
            }
            else
            {
                return await getItemsRate(itemId);
            }
        }

        private async Task<RateInfoDto> getItemsRate(int itemId)
        {
            ItemMaster itemMaster = await this._itemMasterService.Get(itemId);
            return new RateInfoDto() { Unit = itemMaster.Unit, Quantity = itemMaster.Quantity.Value, Rate = itemMaster.Rate.Value, RateSource = RateSource.Item };
        }

        private async Task<RateInfoDto> getVehicleRate(int itemId, int vehicleId)
        {
            VehicleRateConfiguration vehicleRate = await this._vehicleRateService.GetRateInfo(vehicleId, itemId);

            if (vehicleRate == null)
            {
                return await getItemsRate(itemId);
            }
            else
            {
                return new RateInfoDto() { Unit = vehicleRate.ItemMaster.Unit, Quantity = vehicleRate.ItemMaster.Quantity.Value, Rate = vehicleRate.ItemMaster.Rate.Value, RateSource = RateSource.Vehicle };
            }
        }

        private async Task<RateInfoDto> getCustomerRate(int itemId, int vehicleId,int customerId)
        {
            VehicleRateConfiguration customerRateConfiguration = await this._vehicleRateService.GetCustomerRateForItem(customerId, vehicleId, itemId, ConfigurationType.Customer);

            if(customerRateConfiguration == null)
            {
                return await getVehicleRate(itemId, vehicleId);
            } else
            {
                return new RateInfoDto() { Unit = customerRateConfiguration.ItemMaster.Unit, Quantity = customerRateConfiguration.ItemMaster.Quantity.Value, Rate = customerRateConfiguration.ItemMaster.Rate.Value, RateSource = RateSource.Customer };
            }
        }
    }
}
