using Invoice.UI.Company;
using Invoice.UI.CompanySelector;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows.Forms;

namespace Invoice.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Build configuration
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // path to bin/debug
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            // Read values
            string apiUrl = config["CurrentConfig:ApiUrl"];
            Settings.BaseUrl = apiUrl;

            CompanySelectorPresenter presenter = new CompanySelectorPresenter(CompanyRestClient.Instance, FinancialYear.FinancialYearRestClient.Instance);
            presenter.SetView(new CompanySelector.CompanySelector());
            presenter.ShowUI();

            if (presenter.GetView().DialogResult == DialogResult.OK)
            {
                Application.Run(presenter.GetNextView());
            }

        }
    }
}
