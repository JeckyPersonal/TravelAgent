using Invoice.UI.Driver;
using Invoice.UI.DTO;
using Invoice.UI.Item;
using Invoice.UI.Rental;
using Invoice.UI.Vehicle;
using Invoice.UI.Vehicle.RateConfiguration;
using Invoice.UI.Vehicle.VehicleDetail;
using System.Collections.Generic;
using System.Data;

namespace Invoice.UI.Main.PresenterFactory
{
    internal class VoucherOverviewPresenter : IOverviewPresenter
    {
        private DataTable _table;
        private readonly CustomerRestClient _customerRestClient;
        private readonly VehicleRestClient _vehicleRestClient;
        private readonly ItemRestClient _itemRestClient;
        private readonly VehicleDetailRestClient _vehicleDetailRestClient;
        private readonly VoucherRestClient _voucherRestClient;
        private readonly VouchelrDetailRestClient _voucherDetailRestClient;
        private readonly DriverRestClient _driverRestClient;
        private readonly VoucherDataGridFormatter _gridFormatter;
        private readonly VehicleRateConfigurationRestClient _rateConfigurationClient;
        private readonly CustomerRateConfigurationRestClient _customerRateConfigurationClient;

        public VoucherOverviewPresenter(CustomerRestClient customerRestClient, VehicleRestClient vehicleRestClient, ItemRestClient itemRestClient, VehicleDetailRestClient vehicleDetailRestClient, VoucherRestClient voucherRestClient, VouchelrDetailRestClient voucherDetailRestClient, DriverRestClient driverRestClient,VehicleRateConfigurationRestClient vehicleRateConfigurationRestClient, CustomerRateConfigurationRestClient customerConfigurationRestClient)
        {
            _table = new DataTable();
            _customerRestClient = customerRestClient;
            _vehicleRestClient = vehicleRestClient;
            _itemRestClient = itemRestClient;
            _vehicleDetailRestClient = vehicleDetailRestClient;
            _voucherRestClient = voucherRestClient;
            _voucherDetailRestClient = voucherDetailRestClient;
            _driverRestClient = driverRestClient;
            _rateConfigurationClient = vehicleRateConfigurationRestClient;
            _customerRateConfigurationClient = customerConfigurationRestClient;
            _gridFormatter = new VoucherDataGridFormatter();
        }

        public DataTable BuildTable()
        {
            //List<VoucherMasterDto> vouchers = this._voucherRestClient.GetAll();

            this._gridFormatter.BuildTable(new VoucherLoader(this._voucherRestClient), this._table);

            return _table;
        }

        public BasePresenter CreatePresenter()
        {
            VoucherPresenter presenter = new VoucherPresenter(this._customerRestClient, this._vehicleRestClient, this._itemRestClient, this._vehicleDetailRestClient, this._voucherRestClient, this._voucherDetailRestClient, this._driverRestClient, this._rateConfigurationClient, this._customerRateConfigurationClient);
            frmRental voucherView = new frmRental(presenter);
            return presenter;
        }

        public IDataGridFormatter GetDataGridFormatter()
        {
            return this._gridFormatter;
        }

        public Menu GetMenu()
        {
            return Menu.Voucher;
        }
    }
}
