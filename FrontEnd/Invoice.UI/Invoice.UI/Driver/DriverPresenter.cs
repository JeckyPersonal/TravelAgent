using Invoice.UI.DTO;
using Invoice.UI.Exceptions;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Invoice.UI.Driver
{
    public class DriverPresenter : BasePresenter
    {
        private IDriverView _view;
        private readonly DriverRestClient _restClient;

        public DriverPresenter(DriverRestClient restClient)
        {
            this._restClient = restClient;
        }

        public override void Close()
        {
            this._view.CloseUI();
        }

        public override void SaveAndClose()
        {
            try
            {
                this.saveDriver();
                this._view.CloseUI();
            }
            catch (ValidationException vex)
            {
                this._view.ShowError(vex.Errors);
            }
        }

        private void saveDriver()
        {
            DriverDto driverDto = this._view.GetDto() as DriverDto;
            DriverDto savedDto = new DriverDto();
            if (this._view.GetMode() == ActionMode.New)
            {
                savedDto = this._restClient.Add(driverDto);
            }
            else
            {
                savedDto = this._restClient.Update(driverDto);
            }
        }

        public override void SaveAndNew()
        {
            this.saveDriver();
            this._view.ClearUI();
        }

        protected override object BuidDtoForEdit(int id)
        {
            return this._restClient.Get(id);
        }

        protected override object BuildDto()
        {
            return new DriverDto();
        }

        public void SetView(IDriverView view)
        {
            this._view = view;
            base.SetView(view);
        }
    }
}
