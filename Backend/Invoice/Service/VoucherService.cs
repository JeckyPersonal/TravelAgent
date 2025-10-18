using Invoice.Model;
using Invoice.Repository;

namespace Invoice.Service
{
    public class VoucherService : IVoucherService
    {
        private readonly IInvoiceRepository<VoucherMaster> _voucherRepository;
        private readonly AssertService<VoucherMaster> _assertService;

        public VoucherService(IInvoiceRepository<VoucherMaster> voucherRepository)
        {
            _voucherRepository = voucherRepository;
            _assertService = new AssertService<VoucherMaster>(_voucherRepository);
        }

        public async Task<VoucherMaster> Add(VoucherMaster entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(VoucherMaster));

            return await this._voucherRepository.Add(entity);
        }

        public async Task<VoucherMaster> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(id));

            return await this._voucherRepository.Get(x => x.Id.Equals(id), true);
        }

        public async Task<List<VoucherMaster>> GetAll()
        {
            List<string> pathsEntity = new List<string>() { "Customer", "Vehicle", "VehicleDetail", "Driver" };
            return await this._voucherRepository.GetAll(pathsEntity);
        }

        public string GetVoucherNo()
        {

            int totalVoucherPerMonth = this._voucherRepository.GetMultiple(x => x.VoucherDate.Month.Equals(DateTime.Now.Month), true).Result.Count;

            totalVoucherPerMonth = totalVoucherPerMonth == 0 ? 1 : totalVoucherPerMonth;
            string voucherIndex = string.Empty;
            if (totalVoucherPerMonth < 10)
            {
                voucherIndex = $"00{totalVoucherPerMonth}";
            }
            else if (totalVoucherPerMonth < 100)
            {
                voucherIndex = $"0{totalVoucherPerMonth}";
            }
            else
            {
                voucherIndex = totalVoucherPerMonth.ToString();
            }

            string currentTime = $"{DateTime.Now.ToString("dd-MMM-yyyy")}-{voucherIndex}";

            return currentTime;

        }

        public async Task<VoucherMaster> Update(VoucherMaster entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, nameof(VoucherMaster));

            VoucherMaster voucherById = await this._assertService.AssertEntityExist(x => x.Id.Equals(entity.Id), nameof(VoucherMaster));

            voucherById.VoucherDate = entity.VoucherDate;
            voucherById.FromDate = entity.FromDate;
            voucherById.ToDate = entity.ToDate;
            voucherById.PickupLocation = entity.PickupLocation;
            voucherById.DropLocation = entity.DropLocation;
            voucherById.CustomerId = entity.CustomerId;
            voucherById.DriverId = entity.DriverId;
            voucherById.RegistrationId = entity.RegistrationId;
            voucherById.VehicleId = entity.VehicleId;
            voucherById.VoucherNo = entity.VoucherNo;
            voucherById.Days = entity.Days;
            //voucherById.FinancialYearId = entity.FinancialYearId;

            return await this._voucherRepository.Update(voucherById);
        }
    }
}
