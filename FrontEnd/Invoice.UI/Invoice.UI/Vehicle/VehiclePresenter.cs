using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using System.Windows.Forms;

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

        private VehicleDto saveVehicle()
        {
            VehicleDto vehicleDto = this._vehicleView.GetDto() as VehicleDto;

            if (this._vehicleView.GetMode() == ActionMode.New)
            {
               return this._restClient.Add(vehicleDto);
            }
            else
            {
                return this._restClient.Update(vehicleDto);
            }
        }

        public override void SaveAndNew()
        {
            try
            {
                VehicleDto savedVehicle = this.saveVehicle();
                if (this._vehicleView.ShowMessage().Equals(DialogResult.Yes))
                {
                    this._vehicleView.SetDto(savedVehicle);
                }
                else
                {
                    this._vehicleView.ClearUI();
                }
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
