using Invoice.UI.CustomControl;
using System.Collections.Generic;
using System.Data;
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

        public void LoadView(Menu menu)
        {
            MainData dataToLoad = null;
            if(!this._openedMenu.TryGetValue(menu, out dataToLoad))
            {
                dataToLoad = new MainData();
                dataToLoad.Dock = DockStyle.Fill;
                dataToLoad.Heading = menu.ToString();
                this._openedMenu.Add(menu, dataToLoad);
            }

            this.pnlMain.Controls.Add(dataToLoad);

            if (this._currentMenu != null)
            {
                this.pnlMain.Controls.Remove(this._currentMenu);
            }

            this._currentMenu = dataToLoad;
        }

        public void LoadData(DataTable table)
        {
            this._currentMenu.DataSource = table;
        }

        private void btnCompany_Click(object sender, System.EventArgs e)
        {
            this._presenter.LoadCompanies();
        }
    }
}
