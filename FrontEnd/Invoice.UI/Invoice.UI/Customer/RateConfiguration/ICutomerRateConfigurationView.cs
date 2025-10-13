using Invoice.UI.DTO;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Customer.RateConfiguration
{
    internal interface ICutomerRateConfigurationView : IVehicleRateConfigurationView
    {
        int GetCustomerId();
        void SetVehicles(DataTable vehicles);
        void ShowVehicleRate(VehicleRateDto vehicleRate);
    }
}
