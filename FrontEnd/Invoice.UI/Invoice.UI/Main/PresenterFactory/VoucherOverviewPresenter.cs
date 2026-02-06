using Invoice.UI.CustomControl.EventArguments;
using Invoice.UI.Driver;
using Invoice.UI.DTO;
using Invoice.UI.Item;
using Invoice.UI.Rental;
using Invoice.UI.Vehicle;
using Invoice.UI.Vehicle.RateConfiguration;
using Invoice.UI.Vehicle.VehicleDetail;
using System;
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
        private readonly IRowAdder<VoucherMasterDto> _rowAdder;
        private readonly VehicleRateConfigurationRestClient _rateConfigurationClient;
        private readonly CustomerRateConfigurationRestClient _customerRateConfigurationClient;

        public VoucherOverviewPresenter(CustomerRestClient customerRestClient, VehicleRestClient vehicleRestClient, ItemRestClient itemRestClient, VehicleDetailRestClient vehicleDetailRestClient, VoucherRestClient voucherRestClient, VouchelrDetailRestClient voucherDetailRestClient, DriverRestClient driverRestClient, VehicleRateConfigurationRestClient vehicleRateConfigurationRestClient, CustomerRateConfigurationRestClient customerConfigurationRestClient)
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
            _rowAdder = _gridFormatter as IRowAdder<VoucherMasterDto>;
        }

        public DataTable BuildTable()
        {
            this._table.Clear();

            this._table.Columns.Clear();

            this._gridFormatter.AddColumns(this._table);

            this._gridFormatter.BuildTable(new VoucherLoader(this._voucherRestClient), this._table);

            return _table;
        }

        public DataTable BuildTable(List<SearchCriteriaEventArgs> criteria)
        {
            this._table.Clear();

            if (this._table.Columns.Count == 0)
                this._gridFormatter.AddColumns(this._table);

            this._gridFormatter.BuildTable(new VoucherLoaderBySearchCriteria(this._voucherRestClient, criteria), this._table);

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

        public bool DeleteRecord(DataRow selectedRow)
        {
            VoucherMasterDto vehicleDto = this._rowAdder.GetObject(selectedRow);
            //TODO Remove try catch
            try {
                this._voucherRestClient.Delete(vehicleDto);
            }
            catch (Exception ex) { var c = ex.StackTrace; }

            return true;
        }
    }
}
