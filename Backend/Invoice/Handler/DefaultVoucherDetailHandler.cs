using Invoice.DTO;
using Invoice.Model;
using Invoice.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Invoice.Handler
{
    public class DefaultVoucherDetailHandler
    {
        private readonly IVehicleRateService _vehicleRateService;

        public DefaultVoucherDetailHandler(IVehicleRateService vehicleRateService)
        {
            this._vehicleRateService = vehicleRateService;
        }

        private double calculateAmount(double rate, int interval, int totalDays, ItemMaster item)
        {
            if (interval > 0)
            {
                int frequency = totalDays / interval;

                if (frequency < 1) frequency = 1;

                return rate * item.Quantity.Value * frequency;
            }
            else
            {
                return rate * item.Quantity.Value;
            }
        }

        private VoucherDetailDto createVoucherDetail(VehicleRateConfiguration rateConfiguration, int totalDays)
        {
            ItemMaster itemMaster = rateConfiguration.ItemMaster;
            ItemInterval intervalMaster = itemMaster.Interval;
            int interval = intervalMaster.Interval;

            return new VoucherDetailDto()
            {
                Id = 0,
                ItemId = rateConfiguration.ItemId,
                Interval = interval,
                IntervalName = intervalMaster.IntervalName,
                Rate = rateConfiguration.Rate,

                Quantity = Convert.ToInt32(itemMaster.Quantity),
                ItemName = itemMaster.ItemName,
                Unit = itemMaster.Unit,

                Amount = calculateAmount(rateConfiguration.Rate, interval, totalDays, itemMaster)
            };

        }

        public async Task<List<VoucherDetailDto>> GetDefaultDetail(int vehicleId, int customerId, int totalDays)
        {
            List<VehicleRateConfiguration> rateConfigurations = await this._vehicleRateService.GetAllCustomerRates(vehicleId, customerId, Model.ConfigurationType.Customer);

            if (rateConfigurations.Count == 0) return new List<VoucherDetailDto>();

            return rateConfigurations.Select(x => this.createVoucherDetail(x, totalDays)).ToList();
        }
    }
}
