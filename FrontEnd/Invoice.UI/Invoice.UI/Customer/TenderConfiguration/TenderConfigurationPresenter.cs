using Invoice.UI.Customer.RateConfiguration;
using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Customer.TenderConfiguration
{
    internal class TenderConfigurationPresenter : BaseDetailPresenter
    {
        private readonly TenderConfigurationRestClient _tenderRestClient;
        private readonly TenderFuelConfigurationRestClient _tenderFuelRestClient;
        private readonly FuelDataGridFormatter _fuelDataGridFormatter;
        private readonly DataTable _fuelRatetable;
        private ITenderConfigurationView _view;

        public TenderConfigurationPresenter(TenderConfigurationRestClient tenderRestClient, TenderFuelConfigurationRestClient tenderFuelRestClient, FuelDataGridFormatter fuelDataGridFormatter)
        {
            _tenderRestClient = tenderRestClient;
            _tenderFuelRestClient = tenderFuelRestClient;
            _fuelDataGridFormatter = fuelDataGridFormatter;
            _fuelRatetable = new DataTable();
            _fuelDataGridFormatter.AddColumns(this._fuelRatetable);
        }

        public void SetView(ITenderConfigurationView view)
        {
            this._view = view;
            base.SetView(view);
        }

        public void LoadFuelRates()
        {
            int tenderId = this._view.GetTenderId();

            if (tenderId == 0)
            {
                this._fuelRatetable.Rows.Clear();

                this._fuelDataGridFormatter.AddColumns(this._fuelRatetable);

                this._view.ShowRates(this._fuelRatetable, this._fuelDataGridFormatter);

                return;
            }

            List<TenderFuelRateDto> fuelRates = this._tenderFuelRestClient.GetByTenderID(tenderId);

            this._fuelRatetable.Rows.Clear();

            foreach (var fuelRate in fuelRates)
            {
                DataRow row = this._fuelRatetable.NewRow();

                fuelRate.Action = ActionMode.None;

                this._fuelDataGridFormatter.AddRow(fuelRate, row);

                this._fuelRatetable.Rows.Add(row);
            }

            this._view.ShowRates(this._fuelRatetable, this._fuelDataGridFormatter);
        }

        public void EditFuelRate()
        {
            DataRow editingRow= this._view.GetSelectedFuelRate();
            TenderFuelRateDto editableFuelRate = this._fuelDataGridFormatter.GetObject(editingRow);
            editableFuelRate.Action = ActionMode.Edit;
            this._view.SetDetailDto(editableFuelRate);
        }

        public override void Close()
        {
            this._view.CloseUI();
        }

        public override bool DeleteRecord(DataRow id)
        {
            throw new NotImplementedException();
        }

        public override void SaveAndClose()
        {
            throw new NotImplementedException();
        }

        public void AddDetail(TenderFuelRateDto tenderFuelRateDto) 
        {
            DataRow row = this._fuelRatetable.NewRow();
            this._fuelDataGridFormatter.AddRow(tenderFuelRateDto, row);
            this._fuelRatetable.Rows.Add(row);
        }

        public override void SaveAndNew()
        {
            TenderDto tenderDto = saveTender();

            if (this._view.ShowMessage().Equals(DialogResult.OK)) 
            {
                this._view.SetDto(tenderDto);
                return;
            }
            this._view.ClearUI();
        }

        public bool DeleteFuelRate() 
        {
            DataRow selectedRow = this._view.GetSelectedFuelRate();
            TenderFuelRateDto detailDto = this._fuelDataGridFormatter.GetObject(selectedRow);
            if (detailDto.Id != 0)
            {
                TenderFuelRateDto dto = this._tenderFuelRestClient.Delete(detailDto.Id);
                return detailDto.Id == dto.Id;
            }
            return true;
        }

        private TenderDto saveTender()
        {
            TenderDto tenderDto = this._view.GetDto() as TenderDto;

            if (this._view.GetMode() == ActionMode.New)
            {
                return this._tenderRestClient.Add(tenderDto);
            }
            else
            {
                return this._tenderRestClient.Update(tenderDto);
            }
        }

        public void saveDetail(TenderFuelRateDto singleRate)
        {
            if (singleRate.Action.Equals(ActionMode.New))
            {
                if (singleRate.TenderID == 0)
                {
                    TenderDto tenderDto = saveTender();
                    singleRate.TenderID = tenderDto.Id;
                    this._tenderFuelRestClient.Add(singleRate);
                    this._view.SetDto(tenderDto);
                }
                else {
                    this._tenderFuelRestClient.Add(singleRate);
                }
            }
            else if (singleRate.Action.Equals(ActionMode.Edit))
            {
                this._tenderFuelRestClient.Update(singleRate);
            }

        }

        protected override object BuidDtoForEdit(int id)
        {
            throw new NotImplementedException();
        }

        protected override object BuildDto()
        {
            return this._tenderRestClient.GetByCustomerID(this._view.GetCustomerId());
        }
    }
}
