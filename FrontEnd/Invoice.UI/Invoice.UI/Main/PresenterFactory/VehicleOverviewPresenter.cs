using Invoice.UI.DTO;
using Invoice.UI.Vehicle;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Main.PresenterFactory
{
    internal class VehicleOverviewPresenter : IOverviewPresenter
    {
        private readonly DataTable _table;
        private readonly VehicleRestClient _restClient;
        private readonly IDataGridFormatter _gridFormatter;
        private readonly IRowAdder<VehicleDto> _rowAdder;

        public VehicleOverviewPresenter(VehicleRestClient restClient)
        {
            this._restClient = restClient;
            this._table = new DataTable();
            this._gridFormatter = VehicleTableFormatter.Instance;
            this._rowAdder = this._gridFormatter as IRowAdder<VehicleDto>;
        }

        public DataTable BuildTable()
        {
            List<VehicleDto> vehicles = this._restClient.GetAll();

            this._table.Clear();

            this._rowAdder.AddColumns(this._table);

            foreach (VehicleDto vehicle in vehicles)
            {
                DataRow row = this._table.NewRow();

                this._rowAdder.AddRow(vehicle, row);

                this._table.Rows.Add(row);
            }

            return this._table;
        }

        public BasePresenter CreatePresenter()
        {
            VehiclePresenter presenter = new VehiclePresenter(this._restClient);
            frmVehicle vehicle = new frmVehicle(presenter);

            return presenter;
        }

        public bool DeleteRecord(DataRow selectedRow)
        {
            VehicleDto vehicleDto = this._rowAdder.GetObject(selectedRow);

            this._restClient.Delete(vehicleDto);

            return true;
        }

        public IDataGridFormatter GetDataGridFormatter()
        {
            return this._gridFormatter;
        }

        public Menu GetMenu()
        {
            return Menu.Vehicle;
        }
    }
}
