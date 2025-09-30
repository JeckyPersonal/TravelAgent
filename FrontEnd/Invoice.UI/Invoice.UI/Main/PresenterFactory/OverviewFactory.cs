using Invoice.UI.Bank;
using Invoice.UI.Company;
using Invoice.UI.Driver;
using Invoice.UI.Item;
using Invoice.UI.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.Main.PresenterFactory
{
    internal class OverviewFactory
    {
        public IOverviewPresenter GetOverviewPresenter(Menu menu)
        {
            switch (menu)
            {
                case Menu.Company:
                    return new CompanyOverviewPresenter(CompanyRestClient.Instance);
                case Menu.Bank:
                    return new BankOverviewPresenter(BankRestClient.Instance);
                case Menu.Customer:
                    return new CustomerOverviewPresenter(CustomerRestClient.Instance);
                case Menu.Item:
                    return new ItemOverviewPresenter(ItemRestClient.Instance);
                case Menu.Driver:
                    return new DriverOverviewPresenter(DriverRestClient.Instance);
                case Menu.Vehicle:
                    return new VehicleOverviewPresenter(VehicleRestClient.Instance);
                default:
                    throw new NotImplementedException("Overview presenter is not implemented. Please contact to Administrator."); ;
            }
        }
    }
}
