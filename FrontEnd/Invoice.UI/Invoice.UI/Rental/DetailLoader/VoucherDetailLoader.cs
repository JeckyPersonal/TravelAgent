using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Rental.DetailLoader
{
    internal class VoucherDetailLoader : EntityLoader<VoucherDetailDto>
    {
        private readonly VouchelrDetailRestClient _voucherDetailRestClient;
        private readonly int _voucherId;

        public VoucherDetailLoader(VouchelrDetailRestClient voucherDetailRestClient, int voucherId)
        {
            _voucherDetailRestClient = voucherDetailRestClient;
            _voucherId = voucherId;
        }

        public List<VoucherDetailDto> GetEntities()
        {
            return this._voucherDetailRestClient.GetAll(this._voucherId);
        }
    }
}
