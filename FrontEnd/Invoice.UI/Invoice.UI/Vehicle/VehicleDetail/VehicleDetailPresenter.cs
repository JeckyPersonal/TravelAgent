using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;

namespace Invoice.UI.Vehicle.VehicleDetail
{
    internal class VehicleDetailPresenter : BasePresenter
    {
        private IVehicleDetailView _view;
        private readonly VehicleDetailRestClient _restClient;
        private readonly DataTable _detailTable;

        public VehicleDetailPresenter(VehicleDetailRestClient restClient)
        {
            this._restClient = restClient;
            this._detailTable = new DataTable();
            this._detailTable.Columns.Add("Id");
            this._detailTable.Columns.Add("Registration Number");
        }

        public override void Close()
        {
            this._view.CloseUI();
        }

        public override void SaveAndClose()
        {
            this.saveVehicleDetail();
            this.Close();
        }

        public void LoadDetails(int vehicleId)
        {
            this._detailTable.Clear();


            List<VehicleDetailDto> details = this._restClient.GetAll(vehicleId);

            foreach (VehicleDetailDto detail in details) { 
                DataRow row = this._detailTable.NewRow();

                row["Id"] = detail.Id;
                row["Registration Number"] = detail.RegistrationNumber;

                this._detailTable.Rows.Add(row);
            }

            this._view.SetDataSource(this._detailTable);
        }

        private VehicleDetailDto saveVehicleDetail()
        {
            VehicleDetailDto dto = this._view.GetDto() as VehicleDetailDto;
            if (this._view.GetMode() == ActionMode.New)
            {
                int vehicleId = this._view.GetVehicleId();
                return this._restClient.Add(vehicleId, dto);
            }
            else
            {
                return this._restClient.Update(dto);
            }
        }

        public override void SaveAndNew()
        {
            try
            {
                this.saveVehicleDetail();
                this._view.ClearUI();
            }
            catch (ValidationException vex)
            {
                this._view.ShowError(vex.Errors);
            }
        }

        protected override object BuidDtoForEdit(int id)
        {
            return this._restClient.Get(id);
        }

        protected override object BuildDto()
        {
            return new VehicleDetailDto();
        }

        internal void SetView(IVehicleDetailView frmVehicleDetail)
        {
            this._view = frmVehicleDetail;
            base.SetView(frmVehicleDetail);
        }

        internal void EditRegistrationDetail()
        {
            DataRow row = this._view.GetSelectedRegistration();
            VehicleDetailDto dto = new VehicleDetailDto()
            {
                Id = Convert.ToInt32(row["Id"]),
                RegistrationNumber = Convert.ToString(row["Registration Number"])
            };

            this._view.SetDto(dto);
        }
    }
}