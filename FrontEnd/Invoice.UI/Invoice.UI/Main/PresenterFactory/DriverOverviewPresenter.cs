using Invoice.UI.Driver;
using Invoice.UI.DTO;
using Invoice.UI.Payment;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Main.PresenterFactory
{
    public class DriverOverviewPresenter : IOverviewPresenter
    {
        private readonly DriverRestClient _restClient;
        private readonly DataTable _table;
        private readonly IDataGridFormatter _formatter;
        private readonly IRowAdder<DriverDto> _rowAdder;

        public DriverOverviewPresenter(DriverRestClient restClient)
        {
            this._restClient = restClient;
            this._table = new DataTable();
            this._formatter = DriverGridFormatter.Instance;
            this._rowAdder = this._formatter as IRowAdder<DriverDto>;
        }

        public DataTable BuildTable()
        {
            List<DriverDto> drivers = this._restClient.GetAll();

            this._table.Columns.Clear();

            this._rowAdder.AddColumns(this._table);

            foreach (DriverDto driver in drivers)
            {
                DataRow row = this._table.NewRow();

                this._rowAdder.AddRow(driver, row);

                this._table.Rows.Add(row);
            }

            return _table;
        }

        public BasePresenter CreatePresenter()
        {
            DriverPresenter presenter = new DriverPresenter(this._restClient);
            frmDriver driver = new frmDriver(presenter);
            return presenter;
        }

        public bool DeleteRecord(DataRow selectedRow)
        {
            DriverDto paymentDto = this._rowAdder.GetObject(selectedRow);

            this._restClient.Delete(paymentDto);

            return true;
        }

        public IDataGridFormatter GetDataGridFormatter()
        {
            return DriverGridFormatter.Instance;
        }

        public Menu GetMenu()
        {
            return Menu.Driver;
        }
    }
}
