using Invoice.Test.Model.Company;
using Invoice.UI.DTO;
using Invoice.UI.Vehicle;
using Invoice.UI.Vehicle.RateConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Invoice.UI.Customer.RateConfiguration
{
    internal partial class frmCustomerRateConfiguration : TitledForm, ICutomerRateConfigurationView
    {
        private ActionMode _mode;
        private readonly int _customerId;
        private readonly string _customerName;
        private readonly CustomerRateConfigurationPresenter _presenter;
        private CustomerRateDto _dto;

        public frmCustomerRateConfiguration(CustomerRateConfigurationPresenter presenter, int customerId, string customerName)
        {
            InitializeComponent();
            this._presenter = presenter;
            this._presenter.SetView(this);
            this._customerId = customerId;
            this._customerName = customerName;

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

        public DataRow GetSelectedRate()
        {
            DataRowView rowView = this.dgvRateConfiguration.SelectedRows[0].DataBoundItem as DataRowView;

            return rowView.Row;
        }

        public int GetVehicleId()
        {
            DataRowView dataRowView = this.dgvVehicle.SelectedRows[0].DataBoundItem as DataRowView;

            return Convert.ToInt32(dataRowView.Row[VehicleTableFormatter.COLUMN_NAME_ID]);
        }

        public void SetDto(object dto)
        {

            CustomerRateDto rateDto = dto as CustomerRateDto;

            if (rateDto.Id == 0)
            {
                this._dto = new CustomerRateDto();
                this._mode = ActionMode.New;
                return; 
            }

            this._dto = rateDto;
            this._mode = ActionMode.Edit;
            txtItemName.Text = $"{rateDto.ItemName} ({rateDto.Id})";
            txtUnit.Text = rateDto.Unit;
            txtQuantity.Text = rateDto.Quantity.ToString();
            txtRate.Text = rateDto.Rate.ToString();
        }

        public void updateItem(VehicleRateDto item) 
        {
            this._mode = ActionMode.Edit;
            this._dto.Id = item.Id;
            this._dto.ItemId = item.ItemId;
            this._dto.ItemName = item.ItemName;
            this._dto.Unit = item.Unit;
            this._dto.Quantity = item.Quantity;
            this._dto.Rate = item.Rate;
            

            txtItemName.Text=this._dto.ItemName;
            txtUnit.Text = this._dto.Unit;
            txtQuantity.Text = this._dto.Quantity.ToString();
            txtRate.Text = this._dto.Rate.ToString();

        }

        public void SetItemInfo(ItemMasterDto itemDto)
        {
            if (itemDto == null) return;

            txtItemName.Text = itemDto.ItemName;
            txtQuantity.Text = itemDto.Quantity.ToString();
            txtRate.Text = itemDto.Rate.ToString();
            txtUnit.Text = itemDto.Unit;
        }

        public void SetItemSource(List<string> names)
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(names.ToArray());
            this.txtItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtItemName.AutoCompleteCustomSource = collection;
        }

        public void ShowError(ValidationErrorResponse error)
        {
            throw new NotImplementedException();
        }

        public void ShowRates(DataTable table, VehicleRateConfigDataGridFormatter formatter)
        {
            this.dgvRateConfiguration.DataSource = table;
            formatter.ResizeColumn(this.dgvRateConfiguration);

        }

        private void frmCustomerRateConfiguration_Load(object sender, EventArgs e)
        {
            this._presenter.LoadVehicle();
            this._presenter.SetItemSource();
            this._dto.CustomerId = _customerId;
            this._dto.CustomerName = _customerName;
            lblCustomer.Text = this._dto.CustomerName;

            if (dgvVehicle.Rows.Count > 0) {
                this.ClearUI();
                this._presenter.LoadRates();
            }
        }

        public void SetVehicles(DataTable vehicles)
        {
            this.dgvVehicle.DataSource = vehicles;
            this.dgvVehicle.Columns[VehicleTableFormatter.COLUMN_NAME_ID].Visible = false;
            this.dgvVehicle.Columns[VehicleTableFormatter.COLUMN_NAME_TYPE].Width = 190;
        }

        public int GetCustomerId()
        {
            return this._dto.CustomerId;
        }

        private void dgvVehicle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ClearUI();
            this._presenter.LoadRates();
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            if (txtItemName.Text == string.Empty) { return; }

            if (sender.Equals(txtItemName))
            {
                int openBrecIndex = txtItemName.Text.LastIndexOf("(");

                this._dto.ItemName = txtItemName.Text.Substring(0, openBrecIndex - 1);
                string strId = txtItemName.Text.Substring(openBrecIndex + 1).Replace(")", string.Empty);

                int id = 0;
                if (int.TryParse(strId, out id))
                {
                    this._dto.ItemId = id;
                }

                this._presenter.ShowItemInfo(id);

                double rate = 0;

                double.TryParse(txtRate.Text, out rate);

                this._dto.Rate = rate;
                this._dto.Unit = txtUnit.Text;
            }
            else if (sender.Equals(txtRate))
            {
                double rate = 0;

                double.TryParse(txtRate.Text, out rate);

                this._dto.Rate = rate;
                this._dto.Unit = txtUnit.Text;

                int quantity = 0;
                int.TryParse(txtQuantity.Text, out quantity);
                this._dto.Quantity = quantity;
                this._dto.VehicleId = this.GetVehicleId();
            }
        }

        public void ShowVehicleRate(VehicleRateDto vehicleRate)
        {
            if (vehicleRate == null) return;
            this._dto.ItemId = vehicleRate.ItemId;
            txtItemName.Text = vehicleRate.ItemName;
            txtQuantity.Text = vehicleRate.Quantity.ToString();
            txtRate.Text = vehicleRate.Rate.ToString();
            txtUnit.Text = vehicleRate.Unit;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this._presenter.SaveAndNew();
        }

        private void dgvRateConfiguration_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) {
                return;
            }
            this._presenter.EditRate();
        }
    }
}
