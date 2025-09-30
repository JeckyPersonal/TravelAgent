using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Vehicle.VehicleDetail
{
    internal interface IVehicleDetailView : IBaseView
    {
        DataRow GetSelectedRegistration();
        int GetVehicleId();
        void SetDataSource(DataTable detailTable);
    }
}
