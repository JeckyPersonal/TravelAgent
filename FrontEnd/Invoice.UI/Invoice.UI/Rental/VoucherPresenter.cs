using Invoice.UI.Driver;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using Invoice.UI.Item;
using Invoice.UI.Main.PresenterFactory;
using Invoice.UI.Rental.DetailLoader;
using Invoice.UI.Vehicle;
using Invoice.UI.Vehicle.RateConfiguration;
using Invoice.UI.Vehicle.VehicleDetail;
using System;
using System.Collections.Generic;
using System.Data;

namespace Invoice.UI.Rental
{
    internal class VoucherPresenter : BasePresenter
    {
        private IVoucherView _view;
        private readonly CustomerRestClient _customerRestClient;
        private readonly VehicleRestClient _vehicleRestClient;
        private readonly ItemRestClient _itemRestClient;
        private readonly VehicleDetailRestClient _vehicleDetailRestClient;
        private readonly VoucherRestClient _voucherRestClient;
        private readonly VouchelrDetailRestClient _voucherDetailRestClient;
        private readonly DriverRestClient _driverRestClient;
        private readonly VoucherDetailGridFormatter _detailGridFormatter;
        private readonly VehicleRateConfigurationRestClient _rateConfigurationClient;
        private readonly CustomerRateConfigurationRestClient _customerRateConfigurationClient;
        private readonly DataTable _detailTable;

        public VoucherPresenter(CustomerRestClient customerRestClient, VehicleRestClient vehicleRestClient, ItemRestClient itemRestClient, VehicleDetailRestClient vehicleDetailRestClient, VoucherRestClient voucherRestClient, VouchelrDetailRestClient voucherDetailRestClient, DriverRestClient driverRestClient, VehicleRateConfigurationRestClient rateConfigurationClient, CustomerRateConfigurationRestClient customerRateConfigurationClient)
        {
            this._customerRestClient = customerRestClient;
            this._vehicleRestClient = vehicleRestClient;
            this._itemRestClient = itemRestClient;
            this._vehicleDetailRestClient = vehicleDetailRestClient;
            this._voucherRestClient = voucherRestClient;
            this._voucherDetailRestClient = voucherDetailRestClient;
            this._driverRestClient = driverRestClient;
            this._detailTable = new DataTable();
            this._detailGridFormatter = new VoucherDetailGridFormatter();
            this._detailGridFormatter.AddColumns(this._detailTable);
            this._rateConfigurationClient = rateConfigurationClient;
            this._customerRateConfigurationClient = customerRateConfigurationClient;
        }

        public override void Close()
        {
            this._view.CloseUI();
        }

        public override void SaveAndClose()
        {
            this.saveVoucher();
            this.Close();
        }

        public void LoadCustomer()
        {
            List<CustomerDto> customers = this._customerRestClient.GetAll();
            this._view.SetCustomerSource(customers);
        }

        public void LoadVehicle()
        {
            List<VehicleDto> vehicles = this._vehicleRestClient.GetAll();
            this._view.SetVehicleSource(vehicles);
        }

        public void LoadVehicleDetail()
        {
            VehicleDto selectedVehicle = this._view.GetSelectedVehicle();

            if (selectedVehicle == null) return;

            List<VehicleDetailDto> vehicleDetail = this._vehicleDetailRestClient.GetAll(selectedVehicle.Id);
            
            this._view.SetVehicleRegistrationSource(vehicleDetail);
        }

        public void LoadItem()
        {
            List<ItemMasterDto> items = this._itemRestClient.GetAll();
            this._view.SetItemSource(items);
        }

        public void LoadItem(int customerID, int vehicleID) {

            List<ItemMasterDto> items = new List<ItemMasterDto>();
            var temp = this._customerRateConfigurationClient.GetAll(customerID, vehicleID);
            foreach (var item in temp) {
                items.Add(new ItemMasterDto()
                {
                    Id = item.Id,
                    ItemName= item.ItemName,
                    Quantity = item.Quantity,
                    Rate = item.Rate,
                    Unit = item.Unit,
                });
            }
            this._view.SetItemSource(items);
        }

        public void LoadLocation()
        {
            List<string> locations = new List<string>();
            this._view.SetPickupLocation(locations);
            this._view.SetDropLocation(locations);

        }

