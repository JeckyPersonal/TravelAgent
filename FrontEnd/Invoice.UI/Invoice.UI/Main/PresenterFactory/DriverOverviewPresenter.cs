using Invoice.UI.Driver;
using Invoice.UI.DTO;
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

        public DriverOverviewPresenter(DriverRestClient restClient)
        {
            this._restClient = restClient;
            this._table = new DataTable();
        }

        public DataTable BuildTable()
        {
            List<DriverDto> drivers = this._restClient.GetAll();

            this._table.Columns.Clear();

            this._table.Clear();

            this._table.Columns.Add(DriverGridFormatter.COLUMN_NAME_ID);
            this._table.Columns.Add(DriverGridFormatter.COLUMN_NAME_NAME);
            this._table.Columns.Add(DriverGridFormatter.COLUMN_NAME_MOBILE_NO);
            this._table.Columns.Add(DriverGridFormatter.COLUMN_NAME_LICENSE_NO);

            foreach (DriverDto driver in drivers)
            {
                DataRow row = this._table.NewRow();

                row[DriverGridFormatter.COLUMN_NAME_ID] = driver.Id;
                row[DriverGridFormatter.COLUMN_NAME_NAME] = driver.DriverName;
                row[DriverGridFormatter.COLUMN_NAME_MOBILE_NO] = driver.DriverMobile;
                row[DriverGridFormatter.COLUMN_NAME_LICENSE_NO] = driver.LicenseNo;

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
