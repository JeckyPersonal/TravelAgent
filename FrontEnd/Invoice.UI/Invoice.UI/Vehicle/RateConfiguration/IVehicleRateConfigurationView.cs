using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Vehicle.RateConfiguration
{
    internal interface IVehicleRateConfigurationView : IBaseView
    {
        DataRow GetSelectedRate();
        int GetVehicleId();
        void SetItemInfo(ItemMasterDto itemDto);
        void SetItemSource(List<string> names);
        void ShowRates(DataTable table);
    }
}
