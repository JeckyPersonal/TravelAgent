using Invoice.UI.Company;
using Invoice.UI.CompanySelector;
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

            CompanySelectorPresenter presenter = new CompanySelectorPresenter(CompanyRestClient.Instance, FinancialYear.FinancialYearRestClient.Instance);
            presenter.SetView(new CompanySelector.CompanySelector());
            presenter.ShowUI();

            if(presenter.GetView().DialogResult == DialogResult.OK)
            {
                Application.Run(presenter.GetNextView());
            }

        }
    }
}
