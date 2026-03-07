using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Customer.TenderConfiguration
{
    internal interface ITenderConfigurationView : IBaseView
    {
        int GetTenderId();
        void ShowRates(DataTable table, FuelDataGridFormatter formatter);
        void ClearDetailView();
        void SetDetailDto(object dto);
        DataRow GetSelectedFuelRate();
        int GetCustomerId();
    }
}
