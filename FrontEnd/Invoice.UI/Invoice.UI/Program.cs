using Invoice.UI.Company;
using Invoice.UI.CompanySelector;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
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

            //// 1️⃣ Build configuration
            //var builder = new ConfigurationBuilder() 
            //    .SetBasePath(AppContext.BaseDirectory) 
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) .Build(); 
            //// 2️⃣ Create service collection (DI container)
            //var services = new ServiceCollection(); 
            //// 3️⃣ Bind config section to strongly typed class
            //services.Configure<CurrentConfig>(builder.GetSection("CurrentConfig")); 
            //// 4️⃣ Register your main form
            //services.AddTransient<Form>();

            //// 5️⃣ Build the provider and run the app
            //using (ServiceProvider serviceProvider = services.BuildServiceProvider()) 
            //{

            //    CompanySelectorPresenter presenter = new CompanySelectorPresenter(CompanyRestClient.Instance, FinancialYear.FinancialYearRestClient.Instance);
            //    presenter.SetView(new CompanySelector.CompanySelector());
            //    presenter.ShowUI();

            //    if (presenter.GetView().DialogResult == DialogResult.OK)
            //    {
            //        var form = serviceProvider.GetRequiredService<Form>();
            //        ApplicationConfiguration.Initialize();
            //        Application.Run(presenter.GetNextView());

            //        Application.Run(presenter.GetNextView());
            //    }
            //}

            ///*consumer who want to use setings

            //private readonly CurrentConfig _config;

            //public Form1(IOptions<CurrentConfig> options)
            //{
            //    InitializeComponent();
            //    _config = options.Value;
            //}
            //*/

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
