using Invoice.Test.Model.Company;
using Invoice.UI.CustomControl;
using Invoice.UI.DTO;
using Invoice.UI.Item;
using Invoice.UI.Vehicle.RateConfiguration;
using Invoice.UI.Vehicle.VehicleDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Vehicle
{
    internal partial class frmVehicle : TitledForm, IVehicleView
    {

        private VehicleDto _dto;
        private ActionMode _actionMode;
        private readonly VehiclePresenter _presenter;

        public frmVehicle(VehiclePresenter presenter)
        {
            InitializeComponent();
            this._dto = new VehicleDto();
            this._presenter = presenter;
            this._presenter.SetView(this);
        }

        public void ClearUI()
        {
            txtVehicleType.Clear();
            txtId.Text = "0";
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
            this._dto = dto as VehicleDto;

            if (this._dto == null || this._dto.Id == 0)
            {
                this._actionMode = ActionMode.New;
                this.btnVehicleDetail.Enabled = false;
                return;
            }

            txtId.Text = this._dto.Id.ToString();
            txtVehicleType.Text = this._dto.VehicleType;

            this.btnVehicleDetail.Enabled = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Focus();
            this._presenter.SaveAndNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._presenter.Close();
        }

        private void txtVehicleType_Leave(object sender, EventArgs e)
        {
            if (sender.Equals(txtId))
            {
                int id;
                if(int.TryParse(txtId.Text, out id))
                {
                    this._dto.Id = id;
                }
            }
            else if (sender.Equals(txtVehicleType))
            {
                this._dto.VehicleType = txtVehicleType.Text;
            }

        }

        private void btnVehicleDetail_Click(object sender, EventArgs e)
        {
            VehicleDetailPresenter presenter = new VehicleDetailPresenter(VehicleDetailRestClient.Instance);
            frmVehicleDetail detail = new frmVehicleDetail(presenter, this._dto.Id);
            presenter.OpenNewUI();
        }

        private void btnAddRateInfo_Click(object sender, EventArgs e)
        {
            VehicleRateConfigurationPresenter presenter = new VehicleRateConfigurationPresenter(VehicleRateConfigurationRestClient.Instance, ItemRestClient.Instance, VehicleRateConfigDataGridFormatter.Instance);
            frmRateConfiguration rateConfiguration = new frmRateConfiguration(presenter, this._dto.VehicleType, this._dto.Id);
            presenter.OpenNewUI();
        }
    }
}
