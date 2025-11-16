using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice.UI.Vehicle.RateConfiguration
{
    internal partial class frmRateConfiguration : TitledForm, IVehicleRateConfigurationView
    {

        private readonly string _vehicleName;
        private readonly int _vehicleId;
        private readonly VehicleRateConfigurationPresenter _presenter;
        private ActionMode _mode;
        private VehicleRateDto _dto;

        public frmRateConfiguration(VehicleRateConfigurationPresenter presenter, string vehicleName, int vehicleId)
        {
            InitializeComponent();
            this._vehicleName = vehicleName;
            this._vehicleId = vehicleId;
            this._dto = new VehicleRateDto();
            this._dto.VehicleName = vehicleName;
            this._dto.VehicleId = vehicleId;
            this._presenter = presenter;
            this._presenter.SetView(this);
            this.lblVehicleName.Text = vehicleName;
        }

        public void ClearUI()
        {
            txtItemName.Clear();
            txtQuantity.Clear();
            txtRate.Clear();
            txtUnit.Clear();
        }

        public DialogResult CloseUI()
        {
            DialogResult restult = this.DialogResult;
            this.Close();
            return restult;
        }

        public object GetDto()
        {
            return this._dto;
        }

        public ActionMode GetMode()
        {
            return this._mode;
        }

        public int GetVehicleId()
        {
            return this._vehicleId;
        }

        public void SetDto(object dto)
        {
            VehicleRateDto rateDto = dto as VehicleRateDto;

            if (rateDto.Id == 0)
            {
                this._mode = ActionMode.New;
                return;
            }
            this._dto = rateDto;

            txtItemName.Text = $"{rateDto.ItemName} ({rateDto.Id})";
            txtUnit.Text = rateDto.Unit;
            txtQuantity.Text = rateDto.Quantity.ToString();
            txtRate.Text = rateDto.Rate.ToString();
        }

        public void ShowError(ValidationErrorResponse error)
        {
            throw new NotImplementedException();
        }

        public void ShowRates(DataTable table, VehicleRateConfigDataGridFormatter formatter)
        {
            this.dgvData.DataSource = table;
            formatter.ResizeColumn(this.dgvData);
        }

        private void frmRateConfiguration_Load(object sender, EventArgs e)
        {
            this._presenter.LoadRates();
            this._presenter.SetItemSource();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.btnSave.Focus();
            this._presenter.SaveAndNew();
            this._presenter.LoadRates();
            this._dto = new VehicleRateDto();
            this._dto.VehicleId = _vehicleId;
            this._mode = ActionMode.New;
        }

        public void SetItemSource(List<string> names)
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(names.ToArray());
            this.txtItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtItemName.AutoCompleteCustomSource = collection;
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            if(sender.Equals(txtItemName))
            {
                int openBrecIndex = txtItemName.Text.LastIndexOf("(");

                this._dto.ItemName = txtItemName.Text.Substring(0, openBrecIndex - 1);
                string strId = txtItemName.Text.Substring(openBrecIndex + 1).Replace(")", string.Empty);

                int id = 0;
                if(int.TryParse(strId, out id))
                {
                    this._dto.ItemId = id;
                }

                this._presenter.ShowItemInfo(this._dto.ItemId);
            } else if(sender.Equals(txtRate))
            {
                double rate = 0;
                if (double.TryParse(txtRate.Text, out rate))
                    this._dto.Rate = rate;
            }
        }

        public void SetItemInfo(ItemMasterDto itemDto)
        {
            txtQuantity.Text = itemDto.Quantity.ToString();
            txtUnit.Text = itemDto.Unit.ToString();
        }

        public DataRow GetSelectedRate()
        {
            if(this.dgvData.SelectedRows.Count == 0) return null;

            DataRowView rowView = this.dgvData.SelectedRows[0].DataBoundItem as DataRowView;

            return rowView.Row;
        }

        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this._mode = ActionMode.Edit;
            this._presenter.EditRate();
        }
    }
}
