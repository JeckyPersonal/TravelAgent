using Invoice.Test.Model.Company;
using Invoice.UI.CustomControl;
using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Driver
{
    public partial class frmDriver : TitledForm, IDriverView
    {

        private ActionMode _actionMode;
        private DriverDto _dto;
        private readonly DriverPresenter _presenter;

        public frmDriver(DriverPresenter presenter)
        {
            InitializeComponent();
            this._dto = new DriverDto();
            this._presenter = presenter;
            this._presenter.SetView(this);
        }

        public void ClearUI()
        {
            txtId.Text = "0";
            txtName.Clear();
            txtMobileNo.Clear();
            txtDrivingLicense.Clear();
        }

        public DialogResult CloseUI()
        {
            DialogResult result = this.DialogResult;
            this.Close();
            return result;
        }

        public object GetDto()
        {
            return this._dto;
        }

        public ActionMode GetMode()
        {
            return this._actionMode;
        }

        public void SetDto(object dto)
        {
            this._dto = dto as DriverDto;

            if (_dto == null || this._dto.Id == 0)
            {
                this._actionMode = ActionMode.New;
                return;
            }

            txtId.Text = Convert.ToString(_dto.Id);
            txtName.Text = this._dto.DriverName;
            txtMobileNo.Text = this._dto.DriverMobile;
            txtDrivingLicense.Text = this._dto.LicenseNo;

            this._actionMode = ActionMode.Edit;

        }

        public void ShowError(ValidationErrorResponse errorResponse)
        {
            this.flowPanelErrorMessage.Controls.Clear();

            foreach (var item in errorResponse.Errors)
            {
                foreach (string error in item.Value)
                {
                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.Message = error;
                    errorMessage.Dock = DockStyle.Top;
                    errorMessage.Margin = new Padding(0, 3, 0, 3);
                    this.flowPanelErrorMessage.Controls.Add(errorMessage);
                }
            }

            this.flowPanelErrorMessage.Visible = true;
            this.pnlData.PerformLayout();
            this.PerformLayout();
            this.Refresh();
        }

        private void txtDrivingLicense_Leave(object sender, EventArgs e)
        {
            if (sender.Equals(txtId))
            {
                int id = 0;
                if (int.TryParse(txtId.Text, out id))
                {
                    this._dto.Id = id;
                }
            }
            else if (sender.Equals(txtName))
            {
                this._dto.DriverName = txtName.Text;
            }
            else if (sender.Equals(txtMobileNo))
            {
                this._dto.DriverMobile = txtMobileNo.Text;
            }
            else if (sender.Equals(txtDrivingLicense))
            {
                this._dto.LicenseNo = txtDrivingLicense.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._presenter.SaveAndNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._presenter.Close();
        }
    }
}
