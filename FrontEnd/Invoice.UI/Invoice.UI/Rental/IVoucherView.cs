using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Rental
{
    internal interface IVoucherView : IBaseView
    {
        void ClearDetailView();
        void SetCustomerSource(List<CustomerDto> customers);
        void SetVehicleSource(List<VehicleDto> vehicle);
        void SetVehicleRegistrationSource(List<VehicleDetailDto> vehicleDetail);
        VehicleDto GetSelectedVehicle();
        void SetItemSource(List<ItemMasterDto> items);
        void SetPickupLocation(List<string> locations);
        void SetDropLocation(List<string> locations);
        void SetDriverSource(List<DriverDto> drivers);
        List<VoucherDetailDto> GetDetails();
        void SetDetails(List<VoucherDetailDto> details);
        int GetVoucherId();
        void SetDetailSource(DataTable detailTable, VoucherDetailGridFormatter detailGridFormatter);
        CustomerDto GetSelectedCustomer();
        void ShowItemInfo(VehicleRateDto vehicleRate);
        void ShowItemInfo(ItemMasterDto itemMasterDto);
        void SetVoucherNo(string voucherNo);
        void SetDetailGridFormatter(VoucherDetailGridFormatter detailGridFormatter);
        DataRow SelectedDetailItem();
        void SetDetailDto(VoucherDetailDto detailDto);
    }
}