        private VoucherMasterDto saveVoucher()
        {
            VoucherMasterDto voucherMaster = this._view.GetDto() as VoucherMasterDto;

            VoucherMasterDto master = this._view.GetMode() == ActionMode.New ? this._voucherRestClient.Add(voucherMaster) : this._voucherRestClient.Update(voucherMaster);

            List<VoucherDetailDto> detailDto = this._view.GetDetails();

            foreach (VoucherDetailDto detail in detailDto)
            {
                if (detail.Action == ActionMode.New)
                {
                    VoucherDetailDto dto = this._voucherDetailRestClient.Add(master.Id, detail);
                }
                else if (detail.Action == ActionMode.Edit)
                {
                    VoucherDetailDto dto = this._voucherDetailRestClient.Update(detail);
                }
                else if (detail.Action == ActionMode.Delete)
                {
                    VoucherDetailDto dto = this._voucherDetailRestClient.Delete(detail.Id);
                }
            }

            return voucherMaster;
        }

        public override void SaveAndNew()
        {
            try
            {
                this.saveVoucher();
                this._view.ShowMessage();
                this._view.ClearUI();
                this._detailTable.Rows.Clear();
            }
            catch (ValidationException vex)
            {
                this._view.ShowError(vex.Errors);
            }
        }

        protected override object BuidDtoForEdit(int id)
        {
            return this._voucherRestClient.Get(id);
        }

        protected override object BuildDto()
        {
            return new VoucherMasterDto();
        }

        internal void SetView(IVoucherView voucherView)
        {
            this._view = voucherView;
            this._view.SetDetailGridFormatter(this._detailGridFormatter);
            base.SetView(voucherView);
        }

        internal void LoadDriver()
        {
            List<DriverDto> drivers = this._driverRestClient.GetAll();
            this._view.SetDriverSource(drivers);
        }

        internal void SetVoucherDetail()
        {
            int voucherId = this._view.GetVoucherId();

            this._detailGridFormatter.BuildTable(new VoucherDetailLoader(this._voucherDetailRestClient, voucherId), this._detailTable);

            this._view.SetDetailSource(this._detailTable, this._detailGridFormatter);
        }

        internal void SetCustomerVehicleDetail() 
        {

            CustomerDto selectedCustomer = this._view.GetSelectedCustomer();
            VehicleDto selectedVehicle = this._view.GetSelectedVehicle();
            int totalDays = this._view.GetTotalDays();

            if (selectedCustomer == null || selectedVehicle == null || this._view.GetMode() != ActionMode.New) return;

            this._detailGridFormatter.BuildTable(new DefaultVoucherDetailLoader(this._voucherDetailRestClient, selectedCustomer.Id, selectedVehicle.Id, totalDays), this._detailTable);

            this._view.SetDetailSource(this._detailTable, this._detailGridFormatter);
        }

        internal void AddDetail(VoucherDetailDto voucherDetail)
        {
            DataRow row = this._detailTable.NewRow();
            this._detailGridFormatter.AddRow(voucherDetail, row);
            this._detailTable.Rows.Add(row);
            this._view.ClearDetailView();
        }

        //internal void LoadVoucherDetail()
        //{
        //    int voucherId = this._view.GetVoucherId();
        //    this._detailGridFormatter.BuildTable(new VoucherDetailLoader(this._voucherDetailRestClient, voucherId), this._detailTable);
        //    this._view.SetDetailSource(this._detailTable, this._detailGridFormatter);
        //}

        internal void ShowRateConfiguration(int itemId)
        {
            if (itemId == 0) return;

            CustomerDto selectedCustomer = this._view.GetSelectedCustomer();
            VehicleDto selectedVehicle = this._view.GetSelectedVehicle();

            int customerId = selectedCustomer == null ? 0 : selectedCustomer.Id;
            int vehicleId = selectedVehicle == null ? 0 : selectedVehicle.Id;

            RateInfoDto rateInfo = this._customerRateConfigurationClient.GetRateInformation(itemId, customerId, vehicleId);
            this._view.ShowItemInfo(rateInfo);
        }

        internal void SetVoucherNo()
        {
            ActionMode mode = this._view.GetMode();
            if (mode.Equals(ActionMode.New))
            {
                string voucherNo = this._voucherRestClient.GetVoucherNo();
                this._view.SetVoucherNo(voucherNo);
            }
        }

        internal void OpenItemForEdit()
        {
            DataRow row = this._view.SelectedDetailItem();
            VoucherDetailDto detailDto = this._detailGridFormatter.GetObject(row);
            this._view.SetDetailDto(detailDto);
        }

        internal void UpdateDetail(VoucherDetailDto voucherDetail)
        {
            DataRow row = this._view.SelectedDetailItem();
            this._detailGridFormatter.AddRow(voucherDetail, row);
            this._view.ClearDetailView();
        }

        internal bool DeleteDetail()
        {
            DataRow selectedRow = this._view.SelectedDetailItem();
            VoucherDetailDto detailDto = this._detailGridFormatter.GetObject(selectedRow);

            VoucherDetailDto dto =  this._voucherDetailRestClient.Delete(detailDto.Id);
            return detailDto.Id == dto.Id;
        }
    }
}
