using Invoice.UI.Company;
using Invoice.UI.CustomControl;
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
        }

        public void LoadView(Menu menu, BasePresenter basePresenter, IDataGridFormatter formatter)
        {
            MainData dataToLoad = null;
            if(!this._openedMenu.TryGetValue(menu, out dataToLoad))
            {
                dataToLoad = new MainData(formatter);
                dataToLoad.OnAddButtonClicked += DataToLoad_OnAddButtonClicked;
                dataToLoad.OnEditButtonClicked += DataToLoad_OnEditButtonClicked;
                dataToLoad.Dock = DockStyle.Fill;
                dataToLoad.Heading = menu.ToString();
                dataToLoad.setBasePresenter(basePresenter);
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

        private void DataToLoad_OnEditButtonClicked(object sender, System.EventArgs e)
        {
            this._presenter.OpenEditUI(1);
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
            this._presenter.LoadCompanies();
        }

        public void FormatCompanyColumns()
        {
            this._currentMenu.FormatTable();
        }
    }
}
