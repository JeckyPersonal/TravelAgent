using Invoice.UI.DTO;
using Invoice.UI.Item;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Invoice.UI.Vehicle.RateConfiguration
{
    internal class VehicleRateConfigurationPresenter : BaseDetailPresenter
    {
        private IVehicleRateConfigurationView _view;
        private readonly VehicleRateConfigurationRestClient _restClient;
        private readonly ItemRestClient _itemRestClient;
        private readonly DataTable _table;
        private readonly VehicleRateConfigDataGridFormatter _formatter;

        public VehicleRateConfigurationPresenter(VehicleRateConfigurationRestClient restClient, ItemRestClient itemRestClient, VehicleRateConfigDataGridFormatter gridFormatter)
        {
            this._restClient = restClient;
            this._table = new DataTable();
            this._formatter = gridFormatter;
            this._formatter.AddColumns(this._table);
            this._itemRestClient = itemRestClient;
        }

        public override void Close()
        {
            this._view.CloseUI();
        }

        public override void SaveAndClose()
        {
            this.saveRates();
            this._view.CloseUI();
        }

        private void saveRates()
        {
            ActionMode mode = this._view.GetMode();
            VehicleRateDto dto = this._view.GetDto() as VehicleRateDto;
            if (mode == ActionMode.New)
            {
                this._restClient.Add(dto);
            }
            else
            {
                this._restClient.Update(dto.Id, dto);
            }
        }

        public override void SaveAndNew()
        {
            this.saveRates();
            this._view.ShowMessage();
            this._view.ClearUI();
        }



        public void LoadRates()
        {
            int vehicleId = this._view.GetVehicleId();

            List<VehicleRateDto> rates = this._restClient.GetAll(vehicleId);

            this._table.Rows.Clear();

            foreach (var rate in rates)
            {
                DataRow row = this._table.NewRow();

                this._formatter.AddRow(rate, row);

                this._table.Rows.Add(row);
            }

            this._view.ShowRates(this._table, this._formatter);
        }

        protected override object BuidDtoForEdit(int id)
        {
            throw new System.NotImplementedException();
        }

        protected override object BuildDto()
        {
            return new VehicleRateDto();
            //throw new System.NotImplementedException();
        }

        public void SetView(IVehicleRateConfigurationView view)
        {
            this._view = view;
            base.SetView(view);
        }

        internal void SetItemSource()
        {
            List<ItemMasterDto> items = this._itemRestClient.GetAll();

            List<string> names = items.Select(x => $"{x.ItemName} ({x.Id})").ToList();

            this._view.SetItemSource(names);
        }

        internal void ShowItemInfo(int id)
        {
            ItemMasterDto itemDto = this._itemRestClient.Get(id);
            this._view.SetItemInfo(itemDto);
        }

        internal void EditRate()
        {
            DataRow row = this._view.GetSelectedRate();

            if (row == null) return;

            VehicleRateDto dto = this._formatter.GetObject(row);

            this._view.SetDto(dto);
        }

        public override bool DeleteRecord(DataRow id)
        {
            VehicleRateDto deletingRow= this._formatter.GetObject(id);

            this._restClient.Delete(deletingRow.Id);
            
            return true;
        }
    }
}