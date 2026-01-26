using Invoice.Test.Model.Company;
using Invoice.UI.CustomControl;
using Invoice.UI.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace Invoice.UI.Vehicle.VehicleDetail
{
    internal partial class frmVehicleDetail : TitledForm, IVehicleDetailView
    {

        private VehicleDetailDto _dto;
        private ActionMode _actionMode;
        private readonly VehicleDetailPresenter _presenter;
        private readonly int _vehicleId;

        public frmVehicleDetail(VehicleDetailPresenter presenter, int vehicleId)
        {
            InitializeComponent();
            this._vehicleId = vehicleId;
            this._dto = new VehicleDetailDto();
            this._presenter = presenter;
            this._presenter.SetView(this);
        }

        public void ClearUI()
        {
            txtId.Clear();
            txtRegistrationNo.Clear();
        }

        public DialogResult ShowMessage()
        {
            return MessageBox.Show(
                "Vehicle detail save successfully.",
                "Vehicle Detail",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
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
            this._dto = dto as VehicleDetailDto;

            if (this._dto == null)
            {
                this._dto = new VehicleDetailDto();
                this._actionMode = ActionMode.New;
            }
            else if (this._dto.Id == 0)
            {
                this._actionMode = ActionMode.New;
            }
            else
            {
                txtId.Text = this._dto.Id.ToString();
                txtRegistrationNo.Text = this._dto.RegistrationNumber;
                this._actionMode = ActionMode.Edit;
            }

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

        public void SetDataSource(DataTable detailTable)
        {
            this.dgvData.DataSource = detailTable;

            this.dgvData.Columns["Id"].Width = 50;
            this.dgvData.Columns["Registration Number"].Width = 200;
        }

        private void frmVehicleDetail_Load(object sender, EventArgs e)
        {
            this._presenter.LoadDetails(this._vehicleId);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.btnSave.Focus();
            this._presenter.SaveAndNew();
            this._presenter.LoadDetails(this._vehicleId);
            this._actionMode = ActionMode.New;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._presenter.Close();
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            if (sender.Equals(txtId))
            {
                int id = 0;
                if(int.TryParse(txtId.Text, out id))
                {
                    this._dto.Id = id;
                }
            }
            else if (sender.Equals(txtRegistrationNo))
            {
                this._dto.RegistrationNumber = txtRegistrationNo.Text;
            }
        }

        public int GetVehicleId()
        {
            return this._vehicleId;
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this._presenter.EditRegistrationDetail();
            this._actionMode = ActionMode.Edit;
        }

        public DataRow GetSelectedRegistration()
        {
            DataRowView dataRowView = this.dgvData.SelectedRows[0].DataBoundItem as DataRowView;
            return dataRowView.Row;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow deletingRecord = GetSelectedRegistration();
            this._presenter.DeleteRecord(deletingRecord);
            deletingRecord.Delete();
            ClearUI();
        }
    }
}
