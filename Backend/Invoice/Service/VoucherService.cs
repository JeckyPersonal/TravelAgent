using Invoice.Model;
using Invoice.Repository;
using Invoice.Utils;
using Microsoft.OpenApi.Writers;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        public async Task<VoucherMaster> Delete(int id)
        {
            VoucherMaster voucherMaster = await this._assertService.AssertEntityExist(x => x.Id.Equals(id), nameof(VoucherMaster));

            return await this._voucherRepository.Delete(voucherMaster);
        }

        public async Task<VoucherMaster> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(id));

            List<string> pathsEntity = new List<string>() { "Customer", "Vehicle", "VehicleDetail", "Driver" };
            return await this._voucherRepository.Get(x => x.Id.Equals(id), true, pathsEntity);
        }

        public async Task<List<VoucherMaster>> GetAll()
        {
            List<string> pathsEntity = new List<string>() { "Customer", "Vehicle", "VehicleDetail", "Driver" };
            return await this._voucherRepository.GetAll(pathsEntity);
        }

        public async Task<List<VoucherMaster>> GetAllByInvoice(int invoiceId)
        {
            this._assertService.AssertNonZeroId(invoiceId, nameof(VoucherMaster));

            return await this._voucherRepository.GetMultiple(x => x.InvoiceId.Equals(invoiceId), true);
        }

        public async Task<VoucherMaster> GetByDriverId(int driverId)
        {
            this._assertService.AssertNonZeroId(driverId, nameof(VoucherMaster));

            return await this._voucherRepository.Get(x => x.DriverId.Equals(driverId), true);
        }

        public async Task<VoucherMaster> GetByVehilceNo(int vehicleDetailId)
        {
            this._assertService.AssertNonZeroId(vehicleDetailId, nameof(VoucherMaster));

            return await this._voucherRepository.Get(x => x.RegistrationId.Equals(vehicleDetailId), true);
        }

        public async Task<List<VoucherMaster>> GetPendingVoucher(int customerId)
        {
            this._assertService.AssertNonZeroId(customerId, nameof(VoucherMaster));

            List<string> pathsEntity = new List<string>() { "Customer", "Vehicle", "VehicleDetail", "Driver" };
            return await this._voucherRepository.GetMultipleInclude(x => x.InvoiceId == null &&
            x.CustomerId == customerId, true, pathsEntity);
        }

        public async Task<VoucherMaster> GetVoucherByCustomer(int customerId)
        {
            this._assertService.AssertNonZeroId(customerId, nameof(VoucherMaster));

            return await this._voucherRepository.Get(x => x.CustomerId.Equals(customerId), true);
        }

        public async Task<List<VoucherMaster>> GetVoucherBySearchCriteria(string voucherStatus, string customerName, string voucherNo, string vehicleName, string driverName, string registrationNo, string pickupLocation, string dropLocation)
        {
            var predicate = PredicateBuilder.True<VoucherMaster>();

            if (!string.IsNullOrEmpty(voucherStatus))
            {
                VoucherStatus queryVoucherStatus = (VoucherStatus)Enum.Parse(typeof(VoucherStatus), voucherStatus);
                predicate = predicate.And(u => u.voucherStatus.Equals(queryVoucherStatus));
            }

            if (!string.IsNullOrEmpty(customerName))
            {
                predicate = predicate.And(v => v.Customer.Name.Equals(customerName));
            }

            if(!string.IsNullOrEmpty(voucherNo))
            {
                predicate = predicate.And(v => v.VoucherNo.Contains(voucherNo));
            }

            if(!string.IsNullOrEmpty(vehicleName))
            {
                predicate = predicate.And(x => x.Vehicle != null && x.Vehicle.VehicleType.Contains(vehicleName));
            }

            if(!string.IsNullOrEmpty(driverName))
            {
                predicate = predicate.And(x => x.Driver!= null && x.Driver.DriverName.Contains(vehicleName));
            }

            if(!string.IsNullOrEmpty(registrationNo))
            {
                predicate = predicate.And(x => x.VehicleDetail != null && x.VehicleDetail.RegistrationNumber.Contains(registrationNo));
            }

            if(!string.IsNullOrEmpty(pickupLocation))
            {
                predicate = predicate.And(x => x.PickupLocation.Contains(pickupLocation));
            }
            if(!string.IsNullOrWhiteSpace(dropLocation))
            {
                predicate = predicate.And(x => x.DropLocation.Contains(dropLocation));
            }

            List<string> pathsEntity = new List<string>() { "Customer", "Vehicle", "VehicleDetail", "Driver" };

            return await this._voucherRepository.GetMultipleInclude(predicate, true, pathsEntity);
        }

        public async Task<VoucherMaster> GetVoucherByVehicleId(int vehicleId)
        {
            this._assertService.AssertNonZeroId(vehicleId, nameof(VoucherMaster));

            return await this._voucherRepository.Get(x => x.VehicleId.Equals(vehicleId), true);
        }

        public string GetVoucherNo()
        {

            int totalVoucherPerMonth = this._voucherRepository.GetMultiple(x => x.VoucherDate.Month == DateTime.Now.Month, true).Result.Count;

            totalVoucherPerMonth = totalVoucherPerMonth == 0 ? 1 : totalVoucherPerMonth + 1;
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

        public async Task<List<VoucherMaster>> UnlinkVouchers(int invoiceId)
        {
            this._assertService.AssertNonZeroId(invoiceId, nameof(VoucherMaster));

            List<VoucherMaster> vouchers = await this._voucherRepository.GetMultiple(x => x.InvoiceId.Equals(invoiceId), true);

            List<VoucherMaster> unlinkedVouchers = new List<VoucherMaster>();

            foreach (var item in vouchers)
            {
                item.InvoiceId = null;

                VoucherMaster unlinkedVoucher = await this._voucherRepository.Update(item);

                unlinkedVouchers.Add(unlinkedVoucher);
            }

            return unlinkedVouchers;
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
            voucherById.voucherStatus = entity.voucherStatus;
            voucherById.VisitorName = entity.VisitorName;
            voucherById.StartFrom = entity.StartFrom;
            voucherById.EndFrom = entity.EndFrom;
            voucherById.BillingWorkType = entity.BillingWorkType;

            return await this._voucherRepository.Update(voucherById);
        }

        public async Task<VoucherMaster> UpdateInvoiceId(int voucherId, int invoiceId)
        {
            this._assertService.AssertNonZeroId(voucherId, nameof(VoucherMaster));

            this._assertService.AssertNonZeroId(invoiceId, nameof(VoucherMaster));

            VoucherMaster voucherById = await this._assertService.AssertEntityExist(x => x.Id.Equals(voucherId), nameof(VoucherMaster));

            voucherById.InvoiceId = invoiceId;

            return await this._voucherRepository.Update(voucherById);
        }

        public async Task<VoucherMaster> UpdateStatus(int voucherId, VoucherStatus status)
        {
            this._assertService.AssertNonZeroId(voucherId, nameof(VoucherMaster));

            VoucherMaster voucherById = await this._assertService.AssertEntityExist(x => x.Id.Equals(voucherId), nameof(VoucherMaster));

            voucherById.voucherStatus = status;

            return await this._voucherRepository.Update(voucherById);
        }
    }
}
