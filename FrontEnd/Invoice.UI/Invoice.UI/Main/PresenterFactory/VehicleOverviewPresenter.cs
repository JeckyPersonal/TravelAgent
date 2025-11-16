using Invoice.UI.DTO;
using Invoice.UI.Vehicle;
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

        public VehicleOverviewPresenter(VehicleRestClient restClient)
        {
            this._restClient = restClient;
            this._table = new DataTable();
        }

        public DataTable BuildTable()
        {
            this._table.Columns.Clear();

            List<VehicleDto> vehicles = this._restClient.GetAll();

            this._table.Clear();

            this._table.Columns.Add(VehicleTableFormatter.COLUMN_NAME_ID);
            this._table.Columns.Add(VehicleTableFormatter.COLUMN_NAME_TYPE);

            foreach (VehicleDto vehicle in vehicles)
            {
                DataRow row = this._table.NewRow();

                row[VehicleTableFormatter.COLUMN_NAME_ID] = vehicle.Id;
                row[VehicleTableFormatter.COLUMN_NAME_TYPE] = vehicle.VehicleType;

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

        public IDataGridFormatter GetDataGridFormatter()
        {
            return VehicleTableFormatter.Instance;
        }

        public Menu GetMenu()
        {
            return Menu.Vehicle;
        }
    }
}
