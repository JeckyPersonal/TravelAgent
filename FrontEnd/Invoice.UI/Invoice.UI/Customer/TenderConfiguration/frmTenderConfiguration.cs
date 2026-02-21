using Invoice.Test.Model.Company;
using Invoice.UI.Customer.RateConfiguration;
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

namespace Invoice.UI.Customer.TenderConfiguration
{
    internal partial class frmTenderConfiguration : TitledForm, ITenderConfigurationView
    {
        private ActionMode _mode;
        private readonly TenderConfigurationPresenter _presenter;
        private TenderDto _dto;
        private readonly int _customerId;

        public frmTenderConfiguration(TenderConfigurationPresenter presenter,int customerID)
        {
            InitializeComponent();
            this._presenter = presenter;
            this._presenter.SetView(this);
            this._customerId = customerID;

        }

        public void ClearUI()
        {
            txtAdjustmentPercentage.Clear();
            txtContractFuelRate.Clear();
            ClearDetailView();
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
            return this._mode;
        }

        public int GetCustomerId()
        {
            return this._customerId;
        }

        public void SetDto(object dto)
        {
            TenderDto tenderDto = dto as TenderDto;
            if (tenderDto.Id == 0)
            {
                this._dto = new TenderDto();
                this._dto.FuelRates = new List<TenderFuelRateDto>();
                this._dto.CustomerID = this._customerId;
                this._mode = ActionMode.New;
            }
            else { 
                this._dto = tenderDto;
                this._mode = ActionMode.Edit;
            }

            cmbContractType.DataSource = Enum.GetValues(typeof(TenderType));
            txtAdjustmentPercentage.Text = this._dto.AdjestmentPercentage.ToString();
            txtContractFuelRate.Text = this._dto.FuelContractRate.ToString();
            cmbContractType.SelectedValue = this._dto.TenderType.ToString();
            
            this._presenter.LoadFuelRates();
        }

        public void SetDetailDto(object dto) 
        {
            TenderFuelRateDto tenderFuelRateDto = dto as TenderFuelRateDto;
            if (tenderFuelRateDto != null) 
            {
                dtpFromDate.Value = new DateTime(tenderFuelRateDto.FromDate.Year,
                    tenderFuelRateDto.FromDate.Month,
                    tenderFuelRateDto.FromDate.Day);

                dtpToDate.Value = new DateTime(tenderFuelRateDto.ToDate.Year, 
                    tenderFuelRateDto.ToDate.Month, 
                    tenderFuelRateDto.ToDate.Day);
                txtFuelRate.Text = tenderFuelRateDto.FuelCost.ToString();
                txtFuelRateID.Text = tenderFuelRateDto.Id.ToString();
            }
        }

        public DataRow GetSelectedFuelRate() 
        {
            DataRowView rowView = this.dgvData.SelectedRows[0].DataBoundItem as DataRowView;
            return rowView.Row;
        }

        public void ShowError(ValidationErrorResponse error)
        {
            throw new NotImplementedException();
        }

        public DialogResult ShowMessage()
        {
            return MessageBox.Show(
               "Tender detail save successfully.",
               "Tender Detail",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information,
               MessageBoxDefaultButton.Button1);
        }

        public int GetTenderId()
        {
            return this._dto.Id;
        }

        public void ClearDetailView()
        {
            txtFuelRateID.Clear();
            txtFuelRate.Clear();
            dtpFromDate.Checked = false;
            dtpToDate.Checked = false;
        }

        public void ShowRates(DataTable table, FuelDataGridFormatter formatter)
        {
            this.dgvData.DataSource = table;
            formatter.ResizeColumn(this.dgvData);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            setDtoValues();
            this._presenter.SaveAndNew();
        }

        private void btnSaveFuelRate_Click(object sender, EventArgs e)
        {
            setDtoValues();


            TenderFuelRateDto newFuelRate = new TenderFuelRateDto() 
            {
                Id = Convert.ToInt32(txtFuelRateID.Text==""? "0" : txtFuelRateID.Text),
                TenderID= this._dto.Id,
                FuelCost = Convert.ToDouble(txtFuelRate.Text),
                FromDate = dtpFromDate.Value.Date,
                ToDate = dtpToDate.Value.Date
            };

            if (this._dto.FuelRates == null)
            {
                newFuelRate.Action = ActionMode.New;
            }
            else if (this._dto.FuelRates.Count == 0)
            {
                newFuelRate.Action = ActionMode.New;
            }
            else if (newFuelRate.Id == 0)
            {
                newFuelRate.Action = ActionMode.New;
            }
            else 
            {
                newFuelRate.Action = ActionMode.Edit;
            }

            this._presenter.saveDetail(newFuelRate);
            this._presenter.LoadFuelRates();
        }

        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this._presenter.EditFuelRate();
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            if (MessageBox.Show($"Are you sure you want to delete selected Fuel Rate?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            if (this._presenter.DeleteFuelRate()) 
            {
                this.dgvData.Rows.Remove(this.dgvData.SelectedRows[0]);
                txtFuelRateID.Clear();
            }
        }

        private void setDtoValues() 
        {
            this._dto.AdjestmentPercentage = Convert.ToDouble(txtAdjustmentPercentage.Text);
            this._dto.FuelContractRate = Convert.ToDouble(txtContractFuelRate.Text);
        }

        private void cmbContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbContractType.SelectedValue.ToString() == "") return;

            this._dto.TenderType = (TenderType)Enum.Parse(typeof(TenderType), cmbContractType.SelectedValue.ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this._presenter.Close();
        }
    }
}
