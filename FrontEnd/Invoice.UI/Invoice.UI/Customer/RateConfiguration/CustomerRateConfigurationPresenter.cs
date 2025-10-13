using Invoice.UI.DTO;
using Invoice.UI.Item;
using Invoice.UI.Vehicle;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Invoice.UI.Customer.RateConfiguration
{
    internal class CustomerRateConfigurationPresenter : BasePresenter
    {
        private readonly ItemRestClient _itemRestClient;
        private readonly CustomerRateConfigurationRestClient _rateConfigurationRestClient;
        private readonly VehicleRestClient _vehicleRestClient;
        private readonly VehicleRateConfigDataGridFormatter _rateGridFomatter;
        private ICutomerRateConfigurationView _view;
        private readonly DataTable _table;
        private readonly DataTable _customertable;

        public CustomerRateConfigurationPresenter(ItemRestClient itemRestClient, CustomerRateConfigurationRestClient rateConfigurationRestClient, VehicleRestClient vehicleRestClient, VehicleRateConfigDataGridFormatter rateGridFomatter)
        {
            this._itemRestClient = itemRestClient;
            this._rateConfigurationRestClient = rateConfigurationRestClient;
            this._vehicleRestClient = vehicleRestClient;
            this._rateGridFomatter = rateGridFomatter;
            this._table = new DataTable();
            this._rateGridFomatter.AddColumns(this._table);

            this._customertable = new DataTable();
            this.addRateColumns();
        }

        public override void Close()
        {
            this._view.CloseUI();
        }

        public override void SaveAndClose()
        {
            this.saveRateConfiguration();
            this._view.CloseUI();
        }

        private void saveRateConfiguration()
        {
            ActionMode mode = this._view.GetMode();
            CustomerRateDto dto = this._view.GetDto() as CustomerRateDto;
            if (mode == ActionMode.New)
            {
                this._rateConfigurationRestClient.Add(dto);
            }
            else
            {
                this._rateConfigurationRestClient.Update(dto.Id, dto);
            }
        }

        public override void SaveAndNew()
        {
            this.saveRateConfiguration();
            this._view.ClearUI();
        }

        public void SetView(ICutomerRateConfigurationView view)
        {
            this._view = view;
            base.SetView(view);
        }

        protected override object BuidDtoForEdit(int id)
        {
            throw new System.NotImplementedException();
        }

        protected override object BuildDto()
        {
            return new CustomerRateDto();
        }

        internal void SetItemSource()
        {
            List<ItemMasterDto> items = this._itemRestClient.GetAll();

            List<string> names = items.Select(x => $"{x.ItemName} ({x.Id})").ToList();

            this._view.SetItemSource(names);
        }

        internal void ShowItemInfo(int id)
        {

            int vehicleId = this._view.GetVehicleId();

            VehicleRateDto vehicleRate = VehicleRateConfigurationRestClient.Instance.Get(id, vehicleId);

            if (vehicleRate.Id == 0)
            {
                ItemMasterDto itemById = this._itemRestClient.Get(id);
                this._view.SetItemInfo(itemById);
            }
            else
            {
                this._view.ShowVehicleRate(vehicleRate);
            }
        }

        internal void EditRate()
        {
            DataRow row = this._view.GetSelectedRate();

            if (row == null) return;

            VehicleRateDto dto = this._rateGridFomatter.GetObject(row);

            this._view.SetDto(dto);
        }

        public void LoadRates()
        {
            int vehicleId = this._view.GetVehicleId();
            int customerId = this._view.GetCustomerId();

            List<CustomerRateDto> rates = this._rateConfigurationRestClient.GetAll(vehicleId, customerId);

            this._table.Rows.Clear();

            foreach (var rate in rates)
            {
                DataRow row = this._table.NewRow();

                this._rateGridFomatter.AddRow(rate, row);

                this._table.Rows.Add(row);
            }

            this._view.ShowRates(this._table, this._rateGridFomatter);
        }

        private void addRateColumns()
        {
            this._customertable.Columns.Add(VehicleTableFormatter.COLUMN_NAME_ID);
            this._customertable.Columns.Add(VehicleTableFormatter.COLUMN_NAME_TYPE);
        }

        internal void LoadVehicle()
        {
            List<VehicleDto> vehicles = this._vehicleRestClient.GetAll();

            this._customertable.Rows.Clear();

            foreach (var vehicle in vehicles)
            {
                DataRow row = this._customertable.NewRow();

                row[VehicleTableFormatter.COLUMN_NAME_ID] = vehicle.Id;
                row[VehicleTableFormatter.COLUMN_NAME_TYPE] = vehicle.VehicleType;

                this._customertable.Rows.Add(row);
            }


            this._view.SetVehicles(this._customertable);
        }
    }
}