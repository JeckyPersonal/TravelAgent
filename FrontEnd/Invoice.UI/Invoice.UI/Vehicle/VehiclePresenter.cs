using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;

namespace Invoice.UI.Vehicle
{
    internal class VehiclePresenter : BasePresenter
    {
        private readonly VehicleRestClient _restClient;
        private IVehicleView _vehicleView;

        public VehiclePresenter(VehicleRestClient restClient)
        {
            this._restClient = restClient;
        }

        public override void Close()
        {
            this._vehicleView.CloseUI();
        }

        public override void SaveAndClose()
        {
            this.saveVehicle();
            this.Close();
        }

        private void saveVehicle()
        {
            VehicleDto vehicleDto = this._vehicleView.GetDto() as VehicleDto;

            if (this._vehicleView.GetMode() == ActionMode.New)
            {
                this._restClient.Add(vehicleDto);
            }
            else
            {
                this._restClient.Update(vehicleDto);
            }
        }

        public override void SaveAndNew()
        {
            try
            {
                this.saveVehicle();
                this._vehicleView.ClearUI();
            }
            catch (ValidationException vex)
            {
                this._vehicleView.ShowError(vex.Errors);
            }
        }

        protected override object BuidDtoForEdit(int id)
        {
            return this._restClient.Get(id);
        }

        protected override object BuildDto()
        {
            return new VehicleDto();
        }

        public void SetView(IVehicleView view)
        {
            this._vehicleView = view;
            base.SetView(view);
        }
    }
}
