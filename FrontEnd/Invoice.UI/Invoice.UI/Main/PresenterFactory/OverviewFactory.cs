using Invoice.UI.Bank;
using Invoice.UI.Bank.BankDetail;
using Invoice.UI.Company;
using Invoice.UI.Driver;
using Invoice.UI.InvoiceModule;
using Invoice.UI.Item;
using Invoice.UI.Rental;
using Invoice.UI.Vehicle;
using Invoice.UI.Vehicle.RateConfiguration;
using System;

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
                case Menu.FinancialYear:
                    return new FinancialYearOverViewPresenter(FinancialYear.FinancialYearRestClient.Instance);
                case Menu.Voucher:
                    return new VoucherOverviewPresenter(CustomerRestClient.Instance, VehicleRestClient.Instance, ItemRestClient.Instance, Vehicle.VehicleDetail.VehicleDetailRestClient.Instance, Rental.VoucherRestClient.Instance, Rental.VouchelrDetailRestClient.Instance, DriverRestClient.Instance, VehicleRateConfigurationRestClient.Instance, CustomerRateConfigurationRestClient.CustomerInstance);
                case Menu.Invoice:
                    return new InvoiceOverviewPresenter(InvoiceModule.InvoiceRestClient.Instance, InvoiceModule.InvoiceDetailRestClient.Instance, VoucherRestClient.Instance, CustomerRestClient.Instance, BankRestClient.Instance, BankDetailRestClient.Instance, InvoiceDataGridFormatter.Instance);
                default:
                    throw new NotImplementedException("Overview presenter is not implemented. Please contact to Administrator."); ;
            }
        }
    }
}
