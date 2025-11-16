using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Rental.DetailLoader
{
    internal class DefaultVoucherDetailLoader : EntityLoader<VoucherDetailDto>
    {
        private readonly VouchelrDetailRestClient _voucherDetailRestClient;
        private readonly int _totalDays;
        private readonly int _customerId;
        private readonly int _vehicleId;

        public DefaultVoucherDetailLoader(VouchelrDetailRestClient voucherDetailRestClient, int customerId, int vehicleId, int totalDays)
        {
            this._voucherDetailRestClient = voucherDetailRestClient;
            this._totalDays = totalDays;
            this._customerId = customerId;
            this._vehicleId = vehicleId;
        }

        public List<VoucherDetailDto> GetEntities()
        {
            return this._voucherDetailRestClient.GetDefaultVoucherDetail(this._vehicleId, this._customerId, this._totalDays);
        }
    }
}
