using Invoice.UI.Company;
using Invoice.UI.CustomControl;
using Invoice.UI.Main.PresenterFactory;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Invoice.UI.Main
{
    public partial class frmMain : Form, IMainView
    {
        private Dictionary<Menu, MainData> _openedMenu;
        private MainData _currentMenu;
        private MainWindowPresenter _presenter;

        public frmMain()
        {
            InitializeComponent();
            this._openedMenu = new Dictionary<Menu, MainData>();
            this._presenter = new MainWindowPresenter(this);
            btnVehicle.Image = System.Drawing.Image.FromFile(@"Images\car.png");//ImageColor: #3B2B1F
            btnDriver.Image = System.Drawing.Image.FromFile(@"Images\driver.png");
            btnFinancialYear.Image = System.Drawing.Image.FromFile(@"Images\calendar.png");
            btnBank.Image = System.Drawing.Image.FromFile(@"Images\bank.png");
            btnInvoice.Image = System.Drawing.Image.FromFile(@"Images\invoice.png");
            btnItem.Image = System.Drawing.Image.FromFile(@"Images\item.png");
            btnRantal.Image = System.Drawing.Image.FromFile(@"Images\voucher.png");
            btnCompany.Image = System.Drawing.Image.FromFile(@"Images\company.png");
            btnCustomer.Image = System.Drawing.Image.FromFile(@"Images\customer.png");
            btnPayment.Image = System.Drawing.Image.FromFile(@"Images\payment.png");
        }

        public void LoadView(Menu menu, IOverviewPresenter overviewPresenter, IDataGridFormatter formatter)
        {
            MainData dataToLoad = null;
            if (!this._openedMenu.TryGetValue(menu, out dataToLoad))
            {
                dataToLoad = new MainData(formatter);
                dataToLoad.OnAddButtonClicked += DataToLoad_OnAddButtonClicked;
                dataToLoad.OnEditButtonClicked += DataToLoad_OnEditButtonClicked;
                dataToLoad.OnDeleteButtonClicked += DataToLoad_OnDeleteButtonClicked;
                dataToLoad.Dock = DockStyle.Fill;
                dataToLoad.Heading = menu.ToString();
                dataToLoad.Tag = overviewPresenter;
                this._openedMenu.Add(menu, dataToLoad);
            }

            if (this._currentMenu != dataToLoad)
            {
                this.pnlMain.Controls.Add(dataToLoad);

                if (this._currentMenu != null)
                {
                    this.pnlMain.Controls.Remove(this._currentMenu);
                }

                this._currentMenu = dataToLoad;
            }
        }

        private void DataToLoad_OnDeleteButtonClicked(object sender, System.EventArgs e)
        {
            IOverviewPresenter overviewPresenter = this._currentMenu.Tag as IOverviewPresenter;

            DataRow selectedRow = this.GetSelectedItem();

            if (MessageBox.Show($"Are you sure you want to delete selected {this._currentMenu.Heading}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            if (overviewPresenter.DeleteRecord(selectedRow))
            {
                DataTable sourceTable = this._currentMenu.DataSource as DataTable;

                sourceTable.Rows.Remove(selectedRow);
            }
            else
            {
                MessageBox.Show($"Fail to delete the {this._currentMenu.Heading}.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public DataRow GetSelectedItem()
        {
            return (this._currentMenu.SelectedItem as DataRowView).Row;
        }

        private void DataToLoad_OnEditButtonClicked(object sender, System.EventArgs e)
        {
            this._presenter.OpenEditUI();
        }

        private void DataToLoad_OnAddButtonClicked(object sender, System.EventArgs e)
        {
            this._presenter.OpenNewUI();
        }

        public void LoadData(DataTable table)
        {
            this._currentMenu.DataSource = table;
        }

        private void btnCompany_Click(object sender, System.EventArgs e)
        {
            Menu menu = Main.Menu.Home;

            if (sender.Equals(btnCompany))
            {
                menu = Main.Menu.Company;
            }
            else if (sender.Equals(btnBank))
            {
                menu = Main.Menu.Bank;
            }
            else if (sender.Equals(btnCustomer))
            {
                menu = Main.Menu.Customer;
            }
            else if (sender.Equals(btnItem))
            {
                menu = Main.Menu.Item;
            }
            else if (sender.Equals(btnDriver))
            {
                menu = Main.Menu.Driver;
            }
            else if (sender.Equals(btnVehicle))
            {
                menu = Main.Menu.Vehicle;
            }
            else if (sender.Equals(btnFinancialYear))
            {
                menu = Main.Menu.FinancialYear;
            }
            else if (sender.Equals(btnRantal))
            {
                menu = Main.Menu.Voucher;
            }
            else if (sender.Equals(btnInvoice))
            {
                menu = Main.Menu.Invoice;
            }
            else if (sender.Equals(btnPayment))
            {
                menu = Main.Menu.Payment;
            }

            this._presenter.LoadCompanies(menu);
        }

        public void FormatCompanyColumns()
        {
            this._currentMenu.FormatTable();
        }

        public IOverviewPresenter GetOverviewPresenter()
        {
            return this._currentMenu.Tag as IOverviewPresenter;
        }
    }
}
